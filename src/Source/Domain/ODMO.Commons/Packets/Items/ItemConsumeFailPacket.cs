using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.Items
{
    public class ItemConsumeFailPacket : PacketWriter
    {
        private const int PacketNumber = 3902;

        /// <summary>
        /// Returns the reason of not consuming the item.
        /// </summary>
        /// <param name="slot">Consumed item slot</param>
        /// <param name="itemType">Consumed item type</param>
        /// <param name="failReason">Reason of the error</param>
        public ItemConsumeFailPacket(short slot, int itemType, ItemConsumeFailEnum failReason = ItemConsumeFailEnum.OtherError)
        {
            Type(PacketNumber);
            WriteShort(slot);
            WriteInt(itemType);
            WriteInt(failReason.GetHashCode());
        }
    }
}