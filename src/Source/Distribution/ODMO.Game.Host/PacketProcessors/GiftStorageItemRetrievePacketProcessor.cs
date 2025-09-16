using ODMO.Application;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.GameServer.Combat;
using ODMO.Commons.Packets.Items;
using ODMO.Commons.Utils;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class GiftStorageItemRetrievePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.GiftStorageItemRetrieve;

        private readonly ILogger _logger;
        private readonly ISender _sender;

        public GiftStorageItemRetrievePacketProcessor(ILogger logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;

        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var withdrawType = packet.ReadShort();
            var itemSlot = packet.ReadShort();

            if (withdrawType == 1)
            {
                var targetItem = client.Tamer.GiftWarehouse.GiftFindItemBySlot(itemSlot);

                if (targetItem != null)
                {
                    var newItem = new ItemModel();

                    newItem.SetItemId(targetItem.ItemId);
                    newItem.SetAmount(targetItem.Amount);
                    newItem.SetItemInfo(targetItem.ItemInfo);

                    if (newItem.IsTemporary)
                        newItem.SetRemainingTime((uint)newItem.ItemInfo.UsageTimeMinutes);

                    if (client.Tamer.Inventory.AddItem(newItem))
                    {
                        client.Tamer.GiftWarehouse.RemoveItem(targetItem, (short)itemSlot);
                        client.Tamer.GiftWarehouse.UpdateGiftSlot();

                        client.Send(new LoadGiftStoragePacket(client.Tamer.GiftWarehouse));
                        client.Send(new LoadInventoryPacket(client.Tamer.Inventory, InventoryTypeEnum.Inventory));

                        await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));
                        await _sender.Send(new UpdateItemsCommand(client.Tamer.GiftWarehouse));
                    }
                    else
                    {
                        _logger.Warning($"Failed to add item !! Tamer {client.Tamer.Name} dont have free slots");
                    }
                    
                }

            }
            else
            {
                var Items = client.Tamer.GiftWarehouse.Items.Where(x => x.ItemId > 0).ToList();

                foreach (var targetItem in Items)
                {

                    if (targetItem != null)
                    {
                        var newItem = new ItemModel();

                        newItem.SetItemId(targetItem.ItemId);
                        newItem.SetAmount(targetItem.Amount);
                        newItem.SetItemInfo(targetItem.ItemInfo);

                        if (newItem.IsTemporary)
                            newItem.SetRemainingTime((uint)newItem.ItemInfo.UsageTimeMinutes);

                        client.Tamer.Inventory.AddItem(newItem);
                        client.Tamer.GiftWarehouse.RemoveItem(targetItem, (short)targetItem.Slot);


                    }
                }

                client.Send(new LoadGiftStoragePacket(client.Tamer.GiftWarehouse));
                client.Send(new LoadInventoryPacket(client.Tamer.Inventory, InventoryTypeEnum.Inventory));

                await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));
                await _sender.Send(new UpdateItemsCommand(client.Tamer.GiftWarehouse));
            }

        }
    }
}