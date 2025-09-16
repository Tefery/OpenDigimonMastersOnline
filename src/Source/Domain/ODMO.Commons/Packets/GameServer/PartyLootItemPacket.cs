using ODMO.Commons.Models.Base;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class PartyLootItemPacket : PacketWriter
    {
        private const int PacketNumber = 3939;

      
        public PartyLootItemPacket(CharacterModel tamer,ItemModel item, byte diceCount = 0, string diceName = "")
        {
            Type(PacketNumber);
            WriteInt(tamer.GeneralHandler);
            WriteInt(item.ItemId);
            WriteShort((short)item.Amount);
            WriteByte(100);
            WriteString(tamer.Name);

            if(diceCount > 0)
            {
                WriteByte(diceCount);
                WriteString(diceName);
            }
        }
    }
}
