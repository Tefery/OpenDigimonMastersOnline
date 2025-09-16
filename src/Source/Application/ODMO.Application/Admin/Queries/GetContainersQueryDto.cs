using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Admin.Queries
{
    public class GetContainersQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<ContainerAssetDTO> Registers { get; set; }
    }
}