<#
.SYNOPSIS
    Automated SQL Server database setup for OpenDigimonMastersOnline project.

.DESCRIPTION
    This script automates the complete setup of SQL Server database for ODMO project including:
    - SQL Server Express LocalDB installation
    - SqlPackage utility installation for BACPAC import
    - ODMO database creation from BACPAC file
    - Environment configuration update
    - Connection validation

.PARAMETER InstallationType
    Type of SQL Server installation: 'LocalDB' (default) or 'Express'

.PARAMETER SkipBacpacImport
    Skip the BACPAC import process (useful for testing installation only)

.PARAMETER Force
    Force reinstallation even if components are already installed

.EXAMPLE
    .\Setup-ODMO-Database.ps1
    
.EXAMPLE
    .\Setup-ODMO-Database.ps1 -InstallationType Express -Force

.NOTES
    Requires Administrator privileges
    Compatible with Windows 10/11 and Windows Server 2016+
    PowerShell 5.1+ required
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $false)]
    [ValidateSet('LocalDB', 'Express')]
    [string]$InstallationType = 'LocalDB',
    
    [Parameter(Mandatory = $false)]
    [switch]$SkipBacpacImport,
    
    [Parameter(Mandatory = $false)]
    [switch]$Force
)

# Script configuration
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'Continue'

# Global variables
$script:LogFile = Join-Path $PSScriptRoot "Setup-ODMO-Database-$(Get-Date -Format 'yyyyMMdd-HHmmss').log"
$script:ProjectRoot = $PSScriptRoot
$script:BacpacFile = Join-Path $ProjectRoot "ODMO.bacpac"
$script:SqlLocalDbMsi = Join-Path $ProjectRoot "SqlLocalDB2022.msi"  # SQL Server 2022 ONLY
$script:EnvFile = Join-Path $ProjectRoot ".env"
$script:SuccessfulConnectionString = $null  # Store successful connection string for environment update

# SQL Server 2022 version requirement
$script:RequiredSqlServerVersion = "160"  # SQL Server 2022

# Color scheme for output
$Colors = @{
    Success = 'Green'
    Warning = 'Yellow'
    Error = 'Red'
    Info = 'Cyan'
    Progress = 'Magenta'
}

#region Helper Functions

function Write-LogMessage {
    param(
        [string]$Message,
        [string]$Level = 'INFO',
        [string]$Color = 'White'
    )

    $timestamp = Get-Date -Format 'yyyy-MM-dd HH:mm:ss'
    $logEntry = "[$timestamp] [$Level] $Message"

    # Write to console with color
    Write-Host $logEntry -ForegroundColor $Color

    # Write to log file
    Add-Content -Path $script:LogFile -Value $logEntry -Encoding UTF8
}

function Test-InternetConnectivity {
    Write-LogMessage "Testing internet connectivity..." 'INFO' $Colors.Info

    try {
        # Test connection to Microsoft download servers
        $testUrls = @(
            "download.microsoft.com",
            "aka.ms",
            "google.com"
        )

        foreach ($url in $testUrls) {
            try {
                $result = Test-NetConnection -ComputerName $url -Port 443 -InformationLevel Quiet -WarningAction SilentlyContinue
                if ($result) {
                    Write-LogMessage "Internet connectivity verified" 'SUCCESS' $Colors.Success
                    return $true
                }
            }
            catch {
                continue
            }
        }

        Write-LogMessage "Internet connectivity test failed" 'WARNING' $Colors.Warning
        return $false
    }
    catch {
        Write-LogMessage "Unable to test internet connectivity: $($_.Exception.Message)" 'WARNING' $Colors.Warning
        return $false
    }
}

function Test-Administrator {
    $currentUser = [Security.Principal.WindowsIdentity]::GetCurrent()
    $principal = New-Object Security.Principal.WindowsPrincipal($currentUser)
    return $principal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
}

function Test-PowerShellVersion {
    return $PSVersionTable.PSVersion.Major -ge 5
}

function Test-FileExists {
    param([string]$FilePath, [string]$Description)
    
    if (-not (Test-Path $FilePath)) {
        Write-LogMessage "Required file not found: $Description at $FilePath" 'ERROR' $Colors.Error
        throw "Missing required file: $Description"
    }
    Write-LogMessage "Found required file: $Description" 'SUCCESS' $Colors.Success
}

# Note: Winget installation function removed - no longer required for core functionality
# The script now works completely offline with local files included in the project

