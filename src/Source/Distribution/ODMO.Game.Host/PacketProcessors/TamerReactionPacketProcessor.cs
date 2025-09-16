using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class TamerReactionPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.TamerReaction;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonsServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public TamerReactionPacketProcessor(MapServer mapServer, DungeonsServer dungeonsServer, EventServer eventServer,
            PvpServer pvpServer, ILogger logger, ISender sender)
        {
            _mapServer = mapServer;
            _dungeonsServer = dungeonsServer;
            _eventServer = eventServer;
            _pvpServer = pvpServer;
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var type = packet.ReadInt(); //TODO: enum?
            var value = packet.ReadInt(); //TODO: enum?
            var mapConfig = await _sender.Send(new GameMapConfigByMapIdQuery(client.Tamer.Location.MapId));
            switch (mapConfig?.Type)
            {
                case MapTypeEnum.Dungeon:
                    _dungeonsServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                        new TamerReactionPacket(client.Tamer.GeneralHandler, type, value).Serialize());
                    break;

                case MapTypeEnum.Event:
                    _eventServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                        new TamerReactionPacket(client.Tamer.GeneralHandler, type, value).Serialize());
                    break;

                case MapTypeEnum.Pvp:
                    _pvpServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                        new TamerReactionPacket(client.Tamer.GeneralHandler, type, value).Serialize());
                    break;

                default:
                    _mapServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                        new TamerReactionPacket(client.Tamer.GeneralHandler, type, value).Serialize());
                    break;
            }
        }
    }
}