﻿using DigitalWorldOnline.Application.Separar.Queries;
using DigitalWorldOnline.Commons.Entities;
using DigitalWorldOnline.Commons.Enums;
using DigitalWorldOnline.Commons.Enums.Character;
using DigitalWorldOnline.Commons.Enums.ClientEnums;
using DigitalWorldOnline.Commons.Enums.PacketProcessor;
using DigitalWorldOnline.Commons.Interfaces;
using DigitalWorldOnline.Commons.Packets.GameServer;
using DigitalWorldOnline.GameHost;
using DigitalWorldOnline.GameHost.EventsServer;
using MediatR;
using Serilog;

namespace DigitalWorldOnline.Game.PacketProcessors
{
    public class TradePacketRequestSendProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.TradeRequestSend;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public TradePacketRequestSendProcessor(MapServer mapServer, DungeonsServer dungeonsServer, EventServer eventServer, PvpServer pvpServer, ILogger logger, ISender sender)
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
                // Verificar se o cliente solicitante está em condições de fazer troca
                if (client.Tamer.TradeCondition)
                {
                    client.Send(new TradeRequestErrorPacket(TradeRequestErrorEnum.othertransact));
                    _logger.Warning($"[TRADE] {client.Tamer.Name} attempted to send trade request while already in trade");
                    return;
                }

                if (targetClient.Loading || targetClient.Tamer.State != CharacterStateEnum.Ready ||
                    targetClient.Tamer.CurrentCondition == ConditionEnum.Away || targetClient.Tamer.TradeCondition)
                {
                    client.Send(new TradeRequestErrorPacket(TradeRequestErrorEnum.othertransact));
                    _logger.Debug($"[TRADE] Trade request from {client.Tamer.Name} to {targetClient.Tamer.Name} rejected - target not available");
                }
                else
                {
                    targetClient.Send(new TradeRequestSucessPacket(client.Tamer.GeneralHandler));
                    _logger.Information($"[TRADE] Trade request sent from {client.Tamer.Name} to {targetClient.Tamer.Name}");
                }
            }
            else
            {
                // Corrigido: enviar erro para o cliente solicitante, não para o targetClient que é null
                client.Send(new TradeRequestErrorPacket(TradeRequestErrorEnum.othertransact));
                _logger.Warning($"[TRADE] {client.Tamer.Name} attempted to send trade request to non-existent target (Handle: {TargetHandle})");
            }
        }
    }
}
