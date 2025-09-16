using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Utils;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.Items
{
    public class ReceiveGiftRewardItemFailPacket : PacketWriter
    {
        private const int PacketNumber = 3944;

        public ReceiveGiftRewardItemFailPacket(ReceiveGiftRewardItemFailReasonEnum failReason)
        {
            Type(PacketNumber);
            WriteInt(failReason.GetHashCode());
        }
    }
}