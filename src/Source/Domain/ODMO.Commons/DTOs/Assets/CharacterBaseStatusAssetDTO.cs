using ODMO.Commons.Enums;
using ODMO.Commons.DTOs.Base;

namespace ODMO.Commons.DTOs.Assets
{
    public sealed class CharacterBaseStatusAssetDTO : StatusDTO
    {
        /// <summary>
        /// Sequencial unique identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Reference tamer type for the atributes.
        /// </summary>
        public CharacterModelEnum Type { get; set; }
    }
}