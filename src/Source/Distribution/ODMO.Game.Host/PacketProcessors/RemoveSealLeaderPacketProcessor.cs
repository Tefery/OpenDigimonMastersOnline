using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;

namespace ODMO.Game.PacketProcessors
{
    public class RemoveSealLeaderPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.RemoveSealLeader;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonsServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ISender _sender;

        public RemoveSealLeaderPacketProcessor(
            MapServer mapServer,
            DungeonsServer dungeonsServer,
            EventServer eventServer,
            PvpServer pvpServer,
            ISender sender)
        {
            _mapServer = mapServer;
            _dungeonsServer = dungeonsServer;
            _eventServer = eventServer;
            _pvpServer = pvpServer;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var sealSequentialId = packet.ReadShort();

            client.Tamer.SealList.SetLeader(0);
            var mapConfig = await _sender.Send(new GameMapConfigByMapIdQuery(client.Tamer.Location.MapId));
            switch (mapConfig?.Type)
            {
                case MapTypeEnum.Dungeon:
                    _dungeonsServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                        new RemoveSealLeaderPacket(client.Tamer.GeneralHandler, sealSequentialId).Serialize());
                    break;

                case MapTypeEnum.Event:
                    _eventServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                        new RemoveSealLeaderPacket(client.Tamer.GeneralHandler, sealSequentialId).Serialize());
                    break;

                case MapTypeEnum.Pvp:
                    _pvpServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                        new RemoveSealLeaderPacket(client.Tamer.GeneralHandler, sealSequentialId).Serialize());
                    break;

                default:
                    _mapServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                        new RemoveSealLeaderPacket(client.Tamer.GeneralHandler, sealSequentialId).Serialize());
                    break;
            }

            await _sender.Send(new UpdateCharacterSealsCommand(client.Tamer.SealList));
        }
    }
}