function Install-SqlLocalDB {
    Write-LogMessage "Installing SQL Server LocalDB 2022..." 'INFO' $Colors.Info

    try {
        # Check if SQL Server 2022 LocalDB is already installed
        $localDb2022Path = "${env:ProgramFiles}\Microsoft SQL Server\$script:RequiredSqlServerVersion\Tools\Binn\SqlLocalDB.exe"

        if ((Test-Path $localDb2022Path) -and -not $Force) {
            Write-LogMessage "SQL Server LocalDB 2022 is already installed" 'SUCCESS' $Colors.Success
            return $true
        }

        # Download SQL Server LocalDB 2022 if not present
        if (-not (Test-Path $script:SqlLocalDbMsi)) {
            Write-LogMessage "SQL Server LocalDB 2022 installer not found - downloading automatically..." 'INFO' $Colors.Info

            # Test internet connectivity first
            if (-not (Test-InternetConnectivity)) {
                throw "Internet connectivity required to download SQL Server LocalDB 2022. Please check your connection and try again."
            }

            try {
                $downloadUrl = "https://download.microsoft.com/download/3/8/d/38de7036-2433-4207-8eae-06e247e17b25/SqlLocalDB.msi"
                Write-LogMessage "Downloading from: $downloadUrl" 'INFO' $Colors.Info
                Write-LogMessage "This may take a few minutes (60.6 MB)..." 'INFO' $Colors.Info

                Invoke-WebRequest -Uri $downloadUrl -OutFile $script:SqlLocalDbMsi -UseBasicParsing -TimeoutSec 600

                $fileSize = [math]::Round((Get-Item $script:SqlLocalDbMsi).Length / 1MB, 1)
                Write-LogMessage "SQL Server LocalDB 2022 downloaded successfully ($fileSize MB)" 'SUCCESS' $Colors.Success
            }
            catch {
                Write-LogMessage "Failed to download SQL Server LocalDB 2022: $($_.Exception.Message)" 'ERROR' $Colors.Error
                Write-LogMessage "Please check your internet connection and try again" 'INFO' $Colors.Info
                throw "Unable to download required component: SqlLocalDB2022.msi"
            }
        }

        # Install SQL Server LocalDB 2022
        Test-FileExists $script:SqlLocalDbMsi "SQL Server LocalDB 2022 MSI"

        Write-LogMessage "Installing SQL Server LocalDB 2022 from: $script:SqlLocalDbMsi" 'INFO' $Colors.Info
        $installArgs = @(
            '/i', $script:SqlLocalDbMsi,
            '/qn',
            '/norestart',
            'IACCEPTSQLLOCALDBLICENSETERMS=YES'
        )

        $process = Start-Process -FilePath 'msiexec.exe' -ArgumentList $installArgs -Wait -PassThru

        if ($process.ExitCode -eq 0) {
            Write-LogMessage "SQL Server LocalDB 2022 installed successfully" 'SUCCESS' $Colors.Success

            # Verify SQL Server 2022 installation
            if (Test-Path $localDb2022Path) {
                Write-LogMessage "Verified SQL Server LocalDB 2022 installation" 'SUCCESS' $Colors.Success
                return $true
            } else {
                # Wait a moment and check again (installation might need time)
                Start-Sleep -Seconds 5
                if (Test-Path $localDb2022Path) {
                    Write-LogMessage "Verified SQL Server LocalDB 2022 installation (after delay)" 'SUCCESS' $Colors.Success
                    return $true
                } else {
                    throw "SQL Server LocalDB 2022 installation completed but SqlLocalDB.exe not found at expected location"
                }
            }
        } else {
            throw "Installation failed with exit code: $($process.ExitCode)"
        }
    }
    catch {
        Write-LogMessage "Failed to install SQL Server LocalDB 2022: $($_.Exception.Message)" 'ERROR' $Colors.Error
        throw
    }
}

