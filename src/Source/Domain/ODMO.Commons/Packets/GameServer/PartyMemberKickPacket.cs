using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class PartyMemberKickPacket : PacketWriter
    {
        private const int PacketNumber = 2306;

        public PartyMemberKickPacket(byte partySlot)
        {
            Type(PacketNumber);
            WriteByte(partySlot);
        }
    }
}