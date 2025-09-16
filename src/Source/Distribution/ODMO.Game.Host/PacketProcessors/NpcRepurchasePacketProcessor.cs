using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.Items;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class NpcRepurchasePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.RepurchaseItem;

        private readonly ISender _sender;
        private readonly ILogger _logger;

        public NpcRepurchasePacketProcessor(
            ISender sender,
            ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);
            var npcId = packet.ReadInt();
            var itemIndex = packet.ReadShort();

            var targetItem = client.Tamer.RepurchaseList[itemIndex];

            var price = targetItem.ItemInfo!.SellPrice * targetItem.Amount;
            client.Tamer.Inventory.RemoveBits(price);

            client.Send(new NpcRepurchaseItemPacket(targetItem, client.Tamer.Inventory.Bits));

            _logger.Verbose($"Character {client.TamerId} repurchased {targetItem.ItemId} x{targetItem.Amount} from NPC {npcId} for {price} bits.");

            client.Tamer.Inventory.AddItem(targetItem);
            client.Tamer.RepurchaseList.RemoveAt(itemIndex);

            client.Send(new LoadInventoryPacket(client.Tamer.Inventory, InventoryTypeEnum.Inventory));

            await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));
            await _sender.Send(new UpdateItemListBitsCommand(client.Tamer.Inventory));
        }
    }
}