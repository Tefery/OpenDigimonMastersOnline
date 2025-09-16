using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.Account;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.Chat;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.MapServer;
using ODMO.Commons.Utils;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class DigimonChangeNamePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.DigimonChangeName;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public DigimonChangeNamePacketProcessor(
            MapServer mapServer,
            DungeonsServer dungeonServer,
            EventServer eventServer,
            PvpServer pvpServer,
            ILogger logger,
            ISender sender)
        {
            _mapServer = mapServer;
            _dungeonServer = dungeonServer;
            _eventServer = eventServer;
            _pvpServer = pvpServer;
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            int itemSlot = packet.ReadInt();
            var newName = packet.ReadString();

            var oldName = client.Tamer.Partner.Name;
            var digimonID = client.Tamer.Partner.Id;

            var inventoryItem = client.Tamer.Inventory.FindItemBySlot(itemSlot);

            //_logger.Information($"itemSlot: {itemSlot} | inventoryItem: {inventoryItem.ItemId} | inventoryItem: {inventoryItem.Id}");

            var mapConfig = await _sender.Send(new GameMapConfigByMapIdQuery(client.Tamer.Location.MapId));
            
            if (inventoryItem != null)
            {
                if (inventoryItem?.ItemInfo.Section != 15100)
                {
                    _logger.Error($"The Player {client.Tamer.Name} tryed to change digimon name with the incorrect item: {inventoryItem.ItemId} - {inventoryItem.ItemInfo.Name}");

                    var banProcessor = SingletonResolver.GetService<BanForCheating>();
                    var banMessage = banProcessor.BanAccountWithMessage(client.AccountId, client.Tamer.Name, AccountBlockEnum.Permanent, "Cheating", client, "You tried to change your digimon name using a cheat method, So be happy with ban!");

                    client.Send(new NoticeMessagePacket(banMessage));
                    // client.Send(new DisconnectUserPacket($"GAME DISCONNECTED: TRYING TO USE CHEAT").Serialize());

                    return;
                }

                client.Tamer.Inventory.RemoveOrReduceItem(inventoryItem, 1, itemSlot);
                client.Tamer.Partner.UpdateDigimonName(newName);

                await _sender.Send(new ChangeDigimonNameByIdCommand(digimonID, newName));
                await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));

                switch (mapConfig?.Type)
                {
                    case MapTypeEnum.Dungeon:
                        _dungeonServer.BroadcastForTamerViews(client.TamerId, UtilitiesFunctions.GroupPackets(
                            new UnloadTamerPacket(client.Tamer).Serialize(),
                            new LoadTamerPacket(client.Tamer).Serialize()
                        ));
                        break;

                    case MapTypeEnum.Event:
                        _eventServer.BroadcastForTamerViews(client, UtilitiesFunctions.GroupPackets(
                            new UnloadTamerPacket(client.Tamer).Serialize(),
                            new LoadTamerPacket(client.Tamer).Serialize()
                        ));
                        break;

                    case MapTypeEnum.Pvp:
                        _pvpServer.BroadcastForTamerViews(client, UtilitiesFunctions.GroupPackets(
                            new UnloadTamerPacket(client.Tamer).Serialize(),
                            new LoadTamerPacket(client.Tamer).Serialize()
                        ));
                        break;

                    default:
                        _mapServer.BroadcastForTamerViews(client, UtilitiesFunctions.GroupPackets(
                            new UnloadTamerPacket(client.Tamer).Serialize(),
                            new LoadTamerPacket(client.Tamer).Serialize()
                        ));
                        break;
                }
                //client.Send(new DigimonChangeNamePacket(CharacterChangeNameType.Sucess, itemSlot, oldName, newName));
                //client.Send(new DigimonChangeNamePacket(CharacterChangeNameType.Complete, oldName, newName, itemSlot));

                _logger.Verbose($"Character {client.TamerId} Changed Digimon Name {oldName} to {newName}.");
            }
            else
            {
                _logger.Error($"Item nao encontrado !!");
            }
        }
    }
}