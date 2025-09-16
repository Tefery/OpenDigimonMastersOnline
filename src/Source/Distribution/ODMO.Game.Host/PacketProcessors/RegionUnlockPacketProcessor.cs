using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.Chat;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class RegionUnlockPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.UnlockRegion;

        private readonly ISender _sender;
        private readonly ILogger _logger;

        public RegionUnlockPacketProcessor(
            ISender sender,
            ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var regionIndex = packet.ReadByte();

            var characterRegion = client.Tamer.MapRegions[regionIndex];
            if (characterRegion != null)
            {
                if (characterRegion.Unlocked == 0)
                {
                    characterRegion.Unlock();
                    await _sender.Send(new UpdateCharacterMapRegionCommand(characterRegion));
                    _logger.Verbose($"Character {client.TamerId} unlocked region {regionIndex} at {client.TamerLocation}.");
                }
            }
            else
            {
                client.Send(new SystemMessagePacket($"Unknown region index {regionIndex}."));
                _logger.Warning($"Unknown region index {regionIndex} for character {client.TamerId} at {client.TamerLocation}.");
            }
        }
    }
}
