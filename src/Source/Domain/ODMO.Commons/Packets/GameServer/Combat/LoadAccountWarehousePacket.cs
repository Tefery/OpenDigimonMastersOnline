using ODMO.Commons.Models.Base;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer.Combat
{
    public class LoadAccountWarehousePacket : PacketWriter
    {
        private const int PacketNumber = 3930;

        /// </summary>
        /// <param name="accountWarehouse">The list of Cash Storage</param>
        public LoadAccountWarehousePacket(ItemListModel accountWarehouse)
        {
            Type(PacketNumber);
            WriteShort(accountWarehouse.Count);
            WriteBytes(accountWarehouse.ToArray());
        }
    }
}