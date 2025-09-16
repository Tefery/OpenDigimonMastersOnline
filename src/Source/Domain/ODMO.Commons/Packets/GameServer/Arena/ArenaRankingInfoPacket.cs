using ODMO.Commons.Enums;
using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Utils;
using ODMO.Commons.Writers;
using System.Net.Sockets;

namespace ODMO.Commons.Packets.GameServer
{
    public class ArenaRankingInfoPacket : PacketWriter
    {
        private const int PacketNumber = 16023;

        public ArenaRankingInfoPacket(int tamerId, ArenaRankingModel arena, ArenaRankingEnum ranking, ArenaRankingStatusEnum status, ArenaRankingPositionTypeEnum position)
        {
            Type(PacketNumber);
            WriteByte((byte)ranking);
            WriteByte(0);
            WriteByte((byte)status);

            var tamerCompetitor = arena.GetRank(tamerId);

            if (tamerCompetitor != null)
            {
                WriteInt(tamerCompetitor.Points);
                WriteInt(arena.Competitors.Count - tamerCompetitor.Position);
                WriteInt(tamerCompetitor.Position);
                WriteByte((byte)position);
                WriteByte(0);
            }
            else
            {
                WriteBytes(new byte[14]);
            }

            WriteInt((int)UtilitiesFunctions.CurrentRemainingTimeToResetHour());
            WriteInt((int)arena.RemainingMinutes());

            arena.GetTop100();

            WriteByte((byte)arena.Competitors.Count);
            foreach (var competitor in arena.Competitors.OrderBy( x=> x.Position))
            {
                WriteByte((byte)(competitor.Position));
                WriteString(competitor.TamerName);

                if (String.IsNullOrEmpty(competitor.GuildName))
                {
                    WriteString("-----");
                }
                else
                {
                    WriteString(competitor.GuildName);
                }

                WriteInt(competitor.Points);
                WriteByte((byte)Convert.ToByte(competitor.New));
                WriteByte(0);
            }

        }
    }
}