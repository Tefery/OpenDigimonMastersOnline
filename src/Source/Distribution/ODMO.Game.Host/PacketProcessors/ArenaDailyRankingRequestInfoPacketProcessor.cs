using AutoMapper;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Utils;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class ArenaDailyRankingRequestInfoPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ArenaDailyRankingLoad;

        private readonly ILogger _logger;
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public ArenaDailyRankingRequestInfoPacketProcessor(
            ILogger logger,
            ISender sender,
            IMapper mapper)
        {
            _logger = logger;
            _sender = sender;
            _mapper = mapper;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var rankingInfo = _mapper.Map<ArenaRankingModel>(await _sender.Send(new GetArenaRankingQuery(ArenaRankingEnum.Weekly)));
            
            if (rankingInfo == null)
            {
                client.Send(new ArenaRankingDailyLoadPacket(0, 0));
                return;
            }

            var ranking = rankingInfo.Competitors.FirstOrDefault(x => x.TamerId == client.TamerId);
            
            if (ranking != null)
            {

                client.Send(new ArenaRankingDailyLoadPacket(UtilitiesFunctions.CurrentRemainingTimeToResetDay(), client.Tamer.DailyPoints.Points));

            }
            else
            {
                client.Send(new ArenaRankingDailyLoadPacket(UtilitiesFunctions.CurrentRemainingTimeToResetDay(), 0));
            }
        }
    }
}
