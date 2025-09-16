using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Entities;
using ODMO.Commons.Interfaces;
using MediatR;
using Serilog;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Packets.GameServer;

namespace ODMO.Game.PacketProcessors
{
    public class FriendListPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.FriendList;

        private readonly ISender _sender;
        private readonly ILogger _logger;

        public FriendListPacketProcessor(ISender sender, ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            //_logger.Information("Reading FriendList - packet 2404");

            var friends = client.Tamer.Friends;
            var foes = client.Tamer.Foes;

            //_logger.Information($"Friends: {friends.Count} - Foes: {foes.Count}");

            client.Send(new TamerRelationsPacket(friends, foes));
        }
    }
}