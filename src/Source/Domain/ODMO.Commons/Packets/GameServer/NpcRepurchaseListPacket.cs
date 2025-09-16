using ODMO.Commons.Models.Base;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class NpcRepurchaseListPacket : PacketWriter
    {
        private const int PacketNumber = 3979;

        /// <summary>
        /// Loads the sold items available to repurchase.
        /// </summary>
        public NpcRepurchaseListPacket(List<ItemModel> repurchaseList)
        {
            Type(PacketNumber);
            WriteInt(repurchaseList.Count);
            foreach (var repurchaseItem in repurchaseList)
            {
                WriteBytes(repurchaseItem.ToArray());
            }
        }
    }
}