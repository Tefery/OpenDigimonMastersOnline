using ODMO.Commons.Enums;
using ODMO.Commons.DTOs.Base;

namespace ODMO.Commons.DTOs.Assets
{
    public sealed class CharacterLevelStatusAssetDTO : StatusDTO
    {
        /// <summary>
        /// Sequencial unique identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Reference tamer type for the atributes.
        /// </summary>
        public CharacterModelEnum Type { get; set; }

        /// <summary>
        /// Level reference for the status.
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// Exp required for the next level.
        /// </summary>
        public long ExpValue { get; set; }
    }
}