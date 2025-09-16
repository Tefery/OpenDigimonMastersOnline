using ODMO.Application.Separar.Commands.Create;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.Character;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Packets.GameServer;
using MediatR;

namespace ODMO.Game.PacketProcessors
{
    public class AddFriendPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.AddFriend;

        private readonly ISender _sender;

        public AddFriendPacketProcessor(ISender sender)
        {
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var friendName = packet.ReadString();
            byte status = 0;
            bool stat = false;

            var availableName = await _sender.Send(new CharacterByNameQuery(friendName));

            if (availableName == null)
            {
                client.Send(new FriendNotFoundPacket(friendName));
            }
            else
            {
                if (availableName.State == CharacterStateEnum.Disconnected)
                {
                    status = 0;
                    stat = true;
                }
                else
                {
                    status = 1;
                }

                var newFriend = CharacterFriendModel.Create(friendName, availableName.Id, stat);

                newFriend.SetTamer(client.Tamer);
                newFriend.Annotation = "";
                client.Tamer.AddFriend(newFriend);

                var FriendInfo = await _sender.Send(new CreateNewFriendCommand(newFriend));

                if (FriendInfo != null)
                {
                    client.Send(new AddFriendPacket(friendName, status));
                }

            }
        }
    }
}