using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer
{
    public class PartyRequestSentFailedPacket : PacketWriter
    {
        private const int PacketNumber = 2302;

        /// <summary>
        /// Unable to send party request.
        /// </summary>
        /// <param name="result">Fail result enumeration</param>
        /// <param name="targetName">Target tamer name</param>
        public PartyRequestSentFailedPacket(PartyRequestFailedResultEnum result, string targetName)
        {
            Type(PacketNumber);
            WriteInt(result.GetHashCode());
            WriteString(targetName);
        }
    }
}