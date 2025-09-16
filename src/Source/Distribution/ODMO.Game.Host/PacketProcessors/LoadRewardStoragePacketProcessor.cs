using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer.Combat;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class LoadRewardStoragePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.RewardStorage;

        private readonly ILogger _logger;

        public LoadRewardStoragePacketProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var x1 = packet.ReadUInt();
            var x2 = packet.ReadByte();

            //var targetItem = client.Tamer.GiftWarehouse.FindItemBySlot(itemSlot);

            //client.Send(new LoadRewardStoragePacket(client.Tamer.GiftWarehouse));
        }
    }
}