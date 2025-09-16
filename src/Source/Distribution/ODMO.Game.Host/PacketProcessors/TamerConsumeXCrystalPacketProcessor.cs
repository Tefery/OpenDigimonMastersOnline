using ODMO.Application;
using ODMO.Application.Separar.Commands.Create;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.Character;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Extensions;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Config;
using ODMO.Commons.Models.Digimon;
using ODMO.Commons.Models.Summon;
using ODMO.Commons.Packets.Chat;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.Items;
using ODMO.Commons.Packets.MapServer;
using ODMO.Commons.Utils;
using ODMO.Game.Managers;
using ODMO.GameHost;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Diagnostics.Eventing.Reader;

namespace ODMO.Game.PacketProcessors
{
    public class TamerConsumeXCrystalPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.TamerConsumeXCrystal;

        private readonly MapServer _mapServer;
        private readonly ISender _sender;
        private readonly ILogger _logger;

        public TamerConsumeXCrystalPacketProcessor(MapServer mapServer, ISender sender, ILogger logger)
        {
            _mapServer = mapServer;
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            _logger.Debug($"XCrystal Consume Packet\n");

            _logger.Debug($"Tamer Gauge: {client.Tamer.XGauge} | Tamer XCrystal: {client.Tamer.XCrystals}");

            if ((client.Tamer.XGauge + 500) > client.Tamer.Xai.XGauge)
            {
                _logger.Debug($"Gauge on limit, Sending Packet 16033");
                client.Send(new XaiInfoPacket(client.Tamer.Xai));   // Send Packet 16033
            }
            else
            {
                client.Tamer.ConsumeXCrystal(1);
                client.Tamer.SetXGauge(500);
            }

            _logger.Debug($"Tamer Gauge: {client.Tamer.XGauge} | Tamer XCrystal: {client.Tamer.XCrystals}");
            client.Send(new TamerXaiResourcesPacket(client.Tamer.XGauge, client.Tamer.XCrystals));   // Send Packet 16032
        }

    }
}