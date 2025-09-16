using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class TimeRechargeResultPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.TimeChargeResult;

        private readonly ILogger _logger;

        public TimeRechargeResultPacketProcessor(
            ILogger logger)
        {
            _logger = logger;
        }

        public Task Process(GameClient client, byte[] packetData)
        {

        
            _logger.Debug($"Sending TimeRecharge Result  packet...");
            client.Send(new TimeRechargeResultPacket());

            return Task.CompletedTask;
        }
    }
}