using ODMO.Commons.Models.Base;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class ItemRerollPacket : PacketWriter
    {
        private const int PacketNumber = 3969;

        public ItemRerollPacket(byte result, short accessorySlot, ItemModel accessory)
        {
            Type(PacketNumber);
            WriteByte(result);
            WriteShort(accessorySlot);
            WriteByte(accessory.Power);
            WriteByte(accessory.RerollLeft);

            foreach (var status in accessory.AccessoryStatus.OrderBy(x => x.Slot))
            {
                WriteShort((short)status.Type);
            }

            foreach (var status in accessory.AccessoryStatus.OrderBy(x => x.Slot))
            {
                WriteShort(status.Value);
            }
        }

    }
}