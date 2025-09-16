using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.Character;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.Chat;
using ODMO.Commons.Packets.MapServer;
using ODMO.GameHost;
using MediatR;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Text.RegularExpressions;

namespace ODMO.Game.PacketProcessors
{
    public class TamerSummonPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.TamerSummon;

        private readonly MapServer _mapServer;
        private readonly IConfiguration _configuration;
        private readonly ISender _sender;
        private readonly ILogger _logger;

        private const string GameServerAddress = "GameServer:Address";
        private const string GamerServerPublic = "GameServer:PublicAddress";
        private const string GameServerPort = "GameServer:Port";

        public TamerSummonPacketProcessor(
            MapServer mapServer,
            IConfiguration configuration,
            ISender sender,
            ILogger logger)
        {
            _configuration = configuration;
            _mapServer = mapServer;
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);
            var nCase = packet.ReadByte();
            _ = packet.ReadByte();
            _ = packet.ReadByte();
            var offerTamerName = packet.ReadString();
            // Define o padrão de expressão regular

            string pattern = @"summon\s+(\w+)";

            // Procura o padrão na string
            Match match = Regex.Match(offerTamerName, pattern);

            if (match.Success)
            {
                // Captura o nome após "summon"
                offerTamerName = match.Groups[1].Value;    
            }
          
            var targetClient = _mapServer.FindClientByTamerName(offerTamerName);

            if (targetClient != null)
            {
                var mapConfig = await _sender.Send(new GameMapConfigByMapIdQuery(targetClient.Tamer.Location.MapId));
                var waypoints = await _sender.Send(new MapRegionListAssetsByMapIdQuery(targetClient.Tamer.Location.MapId));

                if (mapConfig == null || waypoints == null || !waypoints.Regions.Any())
                {
                    client.Send(new SystemMessagePacket($"Map information not found for map Id {targetClient.Tamer.Location.MapId}."));
                    _logger.Warning($"Map information not found for map Id {targetClient.Tamer.Location.MapId} on character {client.TamerId} jump booster.");
                    return;
                }


                _logger.Verbose($"Character {client.TamerId}  summoned to map {targetClient.Tamer.Location.MapId} with GM Commands");


                _mapServer.RemoveClient(client);

                var destination = waypoints.Regions.First();

                client.Tamer.NewLocation(targetClient.Tamer.Location.MapId, targetClient.Tamer.Location.X, targetClient.Tamer.Location.Y);
                await _sender.Send(new UpdateCharacterLocationCommand(client.Tamer.Location));

                client.Tamer.Partner.NewLocation(targetClient.Tamer.Location.MapId, targetClient.Tamer.Location.X, targetClient.Tamer.Location.Y);
                await _sender.Send(new UpdateDigimonLocationCommand(client.Tamer.Partner.Location));

                client.Tamer.UpdateState(CharacterStateEnum.Loading);
                await _sender.Send(new UpdateCharacterStateCommand(client.TamerId, CharacterStateEnum.Loading));

                client.SetGameQuit(false);

                client.Send(new MapSwapPacket(
                    _configuration[GamerServerPublic],
                    _configuration[GameServerPort],
                    client.Tamer.Location.MapId,
                    client.Tamer.Location.X,
                    client.Tamer.Location.Y)
                    .Serialize());
            }
        }
    }
}