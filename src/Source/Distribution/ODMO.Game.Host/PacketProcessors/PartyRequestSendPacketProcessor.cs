using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.Character;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Game.Managers;
using ODMO.GameHost;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class PartyRequestSendPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.PartyRequestSend;

        private readonly PartyManager _partyManager;
        private readonly MapServer _mapServer;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public PartyRequestSendPacketProcessor(
            PartyManager partyManager,
            MapServer mapServer,
            ILogger logger,
            ISender sender)
        {
            _partyManager = partyManager;
            _mapServer = mapServer;
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);
            var receiverName = packet.ReadString();

            var targetCharacter = await _sender.Send(new CharacterByNameQuery(receiverName));
            if (targetCharacter == null)
            {
                client.Send(new PartyRequestSentFailedPacket(PartyRequestFailedResultEnum.Disconnected, receiverName));
                _logger.Verbose($"Character {client.TamerId} sent party request to {receiverName} which does not exist.");
            }
            else
            {
                var targetClient = _mapServer.FindClientByTamerId(targetCharacter.Id);
                if (targetClient != null)
                {
                    if (targetClient.Loading || targetClient.Tamer.State != CharacterStateEnum.Ready|| targetClient.DungeonMap)
                    {
                        client.Send(new PartyRequestSentFailedPacket(PartyRequestFailedResultEnum.CantAccept, receiverName));
                        _logger.Verbose($"Character {client.TamerId} sent party request to {targetCharacter.Id} which could not accept.");
                    }                 
                    else
                    {
                        var party = _partyManager.FindParty(targetClient.TamerId);
                        if (party != null)
                        {
                            client.Send(new PartyRequestSentFailedPacket(PartyRequestFailedResultEnum.AlreadyInparty, receiverName));
                            _logger.Verbose($"Character {client.TamerId} sent party request to {targetCharacter.Id} which was already in the party.");
                        }
                        else
                        {
                            targetClient.Send(new PartyRequestSentSuccessPacket(client.Tamer.Name));
                            _logger.Verbose($"Character {client.TamerId} sent party request to {targetCharacter.Id}.");
                        }
                    }
                }
                else
                {
                    client.Send(new PartyRequestSentFailedPacket(PartyRequestFailedResultEnum.Disconnected, receiverName));
                    _logger.Verbose($"Character {client.TamerId} sent party request to {targetCharacter.Id} which was disconnected.");
                }
            }
        }
    }
}