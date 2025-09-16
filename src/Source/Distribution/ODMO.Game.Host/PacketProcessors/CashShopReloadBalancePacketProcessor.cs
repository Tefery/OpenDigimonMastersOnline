using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using MediatR;
using Serilog;
using ODMO.Application;

namespace ODMO.Game.PacketProcessors
{
    public class CashShopReloadBalancePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.CashShopReloadBalance;

        private readonly ILogger _logger;
        private readonly ISender _sender;
        private readonly AssetsLoader _assets;

        public CashShopReloadBalancePacketProcessor(
            ILogger logger,
            AssetsLoader assets,
            ISender sender)
        {
            _logger = logger;
            _assets = assets;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);
            
            _logger.Debug($"Sending account cash coins packet for character {client.TamerId}...");
            
            client.Send(new CashShopCoinsPacket(client.Premium, client.Silk));
        }
    }
}

