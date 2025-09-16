using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.Character;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class TradeAcceptPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.TradeRequestAccept;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public TradeAcceptPacketProcessor(MapServer mapServer, DungeonsServer dungeonsServer, EventServer eventServer, PvpServer pvpServer, ILogger logger, ISender sender)
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
            var packet = new GamePacketReader(packetData);

            var TargetHandle = packet.ReadInt();

            GameClient? targetClient;

            var mapConfig = await _sender.Send(new GameMapConfigByMapIdQuery(client.Tamer.Location.MapId));

            switch (mapConfig!.Type)
            {
                case MapTypeEnum.Dungeon:
                    targetClient = _dungeonServer.FindClientByTamerHandleAndChannel(TargetHandle, client.TamerId);
                    break;

                case MapTypeEnum.Event:
                    targetClient = _eventServer.FindClientByTamerHandleAndChannel(TargetHandle, client.TamerId);
                    break;

                case MapTypeEnum.Pvp:
                    targetClient = _pvpServer.FindClientByTamerHandleAndChannel(TargetHandle, client.TamerId);
                    break;

                default:
                    targetClient = _mapServer.FindClientByTamerHandleAndChannel(TargetHandle, client.TamerId);
                    break;
            }

            if (targetClient != null)
            {
                if (targetClient.Loading || targetClient.Tamer.State != CharacterStateEnum.Ready || targetClient.Tamer.CurrentCondition == ConditionEnum.Away || targetClient.Tamer.TradeCondition)
                {
                    client.Send(new TradeRequestErrorPacket(TradeRequestErrorEnum.othertransact));
                    _logger.Warning($"Character {client.Tamer.Name}({client.TamerId}) sent trade request to {targetClient.Tamer.Name} ({targetClient.TamerId})  and the tamer was already in another transaction.");
                }
                else
                {
                    targetClient.Tamer.SetTrade(true, client.Tamer.GeneralHandler);

                    client.Tamer.SetTrade(true, targetClient.Tamer.GeneralHandler);
                    targetClient.Send(new TradeAcceptPacket(client.Tamer.GeneralHandler));
                    client.Send(new TradeAcceptPacket(TargetHandle));
                    _logger.Warning($"Character {client.Tamer.Name}({client.TamerId}) sent trade request to {targetClient.Tamer.Name} ({targetClient.TamerId})  and the tamer accept trade. » {TargetHandle}");
                }
            }

        }
    }
}
