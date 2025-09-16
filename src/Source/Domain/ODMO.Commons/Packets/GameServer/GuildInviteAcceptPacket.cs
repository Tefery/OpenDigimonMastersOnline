using ODMO.Commons.Enums;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class GuildInviteAcceptPacket : PacketWriter
    {
        private const int PacketNumber = 2108;

        /// <summary>
        /// Accepts an invite to join a guild.
        /// </summary>
        /// <param name="character">New member information</param>
        public GuildInviteAcceptPacket(CharacterModel character)
        {
            Type(PacketNumber);
            WriteByte((byte)GuildAuthorityTypeEnum.NewMember);
            WriteByte((byte)(character.Model - 80000));
            WriteString(character.Name);
            WriteByte(character.Level);
            WriteShort(character.Location.MapId);
            WriteByte(character.Channel);
            WriteString(character.Guild.Name);
        }
    }
}