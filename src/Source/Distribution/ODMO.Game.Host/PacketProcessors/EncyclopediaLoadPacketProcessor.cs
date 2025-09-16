using ODMO.Commons.Entities;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.Items;
using ODMO.Commons.Writers;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class EncyclopediaLoadPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.EncyclopediaLoad;

        private readonly ISender _sender;
        private readonly ILogger _logger;

        public EncyclopediaLoadPacketProcessor(ISender sender,ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var encyclopedia = client.Tamer.Encyclopedia;

            _logger.Debug($"Getting encyclopedia data");

            _logger.Debug($"Encyclopedia's count: {encyclopedia.Count}");

            client.Send(new EncyclopediaLoadPacket(encyclopedia));
        }
    }
}