using ODMO.Application;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.Chat;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Utils;
using ODMO.GameHost;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class PartnerDigicloneResetPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.PartnerDigicloneReset;

        private readonly ISender _sender;
        private readonly ILogger _logger;

        public PartnerDigicloneResetPacketProcessor(
            ISender sender,
            ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var cloneType = (DigicloneTypeEnum)packet.ReadInt();
            var capsuleSlot = packet.ReadInt();

            var capsuleItem = client.Tamer.Inventory.FindItemBySlot(capsuleSlot);
            if (capsuleItem == null)
            {
                _logger.Warning($"Invalid capsule item at slot {capsuleSlot} for tamer {client.TamerId}.");
                client.Send(new SystemMessagePacket($"Invalid capsule item at slot {capsuleSlot}."));
                return;
            }

            if(capsuleItem.ItemInfo.Section == 5701)
            {
                client.Partner.Digiclone.ResetOne(cloneType);
            }
            else
            {
                client.Partner.Digiclone.ResetAll(cloneType);
            }

            var currentCloneLevel = client.Partner.Digiclone.GetCurrentLevel(cloneType);
            _logger.Verbose($"Character {client.TamerId} redefined {client.Partner.Id} clone level to " +
                $"{currentCloneLevel} with {capsuleItem.ItemId}.");

            client.Send(new DigicloneResetPacket(client.Partner.Digiclone));
            client.Send(new UpdateStatusPacket(client.Tamer));

            client.Tamer.Inventory.RemoveOrReduceItem(capsuleItem, 1, capsuleSlot);

            await _sender.Send(new UpdateDigicloneCommand(client.Partner.Digiclone));
            await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));
        }
    }
}