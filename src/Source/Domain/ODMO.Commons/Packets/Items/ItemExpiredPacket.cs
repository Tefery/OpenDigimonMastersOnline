using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Writers;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace ODMO.Commons.Packets.Items
{
    public class ItemExpiredPacket : PacketWriter
    {
        private const int PacketNumber = 3933;

        /// <summary>
        /// Receives and highlight a new item to the target inventory.
        /// </summary>
        /// <param name="item">The item received.</param>
        /// <param name="inventoryType">The target inventory enumeration.</param>
        /// <param name="slot">The affected slot.</param>
        public ItemExpiredPacket(InventorySlotTypeEnum inventoryType, int slot, int ItemId, ExpiredTypeEnum expired)
        {
            Type(PacketNumber);
            WriteByte((byte)inventoryType);
            WriteByte((byte)slot);
            WriteInt(ItemId);
            WriteInt((int)expired);
        }
    }
}