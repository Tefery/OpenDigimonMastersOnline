using ODMO.Application;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;

using MediatR;

namespace ODMO.Game.PacketProcessors
{
    public class SealSetFavoritePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.SetSealFavorite;

        private readonly AssetsLoader _assets;
        private readonly ISender _sender;

        public SealSetFavoritePacketProcessor(
            AssetsLoader assets,
            ISender sender)
        {
            _assets = assets;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var sequentialId = packet.ReadShort();
            var favorite = packet.ReadByte();

            var sealInfo = _assets.SealInfo.FirstOrDefault(x => x.SequentialId == sequentialId);

            if (sealInfo != null)
            {
                client.Tamer.SealList.SetFavorite(sealInfo.SealId, sequentialId, favorite == 1);

                client.Send(new SealFavoritePacket(sequentialId, favorite));

                await _sender.Send(new UpdateCharacterSealsCommand(client.Tamer.SealList));
            }
        }
    }
}