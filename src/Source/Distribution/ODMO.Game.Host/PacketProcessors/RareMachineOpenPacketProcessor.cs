using ODMO.Application;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class RareMachineOpenPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.RareMachineOpen;

        private readonly AssetsLoader _assets;
        private readonly ILogger _logger;

        public RareMachineOpenPacketProcessor(AssetsLoader assets, ILogger logger)
        {
            _assets = assets;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var NpcId = packet.ReadInt();

            //_logger.Information($"Gotcha Npc: {NpcId}");

            var Gotcha = _assets.Gotcha.FirstOrDefault(x => x.NpcId == NpcId);

            client.Send(new GotchaStartPacket(Gotcha));
        }
    }
}
