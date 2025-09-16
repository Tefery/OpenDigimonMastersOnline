using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Admin.Queries
{
    public class GetScansQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<ScanDetailAssetDTO> Registers { get; set; }
    }
}