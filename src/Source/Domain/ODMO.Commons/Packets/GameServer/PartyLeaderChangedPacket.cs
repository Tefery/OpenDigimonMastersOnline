using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class PartyLeaderChangedPacket : PacketWriter
    {
        private const int PacketNumber = 2308;

        public PartyLeaderChangedPacket(int newLeaderSlot)
        {
            Type(PacketNumber);
            WriteInt(newLeaderSlot);
        }
    }
}