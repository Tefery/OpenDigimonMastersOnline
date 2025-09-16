using ODMO.Commons.Models.Asset;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.Items
{
    public class EvolutionArmorUnlockedPacket : PacketWriter
    {
        private const int PacketNumber = 3238;

        public EvolutionArmorUnlockedPacket(short result,byte success)
        {
            Type(PacketNumber);
            WriteShort(result);
            WriteByte(success);
        }
    }
}