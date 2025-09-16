using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class GuildMemberDisconnectPacket : PacketWriter
    {
        private const int PacketNumber = 2112;

        /// <summary>
        /// Send a notification upon guild member disconnect from the game.
        /// </summary>
        /// <param name="name">Disconected member name</param>
        public GuildMemberDisconnectPacket(string name)
        {
            Type(PacketNumber);
            WriteString(name);
        }
    }
}