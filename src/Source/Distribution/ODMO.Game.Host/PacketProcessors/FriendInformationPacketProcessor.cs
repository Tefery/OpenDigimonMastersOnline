using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;

namespace ODMO.Game.PacketProcessors
{
    public class FriendInformationPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.FriendInformation;

        public FriendInformationPacketProcessor()
        {
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            //TODO: fix implementation
            client.Send(new FriendInformationPacket());
        }
    }
}