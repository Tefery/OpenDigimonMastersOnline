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
    public class TamerChargeXCrystalPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.TamerChargeXCrystal;

        private readonly MapServer _mapServer;
        private readonly ISender _sender;
        private readonly ILogger _logger;

        public TamerChargeXCrystalPacketProcessor(
            MapServer mapServer,
            ISender sender,
            ILogger logger)
        {
            _mapServer = mapServer;
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            if (client.Tamer.XGauge >= 500)
            {
                client.Tamer.ConsumeXg(500);
                client.Tamer.SetXCrystals(1);
            }
            else
            {
                _logger.Verbose($"You don't have enought Gauge to store !!");
            }

            /*if (client.Tamer.ConsumeXg(500))
                client.Tamer.SetXCrystals(1);
            else
                _logger.Information($"You don't have enought Gauge to store !!");*/

            client.Send(new TamerXaiResourcesPacket(client.Tamer.XGauge, client.Tamer.XCrystals));
        }
    }
}