function Install-SqlPackage {
    Write-LogMessage "Installing SqlPackage utility..." 'INFO' $Colors.Info

    try {
        # Priority 1: Check for local SqlPackage in project directory
        $localSqlPackage = Join-Path $script:ProjectRoot "SqlPackage\sqlpackage.exe"
        if (Test-Path $localSqlPackage) {
            Write-LogMessage "Found local SqlPackage in project directory" 'SUCCESS' $Colors.Success
            return $localSqlPackage
        }

        # Priority 2: Check if already installed in system
        $commonPaths = @(
            "${env:ProgramFiles}\Microsoft SQL Server\160\DAC\bin\sqlpackage.exe",
            "${env:ProgramFiles}\Microsoft SQL Server\150\DAC\bin\sqlpackage.exe",
            "${env:ProgramFiles}\Microsoft SQL Server\140\DAC\bin\sqlpackage.exe",
            "${env:ProgramFiles(x86)}\Microsoft SQL Server\160\DAC\bin\sqlpackage.exe",
            "${env:ProgramFiles(x86)}\Microsoft SQL Server\150\DAC\bin\sqlpackage.exe",
            "${env:LOCALAPPDATA}\Microsoft\WinGet\Packages\Microsoft.SqlPackage_Microsoft.Winget.Source_8wekyb3d8bbwe\sqlpackage.exe"
        )

        foreach ($path in $commonPaths) {
            if (Test-Path $path) {
                Write-LogMessage "Found existing SqlPackage at: $path" 'SUCCESS' $Colors.Success
                if (-not $Force) {
                    return $path
                }
            }
        }

        # Priority 3: Try winget installation (if available)
        $winget = Get-Command winget -ErrorAction SilentlyContinue
        if ($winget) {
            Write-LogMessage "Attempting SqlPackage installation via winget..." 'INFO' $Colors.Info
            try {
                $result = Start-Process -FilePath 'winget' -ArgumentList @('install', 'Microsoft.SqlPackage', '--accept-package-agreements', '--accept-source-agreements', '--silent') -Wait -PassThru

                if ($result.ExitCode -eq 0) {
                    Write-LogMessage "SqlPackage installed via winget" 'SUCCESS' $Colors.Success

                    # Check common paths again
                    foreach ($path in $commonPaths) {
                        if (Test-Path $path) {
                            Write-LogMessage "Found SqlPackage after winget installation: $path" 'SUCCESS' $Colors.Success
                            return $path
                        }
                    }
                }
            }
            catch {
                Write-LogMessage "Winget installation failed: $($_.Exception.Message)" 'WARNING' $Colors.Warning
            }
        }

        # Download and extract SqlPackage to project directory
        Write-LogMessage "SqlPackage not found - downloading automatically..." 'INFO' $Colors.Info

        # Test internet connectivity first
        if (-not (Test-InternetConnectivity)) {
            throw "Internet connectivity required to download SqlPackage. Please check your connection and try again."
        }

        $downloadUrl = "https://aka.ms/sqlpackage-windows"
        $tempZip = Join-Path $script:ProjectRoot "SqlPackage.zip"
        $extractPath = Join-Path $script:ProjectRoot "SqlPackage"

        try {
            Write-LogMessage "Downloading from: $downloadUrl" 'INFO' $Colors.Info
            Write-LogMessage "This may take a few minutes (40+ MB)..." 'INFO' $Colors.Info

            Invoke-WebRequest -Uri $downloadUrl -OutFile $tempZip -UseBasicParsing -TimeoutSec 600

            Write-LogMessage "Extracting SqlPackage..." 'INFO' $Colors.Info
            if (Test-Path $extractPath) {
                Remove-Item $extractPath -Recurse -Force
            }
            Expand-Archive -Path $tempZip -DestinationPath $extractPath -Force
            Remove-Item $tempZip -Force

            $sqlPackageExe = Join-Path $extractPath "sqlpackage.exe"
            if (Test-Path $sqlPackageExe) {
                $fileSize = [math]::Round((Get-Item $sqlPackageExe).Length / 1MB, 1)
                Write-LogMessage "SqlPackage downloaded and extracted successfully ($fileSize MB)" 'SUCCESS' $Colors.Success
                return $sqlPackageExe
            } else {
                throw "SqlPackage.exe not found in extracted files"
            }
        }
        catch {
            Write-LogMessage "Failed to download SqlPackage: $($_.Exception.Message)" 'ERROR' $Colors.Error
            Write-LogMessage "Please check your internet connection and try again" 'INFO' $Colors.Info
            throw "Unable to download required component: SqlPackage"
        }
    }
    catch {
        Write-LogMessage "Failed to install SqlPackage: $($_.Exception.Message)" 'ERROR' $Colors.Error
        throw
    }
}

#endregion

#region Main Functions

function Initialize-LocalDBInstance {
    Write-LogMessage "Initializing SQL Server LocalDB 2022 instance..." 'INFO' $Colors.Info

    try {
        # Use SQL Server 2022 LocalDB only
        $localDbExe = "${env:ProgramFiles}\Microsoft SQL Server\$script:RequiredSqlServerVersion\Tools\Binn\SqlLocalDB.exe"

        if (-not (Test-Path $localDbExe)) {
            throw "SQL Server LocalDB 2022 not found. Please ensure SQL Server LocalDB 2022 is installed."
        }

        Write-LogMessage "Using SQL Server LocalDB 2022: $localDbExe" 'SUCCESS' $Colors.Success
        
        # Check if MSSQLLocalDB instance exists
        $instances = & $localDbExe info
        if ($instances -contains "MSSQLLocalDB") {
            Write-LogMessage "MSSQLLocalDB instance already exists" 'INFO' $Colors.Info
            
            # Check if it's running (support both English and Portuguese)
            $instanceInfo = & $localDbExe info MSSQLLocalDB
            if ($instanceInfo -match "(State:\s+Running|Estado:\s+Executando)") {
                Write-LogMessage "MSSQLLocalDB instance is already running" 'SUCCESS' $Colors.Success
                return $true
            }
        } else {
            # Create the instance
            Write-LogMessage "Creating MSSQLLocalDB instance..." 'INFO' $Colors.Info
            & $localDbExe create MSSQLLocalDB
        }
        
        # Start the instance
        Write-LogMessage "Starting MSSQLLocalDB instance..." 'INFO' $Colors.Info
        & $localDbExe start MSSQLLocalDB
        
        # Verify it's running (support both English and Portuguese)
        Start-Sleep -Seconds 3
        $instanceInfo = & $localDbExe info MSSQLLocalDB
        if ($instanceInfo -match "(State:\s+Running|Estado:\s+Executando)") {
            Write-LogMessage "MSSQLLocalDB instance started successfully" 'SUCCESS' $Colors.Success
            return $true
        } else {
            throw "Failed to start MSSQLLocalDB instance"
        }
    }
    catch {
        Write-LogMessage "Failed to initialize LocalDB instance: $($_.Exception.Message)" 'ERROR' $Colors.Error
        throw
    }
}

