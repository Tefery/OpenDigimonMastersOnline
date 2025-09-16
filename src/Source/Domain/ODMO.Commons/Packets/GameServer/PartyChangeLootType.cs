using ODMO.Commons.Enums.Party;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class PartyChangeLootTypePacket : PacketWriter
    {
        private const int PacketNumber = 2309;

       
        public PartyChangeLootTypePacket(PartyLootShareTypeEnum lootType, PartyLootShareRarityEnum rareType)
        {
            Type(PacketNumber);
            WriteInt((int)lootType);
            WriteByte((byte)rareType);
            WriteByte(1);          
        }
    }
}
