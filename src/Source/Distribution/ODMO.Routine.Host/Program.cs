using ODMO.Application;
using ODMO.Application.Admin.Repositories;
using ODMO.Application.Extensions;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Repositories.Admin;
using ODMO.Infrastructure;
using ODMO.Infrastructure.Extensions;
using ODMO.Infrastructure.Mapping;
using ODMO.Infrastructure.Repositories.Account;
using ODMO.Infrastructure.Repositories.Admin;
using ODMO.Infrastructure.Repositories.Character;
using ODMO.Infrastructure.Repositories.Config;
using ODMO.Infrastructure.Repositories.Routine;
using ODMO.Infrastructure.Repositories.Server;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Globalization;
using System.Reflection;
using ODMO.Commons.Utils;

namespace ODMO.Routine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Run();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(((Exception)e.ExceptionObject).InnerException);
            if (e.IsTerminating)
            {
                var message = "";
                var exceptionStackTrace = "";
                if (e.ExceptionObject is Exception exception) 
                {
                    message =  exception.Message;
                    exceptionStackTrace = exception.StackTrace;
                }
                Console.WriteLine($"{message}");
                Console.WriteLine($"{exceptionStackTrace}");
                Console.WriteLine("Terminating by unhandled exception...");
            }
            else
                Console.WriteLine("Received unhandled exception.");

            Console.ReadLine();
        }

        public static IHost CreateHostBuilder(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseEnvironment("Development")
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<DatabaseContext>();

                    //TODO: remover após segregar
                    services.AddScoped<IAdminQueriesRepository, AdminQueriesRepository>();
                    services.AddScoped<IAdminCommandsRepository, AdminCommandsRepository>();
                    services.AddScoped<IAccountQueriesRepository, AccountQueriesRepository>();
                    services.AddScoped<IAccountCommandsRepository, AccountCommandsRepository>();
                    services.AddScoped<IServerQueriesRepository, ServerQueriesRepository>();
                    services.AddScoped<IServerCommandsRepository, ServerCommandsRepository>();
                    services.AddScoped<ICharacterQueriesRepository, CharacterQueriesRepository>();
                    services.AddScoped<ICharacterCommandsRepository, CharacterCommandsRepository>();
                    services.AddScoped<IConfigQueriesRepository, ConfigQueriesRepository>();
                    services.AddScoped<IConfigCommandsRepository, ConfigCommandsRepository>();
                    services.AddAutoMapper(typeof(AccountProfile));
                    services.AddAutoMapper(typeof(AssetsProfile));
                    services.AddAutoMapper(typeof(CharacterProfile));
                    services.AddAutoMapper(typeof(ConfigProfile));
                    services.AddAutoMapper(typeof(DigimonProfile));
                    services.AddAutoMapper(typeof(GameProfile));
                    services.AddAutoMapper(typeof(SecurityProfile));
                    services.AddAutoMapper(typeof(ArenaProfile));
                    services.AddAutoMapper(typeof(RoutineProfile));
                    services.AddScoped<IRoutineRepository, RoutineRepository>();
                    services.AddSingleton<ISender, ScopedSender<Mediator>>();
                    services.AddSingleton(ConfigureLogger(context.Configuration));
                    services.AddHostedService<RoutineServer>();
                    services.AddTransient<Mediator>();
                    services.AddSingleton<AssetsLoader>();
                    services.AddMediatR(typeof(MediatorApplicationHandlerExtension).GetTypeInfo().Assembly);
                })
                .ConfigureHostConfiguration(hostConfig =>
                {
                    hostConfig.SetBasePath(Directory.GetCurrentDirectory())
                              .AddEnvironmentVariables(Constants.Configuration.EnvironmentPrefix)
                              .AddUserSecrets<Program>();
                })
                .Build();
        }

        private static ILogger ConfigureLogger(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.RollingFile(configuration["Log:DebugRepository"] ?? "logs\\Debug\\RoutineServer", Serilog.Events.LogEventLevel.Information, retainedFileCountLimit: 10)
                .CreateLogger();
        }
    }
}