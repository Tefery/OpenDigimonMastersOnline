using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class UpdateCurrentHPRatePacket : PacketWriter
    {
        private const int PacketNumber = 1007;

        public UpdateCurrentHPRatePacket(int handler, byte currentHpRate)
        {
            Type(PacketNumber);
            WriteInt(handler);
            WriteByte(currentHpRate);
        }
    }
}