using AutoMapper;
using ODMO.Application;
using ODMO.Application.Separar.Commands.Delete;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.TamerShop;
using ODMO.Commons.Packets.PersonalShop;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;

namespace ODMO.Game.PacketProcessors
{
    public class ConsignedShopViewPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ConsignedShopView;

        private readonly AssetsLoader _assets;
        private readonly MapServer _mapServer;
        private readonly EventServer _eventServer;
        private readonly DungeonsServer _dungeonsServer;
        private readonly PvpServer _pvpServer;
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public ConsignedShopViewPacketProcessor(
            MapServer mapServer,
            EventServer eventServer,
            DungeonsServer dungeonsServer,
            PvpServer pvpServer,
            AssetsLoader assets,
            IMapper mapper,
            ISender sender)
        {
            _mapServer = mapServer;
            _eventServer = eventServer;
            _dungeonsServer = dungeonsServer;
            _pvpServer = pvpServer;
            _assets = assets;
            _mapper = mapper;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            Console.WriteLine($"Pacote de Visualização da Loja Consignada");

            packet.Skip(4);
            var handler = packet.ReadInt();

            Console.WriteLine($"Buscando loja consignada com o identificador {handler}...");
            var consignedShop =
                _mapper.Map<ConsignedShop>(await _sender.Send(new ConsignedShopByHandlerQuery(handler)));
            var mapConfig = await _sender.Send(new GameMapConfigByMapIdQuery(client.Tamer.Location.MapId));
            if (consignedShop == null)
            {
                Console.WriteLine($"Loja consignada não encontrada com o identificador {handler}.");
                client.Send(new ConsignedShopItemsViewPacket());

                Console.WriteLine($"Enviando pacote de descarregamento da loja consignada...");

                switch (mapConfig?.Type)
                {
                    case MapTypeEnum.Dungeon:
                        _dungeonsServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                            new UnloadConsignedShopPacket(handler).Serialize());
                        break;

                    case MapTypeEnum.Event:
                        _eventServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                            new UnloadConsignedShopPacket(handler).Serialize());
                        break;

                    case MapTypeEnum.Pvp:
                        _pvpServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                            new UnloadConsignedShopPacket(handler).Serialize());
                        break;

                    default:
                        _mapServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                            new UnloadConsignedShopPacket(handler).Serialize());
                        break;
                }

                return;
            }

            Console.WriteLine($"Buscando proprietário da loja consignada com id {consignedShop.CharacterId}...");
            var shopOwner =
                _mapper.Map<CharacterModel>(
                    await _sender.Send(new CharacterAndItemsByIdQuery(consignedShop.CharacterId)));

            if (shopOwner == null || shopOwner.ConsignedShopItems.Count == 0)
            {
                Console.WriteLine($"Excluindo loja consignada...");
                await _sender.Send(new DeleteConsignedShopCommand(handler));

                Console.WriteLine($"Enviando pacote de visualização dos itens da loja consignada...");
                client.Send(new ConsignedShopItemsViewPacket());

                Console.WriteLine($"Enviando pacote de descarregamento da loja consignada...");
                switch (mapConfig?.Type)
                {
                    case MapTypeEnum.Dungeon:
                        _dungeonsServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                            new UnloadConsignedShopPacket(handler).Serialize());
                        break;

                    case MapTypeEnum.Event:
                        _eventServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                            new UnloadConsignedShopPacket(handler).Serialize());
                        break;

                    case MapTypeEnum.Pvp:
                        _pvpServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                            new UnloadConsignedShopPacket(handler).Serialize());
                        break;

                    default:
                        _mapServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                            new UnloadConsignedShopPacket(handler).Serialize());
                        break;
                }

                return;
            }

            foreach (var item in shopOwner.ConsignedShopItems.Items)
            {
                item.SetItemInfo(_assets.ItemInfo.FirstOrDefault(x => x.ItemId == item.ItemId));

                //TODO: generalizar isso em rotina
                if (item.ItemId > 0 && item.ItemInfo == null)
                {
                    item.SetItemId();
                    shopOwner.ConsignedShopItems.CheckEmptyItems();
                    Console.WriteLine($"Atualizando a lista de itens da loja consignada...");
                    await _sender.Send(new UpdateItemsCommand(shopOwner.ConsignedShopItems));
                }
            }

            Console.WriteLine($"Enviando pacote de visualização da lista de itens da loja consignada...");
            client.Send(new ConsignedShopItemsViewPacket(consignedShop, shopOwner.ConsignedShopItems, shopOwner.Name));
        }
    }
}