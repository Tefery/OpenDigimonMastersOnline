using ODMO.Commons.DTOs.Character;

namespace ODMO.Application.Admin.Queries
{
    public class GetPlayerInventoryQueryDto
    {
        public CharacterDTO? Player { get; set; }
    }
}
