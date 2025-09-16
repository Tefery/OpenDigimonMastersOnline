using ODMO.Commons.DTOs.Assets;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateScanConfigCommand : IRequest
    {
        public ScanDetailAssetDTO Scan { get; }

        public UpdateScanConfigCommand(ScanDetailAssetDTO scan)
        {
            Scan = scan;
        }
    }
}