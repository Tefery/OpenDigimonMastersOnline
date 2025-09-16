using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class UtilMensagePacket : PacketWriter
    {
        private const int PacketNumber = 4125;

        public UtilMensagePacket(ItemStoneEnum type)
        {
           Type(PacketNumber);
           WriteInt((int)type);
        }
    }
}
