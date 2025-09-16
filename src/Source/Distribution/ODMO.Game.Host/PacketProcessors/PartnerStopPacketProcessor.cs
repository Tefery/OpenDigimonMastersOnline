using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer.Combat;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class PartnerStopPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.PartnerStop;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public PartnerStopPacketProcessor(MapServer mapServer, DungeonsServer dungeonsServer, EventServer eventServer, PvpServer pvpServer, ILogger logger, ISender sender)
        {
            _mapServer = mapServer;
            _dungeonServer = dungeonsServer;
            _eventServer = eventServer;
            _pvpServer = pvpServer;
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            client.Tamer.Partner.StopAutoAttack();

            var mapConfig = await _sender.Send(new GameMapConfigByMapIdQuery(client.Tamer.Location.MapId));

            switch (mapConfig!.Type)
            {
                case MapTypeEnum.Dungeon:
                    _dungeonServer.BroadcastForTamerViewsAndSelf(client.TamerId, new PartnerStopPacket(client.Tamer.Partner.GeneralHandler).Serialize());
                    break;
                case MapTypeEnum.Event:
                    _eventServer.BroadcastForTamerViewsAndSelf(client.TamerId, new PartnerStopPacket(client.Tamer.Partner.GeneralHandler).Serialize());
                    break;
                case MapTypeEnum.Pvp:
                    _pvpServer.BroadcastForTamerViewsAndSelf(client.TamerId, new PartnerStopPacket(client.Tamer.Partner.GeneralHandler).Serialize());
                    break;
                default:
                    _mapServer.BroadcastForTamerViewsAndSelf(client.TamerId, new PartnerStopPacket(client.Tamer.Partner.GeneralHandler).Serialize());
                    break;
            }

        }
    }
}