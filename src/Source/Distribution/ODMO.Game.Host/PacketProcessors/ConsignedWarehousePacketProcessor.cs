using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.PersonalShop;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class ConsignedWarehousePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ConsignedWarehouse;

        private readonly ILogger _logger;

        public ConsignedWarehousePacketProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public Task Process(GameClient client, byte[] packetData)
        {
            _logger.Debug($"Sending consigned warehouse packet...");
            client.Send(new LoadConsignedShopWarehousePacket(client.Tamer.ConsignedWarehouse));

            return Task.CompletedTask;
        }
    }
}