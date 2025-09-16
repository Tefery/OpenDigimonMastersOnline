using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Enums.Character;

namespace ODMO.Application.Admin.Queries
{
    public class GetPlayersQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<CharacterDTO> Registers { get; set; }
    }
}