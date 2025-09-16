using ODMO.Commons.Enums.Party;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class PartyCreatedPacket : PacketWriter
    {
        private const int PacketNumber = 2319;

        public PartyCreatedPacket(int partyId, PartyLootShareTypeEnum lootType)
        {
            Type(PacketNumber);
            WriteInt(partyId);
            WriteInt((int)lootType);
        }
    }
}