function Get-ExistingConnectionString {
    <#
    .SYNOPSIS
    Reads and validates existing ODMO_CONNECTION_STRING from .env file

    .DESCRIPTION
    Checks if there's already a valid database connection configured in .env file
    and tests if it works before assuming we need to reconfigure everything.
    #>

    Write-LogMessage "Checking for existing database configuration..." 'INFO' $Colors.Info

    try {
        if (-not (Test-Path $script:EnvFile)) {
            Write-LogMessage "No .env file found, will create new configuration" 'INFO' $Colors.Info
            return $null
        }

        # Read .env file and extract ODMO_CONNECTION_STRING
        $envContent = Get-Content $script:EnvFile -Encoding UTF8
        $connectionString = $null

        foreach ($line in $envContent) {
            if ($line -match '^ODMO_CONNECTION_STRING=(.+)$') {
                $connectionString = $matches[1].Trim()
                break
            }
        }

        if (-not $connectionString) {
            Write-LogMessage "No ODMO_CONNECTION_STRING found in .env file" 'INFO' $Colors.Info
            return $null
        }

        Write-LogMessage "Found existing connection string, testing connectivity..." 'INFO' $Colors.Info

        # Test the existing connection
        Add-Type -AssemblyName System.Data
        $connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)

        try {
            $connection.Open()

            # Test if ODMO database exists
            $command = $connection.CreateCommand()
            $command.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_CATALOG = 'ODMO'"
            $tableCount = $command.ExecuteScalar()

            if ($tableCount -gt 0) {
                Write-LogMessage "Existing ODMO database found with $tableCount tables - connection is valid!" 'SUCCESS' $Colors.Success
                $connection.Close()
                return $connectionString
            } else {
                Write-LogMessage "Connection works but ODMO database is empty or missing" 'WARNING' $Colors.Warning
                $connection.Close()
                return $connectionString  # Return it anyway, we can import to it
            }
        }
        catch {
            Write-LogMessage "Existing connection failed: $($_.Exception.Message)" 'WARNING' $Colors.Warning
            if ($connection.State -eq 'Open') { $connection.Close() }
            return $null
        }
    }
    catch {
        Write-LogMessage "Error checking existing configuration: $($_.Exception.Message)" 'WARNING' $Colors.Warning
        return $null
    }
}

function Get-PreferredConnectionString {
    <#
    .SYNOPSIS
    Determines the best connection string to use based on user configuration and system compatibility

    .DESCRIPTION
    Intelligently detects if user has SQL Server credentials configured and respects their choice.
    Falls back to appropriate authentication method if needed.
    #>

    Write-LogMessage "Determining optimal database connection method..." 'INFO' $Colors.Info

    try {
        # Check if user has SQL Server credentials configured in .env
        if (Test-Path $script:EnvFile) {
            $envContent = Get-Content $script:EnvFile -Encoding UTF8

            foreach ($line in $envContent) {
                if ($line -match '^ODMO_CONNECTION_STRING=(.+)$') {
                    $configuredConnection = $matches[1].Trim()

                    # Extract server name from user configuration
                    $serverName = $null
                    if ($configuredConnection -match "Server=([^;]+)") {
                        $serverName = $matches[1].Trim()
                    }

                    # If user has ANY server configured (not LocalDB), respect their choice
                    if ($serverName -and $serverName -notmatch "localdb.*MSSQLLocalDB") {
                        Write-LogMessage "Detected user-configured server in .env - respecting user preference" 'INFO' $Colors.Info
                        Write-LogMessage "User configured server: $serverName" 'INFO' $Colors.Info

                        # Respect user's server choice - DO NOT force LocalDB
                        $preferredConnection = $configuredConnection

                        # Only ensure ODMO database name
                        if ($preferredConnection -notmatch "Database=ODMO") {
                            if ($preferredConnection -match "Database=([^;]+)") {
                                $preferredConnection = $preferredConnection -replace "Database=([^;]+)", "Database=ODMO"
                            } else {
                                $preferredConnection += ";Database=ODMO"
                            }
                        }

                        if ($configuredConnection -match "User Id=|UserId=") {
                            Write-LogMessage "Using SQL Server authentication: $($preferredConnection -replace 'Password=[^;]+', 'Password=***')" 'INFO' $Colors.Info
                        } else {
                            Write-LogMessage "Using Windows authentication: $($preferredConnection -replace 'Password=[^;]+', 'Password=***')" 'INFO' $Colors.Info
                        }
                        return $preferredConnection
                    }
                    break
                }
            }
        }

        # Only use LocalDB if no user server is configured
        $defaultConnection = "Server=(localdb)\MSSQLLocalDB;Database=ODMO;Integrated Security=true;TrustServerCertificate=True"
        Write-LogMessage "No user server configured, using default LocalDB" 'INFO' $Colors.Info
        return $defaultConnection
    }
    catch {
        Write-LogMessage "Error determining connection method: $($_.Exception.Message)" 'WARNING' $Colors.Warning
        # Fallback to default
        return "Server=(localdb)\MSSQLLocalDB;Database=ODMO;Integrated Security=true;TrustServerCertificate=True"
    }
}

