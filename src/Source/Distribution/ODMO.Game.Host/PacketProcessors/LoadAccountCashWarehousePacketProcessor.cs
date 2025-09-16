using ODMO.Application;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.GameServer.Combat;
using ODMO.Commons.Packets.Items;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class LoadAccountCashWarehousePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.LoadAccountWarehouse;

        private readonly ILogger _logger;

        public LoadAccountCashWarehousePacketProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var accountWarehouse = client.Tamer.AccountCashWarehouse;

            client.Send(new LoadAccountWarehousePacket(accountWarehouse));
        }
    }
}