using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Game.PacketProcessors
{
    public class AddFriendMemoPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.MemoFriend;

        private readonly ISender _sender;
        private readonly Serilog.ILogger _logger;

        public AddFriendMemoPacketProcessor(ISender sender, Serilog.ILogger logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var friendName = packet.ReadString();
            var oldMemo = packet.ReadString();
            var newMemo = packet.ReadString();

            var friend = client.Tamer.Friends.First(x => x.Name == friendName);

            if (friend != null) await _sender.Send(new ChangeFriendMemoCommand(friend.Id, newMemo));

        }
    }
}