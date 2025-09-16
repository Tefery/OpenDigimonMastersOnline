using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;

using MediatR;

namespace ODMO.Game.PacketProcessors
{
    public class RemoveBuffPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.RemoveBuff;

        private readonly ISender _sender;

        public RemoveBuffPacketProcessor(ISender sender)
        {
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var targetType = packet.ReadByte();
            var buffId = packet.ReadUShort();

            if (client.Tamer.BuffList.ForceExpired(buffId))
            {
                client.Tamer.BuffList.Remove(buffId);

                client?.Send(new RemoveBuffPacket(client.Tamer.GeneralHandler, buffId));
                client?.Send(new UpdateStatusPacket(client.Tamer));
                await _sender.Send(new UpdateCharacterBuffListCommand(client.Tamer.BuffList));
            }

            if (client.Partner.BuffList.ForceExpired(buffId))
            {
                client.Partner.BuffList.Remove(buffId);
                client?.Send(new RemoveBuffPacket(client.Partner.GeneralHandler, buffId));
                client?.Send(new UpdateStatusPacket(client.Tamer));
                await _sender.Send(new UpdateDigimonBuffListCommand(client.Partner.BuffList));
            }
        }
    }
}