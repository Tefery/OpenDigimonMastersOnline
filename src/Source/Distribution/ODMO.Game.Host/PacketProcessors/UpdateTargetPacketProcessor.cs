using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.GameHost;

namespace ODMO.Game.PacketProcessors
{
    public class UpdateTargetPacketProcessor : IGamePacketProcessor
    {
        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;

        public GameServerPacketEnum Type => GameServerPacketEnum.UpdateTarget;
        public UpdateTargetPacketProcessor(
          MapServer mapServer, DungeonsServer dungeonServer)
        {
            _mapServer = mapServer;
            _dungeonServer = dungeonServer;
        }

        public Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            packet.Skip(4);

            var targetHandler = packet.ReadInt();

            client.Tamer.UpdateTargetHandler(targetHandler);

            var targetMob = _mapServer.GetMobByHandler(client.Tamer.Location.MapId, targetHandler, true, client.TamerId);

            if (targetMob != null)
            {

                client.Send(new MobTargetPacket(targetMob.GeneralHandler, targetMob.Level, targetMob.CurrentHpRate, targetMob.TargetSummonHandler, targetMob.GetStartTimeUnixTimeSeconds(), targetMob.GetEndTimeUnixTimeSeconds()));
            }

            var targetdungeonMob = _dungeonServer.GetMobByHandler(client.Tamer.Location.MapId, targetHandler, true, client.TamerId);

            if (targetdungeonMob != null)
            {

                client.Send(new MobTargetPacket(targetdungeonMob.GeneralHandler, targetdungeonMob.Level, targetdungeonMob.CurrentHpRate, targetdungeonMob.TargetSummonHandler, targetdungeonMob.GetStartTimeUnixTimeSeconds(), targetdungeonMob.GetEndTimeUnixTimeSeconds()));
            }

            return Task.CompletedTask;
        }
    }
}