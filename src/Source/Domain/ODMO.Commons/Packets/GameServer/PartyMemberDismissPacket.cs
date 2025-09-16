using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class PartyMemberDismissPacket : PacketWriter
    {
        private const int PacketNumber = 2317;

        public PartyMemberDismissPacket()
        {
            Type(PacketNumber);
        }
    }
}