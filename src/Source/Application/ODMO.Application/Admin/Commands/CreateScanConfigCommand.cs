using ODMO.Commons.DTOs.Assets;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateScanConfigCommand : IRequest<ScanDetailAssetDTO>
    {
        public ScanDetailAssetDTO Scan { get; }

        public CreateScanConfigCommand(ScanDetailAssetDTO scan)
        {
            Scan = scan;
        }
    }
}