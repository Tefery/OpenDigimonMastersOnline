using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class GuildInviteFailPacket : PacketWriter
    {
        private const int PacketNumber = 2110;

        public GuildInviteFailPacket(GuildInviteFailEnum inviteFailEnum, string targetName)
        {
            Type(PacketNumber);
            WriteInt(inviteFailEnum.GetHashCode());
            WriteString(targetName);
        }
    }
}