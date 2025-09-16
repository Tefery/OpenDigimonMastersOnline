
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class ItemSocketOutPacket : PacketWriter
    {
        private const int PacketNumber = 3927;

        public ItemSocketOutPacket(int Money)
        {
            Type(PacketNumber);
            WriteInt(100);
            WriteInt(Money);
            WriteInt(0);

        }
    }
}
