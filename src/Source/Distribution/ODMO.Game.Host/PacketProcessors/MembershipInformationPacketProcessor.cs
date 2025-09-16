using ODMO.Application;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Entities;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class MembershipInformationPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.MembershipInformation;

        private readonly AssetsLoader _assets;
        private readonly ISender _sender;
        private readonly ILogger _logger;

        public MembershipInformationPacketProcessor(AssetsLoader assets, ISender sender, ILogger logger)
        {
            _assets = assets;
            _sender = sender;
            _logger = logger;
        }

        public Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            //var isVip = packet.ReadByte();
            //var time = packet.ReadInt;

            //_logger.Warning($"isVip: {isVip} | Time: {time}");

            if (client.MembershipExpirationDate != null)
            {
                client.Send(new MembershipPacket(client.MembershipExpirationDate.Value, client.MembershipUtcSeconds));
            }
            else
            {
                client.Send(new MembershipPacket());
            }

            return Task.CompletedTask;
        }
    }
}