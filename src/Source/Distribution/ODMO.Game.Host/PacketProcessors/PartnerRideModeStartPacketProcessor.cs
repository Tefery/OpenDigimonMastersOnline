using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class PartnerRideModeStartPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.PartnerRideModeStart;

        private readonly MapServer _mapServer;
        private readonly EventServer _eventServer;
        private readonly DungeonsServer _dungeonsServer;
        private readonly PvpServer _pvpServer;
        private readonly ILogger _logger;

        public PartnerRideModeStartPacketProcessor(
            MapServer mapServer,
            DungeonsServer dungeonsServer,
            EventServer eventServer,
            PvpServer pvpServer,
            ILogger logger)
        {
            _mapServer = mapServer;
            _dungeonsServer = dungeonsServer;
            _eventServer = eventServer;
            _pvpServer = pvpServer;
            _logger = logger;
        }

        public Task Process(GameClient client, byte[] packetData)
        {
            client.Tamer.StartRideMode();

            _mapServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                new UpdateMovementSpeedPacket(client.Tamer).Serialize());
            _mapServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                new RideModeStartPacket(client.Tamer.GeneralHandler, client.Partner.GeneralHandler).Serialize());

            _dungeonsServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                new UpdateMovementSpeedPacket(client.Tamer).Serialize());
            _dungeonsServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                new RideModeStartPacket(client.Tamer.GeneralHandler, client.Partner.GeneralHandler).Serialize());

            _eventServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                new UpdateMovementSpeedPacket(client.Tamer).Serialize());
            _eventServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                new RideModeStartPacket(client.Tamer.GeneralHandler, client.Partner.GeneralHandler).Serialize());

            _pvpServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                new UpdateMovementSpeedPacket(client.Tamer).Serialize());
            _pvpServer.BroadcastForTamerViewsAndSelf(client.TamerId,
                new RideModeStartPacket(client.Tamer.GeneralHandler, client.Partner.GeneralHandler).Serialize());

            _logger.Verbose($"Character {client.TamerId} started riding mode with " +
                            $"{client.Partner.Id} ({client.Partner.CurrentType}).");

            return Task.CompletedTask;
        }
    }
}