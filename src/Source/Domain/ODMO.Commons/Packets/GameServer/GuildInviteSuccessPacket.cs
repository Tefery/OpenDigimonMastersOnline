using ODMO.Commons.Models.Character;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class GuildInviteSuccessPacket : PacketWriter
    {
        private const int PacketNumber = 2109;

        public GuildInviteSuccessPacket(CharacterModel character)
        {
            Type(PacketNumber);
            WriteString(character.Name);
            WriteUInt((uint)character.Guild.Id);
            WriteString(character.Guild.Name);
        }
    }
}