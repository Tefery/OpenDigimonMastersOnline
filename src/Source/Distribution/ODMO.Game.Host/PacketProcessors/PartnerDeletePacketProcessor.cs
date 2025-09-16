using ODMO.Application.Separar.Commands.Delete;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class PartnerDeletePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.PartnerDelete;

        private readonly ILogger _logger;
        private readonly ISender _sender;

        public PartnerDeletePacketProcessor(ILogger logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var slot = packet.ReadByte();
            var validation = packet.ReadString();

            var digimonId = client.Tamer.Digimons.First(x => x.Slot == slot).Id;

            var result = client.PartnerDeleteValidation(validation);

            if (result > 0)
            {
                client.Tamer.RemoveDigimon(slot);

                client.Send(new PartnerDeletePacket(slot));

                await _sender.Send(new DeleteDigimonCommand(digimonId));

                _logger.Verbose($"Character {client.TamerId} deleted partner {digimonId}.");
            }
            else
            {
                client.Send(new PartnerDeletePacket(result));
                _logger.Verbose($"Character {client.TamerId} failed to deleted partner {digimonId} with invalid account information.");
            }
        }
    }
}