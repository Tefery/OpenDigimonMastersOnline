using ODMO.Commons.Enums.Character;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.CharacterServer
{
    public class CharacterDeletedPacket : PacketWriter
    {
        private const int PacketNumber = 1304;

        public CharacterDeletedPacket(DeleteCharacterResultEnum result)
        {
            Type(PacketNumber);
            WriteInt(result.GetHashCode());
        }
    }
}
