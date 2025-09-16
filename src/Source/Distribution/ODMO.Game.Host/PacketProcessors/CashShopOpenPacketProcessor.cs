using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.Chat;
using ODMO.Commons.Packets.GameServer;
using MediatR;
using Serilog;
using System.Net.Sockets;

namespace ODMO.Game.PacketProcessors
{
    public class CashShopOpenPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.CashShopOpen;

        private readonly ILogger _logger;

        public CashShopOpenPacketProcessor(
            ILogger logger)
        {
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {

            var packet = new GamePacketReader(packetData);
            client.Send(new CashShopIniciarPacket());
        }
    }
}

