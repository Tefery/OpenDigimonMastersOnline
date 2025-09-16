using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.Items;
using ODMO.Commons.Utils;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class InventorySortPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.InventorySort;

        private readonly ISender _sender;
        private readonly ILogger _logger;

        public InventorySortPacketProcessor(
            ISender sender,
            ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);
            var inventoryType = (InventoryTypeEnum)packet.ReadByte();

            switch (inventoryType)
            {
                case InventoryTypeEnum.Inventory:
                    {
                        client.Tamer.Inventory.Sort();

                        await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));

                        client.Send(
                            UtilitiesFunctions.GroupPackets(
                                new InventorySortPacket(client.Tamer.Inventory, inventoryType).Serialize(),
                                new LoadInventoryPacket(client.Tamer.Inventory, inventoryType).Serialize()
                            ));
                    }
                    break;

                case InventoryTypeEnum.Warehouse:
                    {
                        client.Tamer.Warehouse.Sort();

                        await _sender.Send(new UpdateItemsCommand(client.Tamer.Warehouse));

                        client.Send(
                            UtilitiesFunctions.GroupPackets(
                                new InventorySortPacket(client.Tamer.Warehouse, inventoryType).Serialize(),
                                new LoadInventoryPacket(client.Tamer.Warehouse, inventoryType).Serialize()
                            ));
                    }
                    break;

                case InventoryTypeEnum.AccountWarehouse:
                    {
                        client.Tamer.AccountWarehouse.Sort();

                        await _sender.Send(new UpdateItemsCommand(client.Tamer.AccountWarehouse));

                        client.Send(
                            UtilitiesFunctions.GroupPackets(
                                new InventorySortPacket(client.Tamer.AccountWarehouse, inventoryType).Serialize(),
                                new LoadInventoryPacket(client.Tamer.AccountWarehouse, inventoryType).Serialize()
                            ));
                    }
                    break;
            }

            _logger.Verbose($"Character {client.TamerId} sorted {inventoryType}.");
        }
    }
}