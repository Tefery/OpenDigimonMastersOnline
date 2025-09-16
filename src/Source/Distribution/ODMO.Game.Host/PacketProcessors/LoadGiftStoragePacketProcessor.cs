using ODMO.Application;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.GameServer.Combat;
using ODMO.Commons.Packets.Items;
using MediatR;
using Serilog;
using System.Text;

namespace ODMO.Game.PacketProcessors
{
    public class LoadGiftStoragePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.LoadGiftStorage;

        private readonly ILogger _logger;

        public LoadGiftStoragePacketProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var giftStorage = client.Tamer.GiftWarehouse;

            client.Send(new LoadGiftStoragePacket(giftStorage));
        }
    }
}