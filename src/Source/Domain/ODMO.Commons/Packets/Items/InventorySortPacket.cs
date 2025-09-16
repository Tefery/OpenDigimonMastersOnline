using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.Items
{
    public class InventorySortPacket : PacketWriter
    {
        private const int PacketNumber = 3986;

        /// <summary>
        /// Sorts the itens on tamer's target inventory.
        /// </summary>
        /// <param name="inventory">The itens to sort</param>
        /// <param name="inventoryType">Inventory type</param>
        public InventorySortPacket(ItemListModel inventory, InventoryTypeEnum inventoryType)
        {
            Type(PacketNumber);
            WriteByte((byte)inventoryType);
            WriteInt(1);
            WriteShort(inventory.Size);
            WriteBytes(inventory.ToArray());
        }
    }
}
