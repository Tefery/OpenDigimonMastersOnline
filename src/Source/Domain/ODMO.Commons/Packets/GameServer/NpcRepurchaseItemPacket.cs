using ODMO.Commons.Models.Base;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class NpcRepurchaseItemPacket : PacketWriter
    {
        private const int PacketNumber = 3978;

        public NpcRepurchaseItemPacket(ItemModel repurchasedItem, long currentBits)
        {
            Type(PacketNumber);
            WriteInt(1);//result
            WriteInt64(currentBits);
            WriteByte(0);//items amount
            //WriteBytes(repurchasedItem.ToArray());
        }
    }
}