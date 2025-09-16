using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Models.Asset;

namespace ODMO.Commons.DTOs.Assets
{
    public sealed class NpcPortalsAmountAssetModel
    {
        /// <summary>
        /// Sequencial unique identifier.
        /// </summary>
        public long Id { get; set; }

        public List<NpcPortalsAssetModel> npcPortalsAsset { get; set; }
    }
}