function Set-SqlServerAuthenticationFallback {
    <#
    .SYNOPSIS
    Configures SQL Server authentication as fallback when Windows Authentication fails

    .DESCRIPTION
    Sets up SQL Server authentication with default credentials when Integrated Security fails
    #>

    Write-LogMessage "Configuring SQL Server authentication fallback..." 'INFO' $Colors.Info

    try {
        # Configure LocalDB to accept SQL Server authentication
        $localDbExe = "${env:ProgramFiles}\Microsoft SQL Server\160\Tools\Binn\SqlLocalDB.exe"

        # Stop and reconfigure LocalDB instance
        & $localDbExe stop MSSQLLocalDB 2>$null
        Start-Sleep -Seconds 2
        & $localDbExe start MSSQLLocalDB
        Start-Sleep -Seconds 3

        # Create SQL Server authentication connection string
        $sqlAuthConnection = "Server=(localdb)\MSSQLLocalDB;Database=ODMO;User Id=sa;Password=123456;TrustServerCertificate=True"

        Write-LogMessage "Configured SQL Server authentication fallback" 'SUCCESS' $Colors.Success
        return $sqlAuthConnection
    }
    catch {
        Write-LogMessage "Failed to configure SQL Server authentication: $($_.Exception.Message)" 'ERROR' $Colors.Error
        return $null
    }
}

