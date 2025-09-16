using ODMO.Application;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Packets.Chat;
using ODMO.Commons.Packets.Items;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class HatchRemoveEggPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.HatchRemoveEgg;

        private readonly AssetsLoader _assets;
        private readonly ISender _sender;
        private readonly ILogger _logger;

        public HatchRemoveEggPacketProcessor(
            AssetsLoader assets,
            ISender sender,
            ILogger logger)
        {
            _assets = assets;
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            if (client.Tamer.Incubator.NotDevelopedEgg)
            {
                var newItem = new ItemModel();
                newItem.SetItemInfo(_assets.ItemInfo.FirstOrDefault(x => x.ItemId == client.Tamer.Incubator.EggId));
                newItem.SetItemId(client.Tamer.Incubator.EggId);
                newItem.SetAmount(1);

                var cloneItem = (ItemModel)newItem.Clone();

                if (client.Tamer.Inventory.AddItem(cloneItem))
                {
                    _logger.Verbose($"Character {client.TamerId} removed egg {client.Tamer.Incubator.EggId} from incubator to inventory.");
                    await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));
                }
                else
                {
                    _logger.Warning($"Inventory full for incubator recovery of item {client.Tamer.Incubator.EggId}.");
                    client.Send(new SystemMessagePacket($"Inventory full for incubator recovery of item {client.Tamer.Incubator.EggId}."));
                    return;
                }
            }
            else
                _logger.Verbose($"Character {client.TamerId} removed egg {client.Tamer.Incubator.EggId} from incubator.");

            client.Tamer.Incubator.RemoveEgg();

            await _sender.Send(new UpdateIncubatorCommand(client.Tamer.Incubator));
        }
    }
}