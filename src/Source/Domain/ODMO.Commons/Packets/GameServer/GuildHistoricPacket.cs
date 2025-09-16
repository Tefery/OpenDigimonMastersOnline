using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Utils;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class GuildHistoricPacket : PacketWriter
    {
        private const int PacketNumber = 2128;

        /// <summary>
        /// Sends the complete guild historic information.
        /// </summary>
        /// <param name="historicList">Guild historic list</param>
        public GuildHistoricPacket(List<GuildHistoricModel> historicList)
        {
            Type(PacketNumber);
            foreach (var historic in historicList)
            {
                WriteByte((byte)historic.Type);

                WriteInt(UtilitiesFunctions.GetUtcSeconds(historic.Date));
                WriteByte((byte)historic.MasterClass);
                WriteString(historic.MasterName);
                WriteByte((byte)historic.MemberClass);
                WriteString(historic.MemberName);
            }

            WriteByte(0);
        }
    }
}