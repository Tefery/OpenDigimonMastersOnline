using ODMO.Commons.Models.Base;
using ODMO.Commons.Models.TamerShop;
using ODMO.Commons.Writers;

using ODMO.Commons.Entities;

namespace ODMO.Commons.Packets.PersonalShop
{
    public class PersonalShopItemsViewPacket : PacketWriter
    {
        private const int PacketNumber = 1515;

        /// <summary>
        /// Shows the selling item list in the target consigned shop.
        /// </summary>
        /// <param name="consignedShop">The consigned shop basic information.</param>
        /// <param name="consignedShopItems">The consigned shop items.</param>
        /// <param name="ownerName">The consigned shop owner name.</param>
        public PersonalShopItemsViewPacket(ItemListModel consignedShopItems, string ownerName)
        {
            Type(PacketNumber);
            WriteInt(100);
            WriteString(ownerName);
            WriteInt(consignedShopItems.Count);

            foreach (var item in consignedShopItems.Items.Where(x => x.ItemId > 0))
            {
                WriteBytes(item.ToArray());
                WriteInt64(item.TamerShopSellPrice);
            }
        }
    }
}