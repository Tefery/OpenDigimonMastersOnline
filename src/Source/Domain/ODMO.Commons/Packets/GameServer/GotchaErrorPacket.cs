using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class GotchaErrorPacket : PacketWriter
    {
        private const int PacketNumber = 3959;

        /// <summary>
        /// Gotcha Error Packet
        /// </summary>
        public GotchaErrorPacket()
        {
            Type(PacketNumber);
            WriteUInt(1);
        }
    }
}