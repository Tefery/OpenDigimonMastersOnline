using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class PartyMemberDisconnectedPacket : PacketWriter
    {
        private const int PacketNumber = 2312;

        public PartyMemberDisconnectedPacket(byte memberSlot)
        {
            Type(PacketNumber);
            WriteInt(memberSlot);
        }
    }
}