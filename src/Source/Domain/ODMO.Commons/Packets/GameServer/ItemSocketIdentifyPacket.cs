using ODMO.Commons.Enums.Character;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class ItemSocketIdentifyPacket : PacketWriter
    {
        private const int PacketNumber = 3929;

        public ItemSocketIdentifyPacket(ItemModel item, int Money)
        {
            Type(PacketNumber);
            WriteByte(item.Power);
            WriteInt(Money);
            WriteInt(0);

        }
    }
}
