using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Admin.Queries
{
    public class GetSpawnPointsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<MapRegionAssetDTO> Registers { get; set; }
    }
}