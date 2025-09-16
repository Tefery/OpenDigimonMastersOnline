using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class DigimonEvolutionFailPacket : PacketWriter
    {
        private const int PacketNumber = 1029;

        /// <summary>
        /// Evolution failed for the current digimon.
        /// </summary>
        public DigimonEvolutionFailPacket()
        {
            Type(PacketNumber);
            WriteInt(0);
        }
    }
}