function Import-BacpacDatabase {
    param([string]$SqlPackagePath)
    
    if ($SkipBacpacImport) {
        Write-LogMessage "Skipping BACPAC import as requested" 'WARNING' $Colors.Warning
        return $true
    }
    
    Write-LogMessage "Importing ODMO database from BACPAC file..." 'INFO' $Colors.Info

    try {
        Test-FileExists $script:BacpacFile "ODMO BACPAC file"

        # Clean up any existing database files to ensure fresh import
        Write-LogMessage "Preparing clean database environment..." 'INFO' $Colors.Info
        $localDbExe = "${env:ProgramFiles}\Microsoft SQL Server\160\Tools\Binn\SqlLocalDB.exe"

        try {
            # Ensure LocalDB instance is running
            & $localDbExe start MSSQLLocalDB 2>$null

            # Remove existing ODMO database if it exists using SQL commands
            $cleanupConnectionString = "Server=(localdb)\MSSQLLocalDB;Integrated Security=true;TrustServerCertificate=True"

            try {
                $cleanupConnection = New-Object System.Data.SqlClient.SqlConnection($cleanupConnectionString)
                $cleanupConnection.Open()

                # Drop ODMO database if it exists
                $dropCommand = $cleanupConnection.CreateCommand()
                $dropCommand.CommandText = @"
                    IF EXISTS (SELECT name FROM sys.databases WHERE name = 'ODMO')
                    BEGIN
                        ALTER DATABASE [ODMO] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                        DROP DATABASE [ODMO];
                    END
"@
                $dropCommand.ExecuteNonQuery()
                $cleanupConnection.Close()

                Write-LogMessage "Removed existing ODMO database" 'INFO' $Colors.Info
            }
            catch {
                Write-LogMessage "No existing ODMO database found or cleanup not needed: $($_.Exception.Message)" 'INFO' $Colors.Info
            }

            # Remove any existing database files
            $dbFilesPath = "${env:USERPROFILE}\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\ODMO*"
            Remove-Item $dbFilesPath -Force -ErrorAction SilentlyContinue

            Write-LogMessage "Clean SQL Server LocalDB 2022 instance prepared" 'SUCCESS' $Colors.Success
        }
        catch {
            Write-LogMessage "Warning during database cleanup: $($_.Exception.Message)" 'WARNING' $Colors.Warning
        }

        # Use intelligent connection string detection
        $targetConnectionString = Get-PreferredConnectionString

        # Ensure the connection string includes the database name
        if ($targetConnectionString -notmatch "Database=ODMO") {
            if ($targetConnectionString -match "Database=([^;]+)") {
                $targetConnectionString = $targetConnectionString -replace "Database=([^;]+)", "Database=ODMO"
            } else {
                $targetConnectionString += ";Database=ODMO"
            }
        }

        Write-LogMessage "Starting BACPAC import (this may take several minutes)..." 'INFO' $Colors.Info
        Write-LogMessage "BACPAC file size: $([math]::Round((Get-Item $script:BacpacFile).Length / 1MB, 2)) MB" 'INFO' $Colors.Info
        Write-LogMessage "Target connection: $($targetConnectionString -replace 'Password=[^;]*', 'Password=***')" 'INFO' $Colors.Info

        $importArgs = @(
            '/Action:Import',
            "/SourceFile:$script:BacpacFile",
            "/TargetConnectionString:`"$targetConnectionString`"",
            '/p:CommandTimeout=1800'  # 30 minutes timeout
        )
        
        $process = Start-Process -FilePath $SqlPackagePath -ArgumentList $importArgs -Wait -PassThru -NoNewWindow

        if ($process.ExitCode -eq 0) {
            Write-LogMessage "BACPAC import completed successfully" 'SUCCESS' $Colors.Success

            # Store the successful connection string for future use
            $script:SuccessfulConnectionString = $targetConnectionString
            return $true
        } else {
            # Try alternative authentication method as fallback
            $fallbackConnection = $null

            # Extract server name from original connection string
            $userServerName = "Server=(localdb)\MSSQLLocalDB"  # Default fallback
            if ($targetConnectionString -match "Server=([^;]+)") {
                $userServerName = "Server=$($matches[1].Trim())"
            }

            if ($targetConnectionString -match "User Id=|UserId=") {
                # SQL Server Authentication failed, try Windows Authentication with user's server
                Write-LogMessage "SQL Server Authentication failed, trying Windows Authentication fallback..." 'WARNING' $Colors.Warning
                Write-LogMessage "Using user's server: $userServerName" 'INFO' $Colors.Info
                $fallbackConnection = "$userServerName;Database=ODMO;Integrated Security=true;TrustServerCertificate=True"
            } elseif ($targetConnectionString -match "Integrated Security=true") {
                # Windows Authentication failed, try SQL Server Authentication with user's server
                Write-LogMessage "Windows Authentication failed, trying SQL Server Authentication fallback..." 'WARNING' $Colors.Warning
                Write-LogMessage "Using user's server: $userServerName" 'INFO' $Colors.Info
                $fallbackConnection = "$userServerName;Database=ODMO;User Id=sa;Password=123456;TrustServerCertificate=True"
            }

            if ($fallbackConnection) {
                Write-LogMessage "Retrying BACPAC import with alternative authentication..." 'INFO' $Colors.Info
                Write-LogMessage "Fallback connection: $($fallbackConnection -replace 'Password=[^;]*', 'Password=***')" 'INFO' $Colors.Info

                $fallbackArgs = @(
                    '/Action:Import',
                    "/SourceFile:$script:BacpacFile",
                    "/TargetConnectionString:`"$fallbackConnection`"",
                    '/p:CommandTimeout=1800'
                )

                $fallbackProcess = Start-Process -FilePath $SqlPackagePath -ArgumentList $fallbackArgs -Wait -PassThru -NoNewWindow

                if ($fallbackProcess.ExitCode -eq 0) {
                    Write-LogMessage "BACPAC import completed successfully with fallback authentication" 'SUCCESS' $Colors.Success
                    $script:SuccessfulConnectionString = $fallbackConnection
                    return $true
                } else {
                    Write-LogMessage "Fallback authentication also failed with exit code: $($fallbackProcess.ExitCode)" 'ERROR' $Colors.Error

                    # Final fallback: try LocalDB if user's server is not available
                    if ($userServerName -notmatch "localdb.*MSSQLLocalDB") {
                        Write-LogMessage "User's server appears unavailable, trying LocalDB as final fallback..." 'WARNING' $Colors.Warning
                        $localDbConnection = "Server=(localdb)\MSSQLLocalDB;Database=ODMO;Integrated Security=true;TrustServerCertificate=True"

                        $localDbArgs = @(
                            '/Action:Import',
                            "/SourceFile:$script:BacpacFile",
                            "/TargetConnectionString:`"$localDbConnection`"",
                            '/p:CommandTimeout=1800'
                        )

                        $localDbProcess = Start-Process -FilePath $SqlPackagePath -ArgumentList $localDbArgs -Wait -PassThru -NoNewWindow

                        if ($localDbProcess.ExitCode -eq 0) {
                            Write-LogMessage "BACPAC import completed successfully with LocalDB fallback" 'SUCCESS' $Colors.Success
                            $script:SuccessfulConnectionString = $localDbConnection
                            return $true
                        } else {
                            Write-LogMessage "LocalDB fallback also failed with exit code: $($localDbProcess.ExitCode)" 'ERROR' $Colors.Error
                        }
                    }
                }
            }

            throw "BACPAC import failed with exit code: $($process.ExitCode). All authentication methods failed."
        }
    }
    catch {
        Write-LogMessage "Failed to import BACPAC: $($_.Exception.Message)" 'ERROR' $Colors.Error
        throw
    }
}

function Update-EnvironmentConfiguration {
    Write-LogMessage "Updating environment configuration..." 'INFO' $Colors.Info

    try {
        # Use the successful connection string from import, or check existing valid connection
        $connectionStringToUse = $null

        if ($script:SuccessfulConnectionString) {
            $connectionStringToUse = $script:SuccessfulConnectionString
            Write-LogMessage "Using successful connection string from BACPAC import" 'INFO' $Colors.Info
        } else {
            $existingConnectionString = Get-ExistingConnectionString
            if ($existingConnectionString) {
                $connectionStringToUse = $existingConnectionString
                Write-LogMessage "Valid connection string already exists in .env file - keeping existing configuration" 'SUCCESS' $Colors.Success
            }
        }

        if ($connectionStringToUse) {
            Write-LogMessage "Connection string: $($connectionStringToUse -replace 'Password=[^;]*', 'Password=***')" 'INFO' $Colors.Info
            $newConnectionString = $connectionStringToUse
        } else {
            # If no valid connection exists, create default LocalDB connection
            $newConnectionString = "Server=(localdb)\MSSQLLocalDB;Database=ODMO;Integrated Security=true;TrustServerCertificate=True"
            Write-LogMessage "Creating new LocalDB connection string in .env file" 'INFO' $Colors.Info
        }

        if (Test-Path $script:EnvFile) {
            # Read existing .env file
            $envContent = Get-Content $script:EnvFile -Raw

            # Update the connection string using regex
            $pattern = '^ODMO_CONNECTION_STRING=.*$'
            $replacement = "ODMO_CONNECTION_STRING=$newConnectionString"

            if ($envContent -match $pattern) {
                $envContent = $envContent -replace $pattern, $replacement
                Write-LogMessage "Updated existing ODMO_CONNECTION_STRING in .env file" 'SUCCESS' $Colors.Success
            } else {
                # Add the connection string if it doesn't exist
                $envContent += "`nODMO_CONNECTION_STRING=$newConnectionString`n"
                Write-LogMessage "Added ODMO_CONNECTION_STRING to .env file" 'SUCCESS' $Colors.Success
            }
            
            # Write back to file
            Set-Content -Path $script:EnvFile -Value $envContent -Encoding UTF8
        } else {
            Write-LogMessage ".env file not found, creating from template..." 'INFO' $Colors.Info
            $envExampleFile = Join-Path $ProjectRoot ".env.example"
            
            if (Test-Path $envExampleFile) {
                Copy-Item $envExampleFile $script:EnvFile
                
                # Update the connection string
                $envContent = Get-Content $script:EnvFile -Raw
                $pattern = '^ODMO_CONNECTION_STRING=.*$'
                $replacement = "ODMO_CONNECTION_STRING=$newConnectionString"
                $envContent = $envContent -replace $pattern, $replacement
                Set-Content -Path $script:EnvFile -Value $envContent -Encoding UTF8
                
                Write-LogMessage "Created .env file from template with LocalDB connection string" 'SUCCESS' $Colors.Success
            } else {
                throw ".env.example file not found"
            }
        }
        
        Write-LogMessage "Environment configuration updated successfully" 'SUCCESS' $Colors.Success
        Write-LogMessage "Connection string: $newConnectionString" 'INFO' $Colors.Info
        return $true
    }
    catch {
        Write-LogMessage "Failed to update environment configuration: $($_.Exception.Message)" 'ERROR' $Colors.Error
        throw
    }
}

function Test-DatabaseConnection {
    Write-LogMessage "Testing database connection..." 'INFO' $Colors.Info

    try {
        # Use the connection string from .env file
        $connectionString = Get-ExistingConnectionString

        if (-not $connectionString) {
            $connectionString = "Server=(localdb)\MSSQLLocalDB;Database=ODMO;Integrated Security=true;TrustServerCertificate=True"
            Write-LogMessage "No .env connection found, using default LocalDB connection" 'WARNING' $Colors.Warning
        } else {
            Write-LogMessage "Using connection string from .env file" 'INFO' $Colors.Info
        }

        # Test using sqlcmd if available
        $sqlcmd = Get-Command sqlcmd -ErrorAction SilentlyContinue
        if ($sqlcmd) {
            Write-LogMessage "Testing connection using sqlcmd..." 'INFO' $Colors.Info
            $result = & sqlcmd -S "(localdb)\MSSQLLocalDB" -d "ODMO" -E -Q "SELECT COUNT(*) as TableCount FROM INFORMATION_SCHEMA.TABLES" -h -1

            if ($LASTEXITCODE -eq 0 -and $result -match '\d+') {
                $tableCount = [int]($result -replace '\s+', '')
                Write-LogMessage "Database connection successful. Found $tableCount tables." 'SUCCESS' $Colors.Success
                return $true
            }
        }

        # Fallback: Test using .NET SqlConnection
        Write-LogMessage "Testing connection using .NET SqlConnection..." 'INFO' $Colors.Info
        Add-Type -AssemblyName System.Data

        $connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
        $connection.Open()

        $command = $connection.CreateCommand()
        $command.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES"
        $tableCount = $command.ExecuteScalar()

        $connection.Close()

        Write-LogMessage "Database connection successful. Found $tableCount tables." 'SUCCESS' $Colors.Success
        return $true
    }
    catch {
        Write-LogMessage "Database connection test failed: $($_.Exception.Message)" 'ERROR' $Colors.Error
        return $false
    }
}

function Show-SetupSummary {
    param([hashtable]$Results)

    $separator = "="*80
    Write-LogMessage "`n$separator" 'INFO' $Colors.Info
    Write-LogMessage "ODMO DATABASE SETUP SUMMARY" 'INFO' $Colors.Info
    Write-LogMessage "$separator" 'INFO' $Colors.Info

    foreach ($step in $Results.Keys) {
        $status = if ($Results[$step]) { "SUCCESS" } else { "FAILED" }
        $logLevel = if ($Results[$step]) { 'SUCCESS' } else { 'ERROR' }
        $color = if ($Results[$step]) { $Colors.Success } else { $Colors.Error }
        Write-LogMessage "$step : $status" $logLevel $color
    }

    Write-LogMessage "`nLog file: $script:LogFile" 'INFO' $Colors.Info

    if ($Results.Values -contains $false) {
        Write-LogMessage "Setup completed with errors. Check the log file for details." 'WARNING' $Colors.Warning
        return $false
    } else {
        Write-LogMessage "Setup completed successfully!" 'SUCCESS' $Colors.Success
        Write-LogMessage "You can now run the ODMO project with the configured database." 'INFO' $Colors.Info
        return $true
    }
}

#endregion

#region Main Execution

function Main {
    Write-LogMessage "================================================================================" 'INFO' $Colors.Info
    Write-LogMessage "ODMO DATABASE SETUP - AUTOMATED INSTALLATION" 'INFO' $Colors.Info
    Write-LogMessage "================================================================================" 'INFO' $Colors.Info
    Write-LogMessage "This script will automatically:" 'INFO' $Colors.Info
    Write-LogMessage "  1. Download SQL Server LocalDB 2022 (if needed)" 'INFO' $Colors.Info
    Write-LogMessage "  2. Download SqlPackage utility (if needed)" 'INFO' $Colors.Info
    Write-LogMessage "  3. Install SQL Server LocalDB 2022" 'INFO' $Colors.Info
    Write-LogMessage "  4. Import ODMO database (186 tables, 23 schemas)" 'INFO' $Colors.Info
    Write-LogMessage "  5. Configure environment (.env file)" 'INFO' $Colors.Info
    Write-LogMessage "  6. Test database connectivity" 'INFO' $Colors.Info
    Write-LogMessage "" 'INFO' $Colors.Info
    Write-LogMessage "Installation Type: $InstallationType" 'INFO' $Colors.Info
    Write-LogMessage "Project Root: $script:ProjectRoot" 'INFO' $Colors.Info
    Write-LogMessage "Log File: $script:LogFile" 'INFO' $Colors.Info
    Write-LogMessage "" 'INFO' $Colors.Info

    $results = @{}

    try {
        # Prerequisites check
        Write-LogMessage "`nChecking prerequisites..." 'INFO' $Colors.Info

        if (-not (Test-Administrator)) {
            throw "This script requires Administrator privileges. Please run as Administrator."
        }
        $results['Administrator Check'] = $true

        if (-not (Test-PowerShellVersion)) {
            throw "PowerShell 5.1 or higher is required."
        }
        $results['PowerShell Version Check'] = $true

        # File existence checks
        Test-FileExists $script:BacpacFile "ODMO BACPAC file"
        # Note: SqlLocalDB MSI will be downloaded automatically if needed
        $results['Required Files Check'] = $true

        # Install SQL Server LocalDB
        Write-LogMessage "`nInstalling SQL Server components..." 'INFO' $Colors.Info
        $results['SQL Server Installation'] = Install-SqlLocalDB

        # Initialize LocalDB instance
        Write-LogMessage "`nInitializing database instance..." 'INFO' $Colors.Info
        $results['Database Instance Setup'] = Initialize-LocalDBInstance

        # Install SqlPackage
        Write-LogMessage "`nInstalling SqlPackage utility..." 'INFO' $Colors.Info
        $sqlPackagePath = Install-SqlPackage
        $results['SqlPackage Installation'] = $true

        # Import BACPAC
        if (-not $SkipBacpacImport) {
            Write-LogMessage "`nImporting database from BACPAC..." 'INFO' $Colors.Info
            $results['BACPAC Import'] = Import-BacpacDatabase -SqlPackagePath $sqlPackagePath
        } else {
            $results['BACPAC Import'] = $true  # Skipped
        }

        # Update environment configuration
        Write-LogMessage "`nUpdating environment configuration..." 'INFO' $Colors.Info
        $results['Environment Configuration'] = Update-EnvironmentConfiguration

        # Test database connection
        Write-LogMessage "`nValidating database setup..." 'INFO' $Colors.Info
        $results['Database Connection Test'] = Test-DatabaseConnection

        # Show summary
        $success = Show-SetupSummary -Results $results

        if ($success) {
            Write-LogMessage "Next steps:" 'INFO' $Colors.Info
            Write-LogMessage "1. Run Test-ODMO-Database.ps1 to perform comprehensive validation" 'INFO' $Colors.Info
            Write-LogMessage "2. Start the ODMO project using your preferred method" 'INFO' $Colors.Info
            Write-LogMessage "3. Check the application logs for any database-related issues" 'INFO' $Colors.Info
        }

        return $success
    }
    catch {
        Write-LogMessage "Setup failed: $($_.Exception.Message)" 'ERROR' $Colors.Error
        $results['Setup'] = $false
        Show-SetupSummary -Results $results
        return $false
    }
}

# Script entry point
if ($MyInvocation.InvocationName -ne '.') {
    $success = Main
    exit $(if ($success) { 0 } else { 1 })
}

#endregion
