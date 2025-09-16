using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Writers;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class ArchiveAcademyErrorPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ArchiveAcademyError;

        private readonly ILogger _logger;

        public ArchiveAcademyErrorPacketProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packets = new GamePacketReader(packetData);

            _logger.Information($"Reading Packet 3228 -> ArchiveAcademyError");

            var errorCode = 0;

            var packet = new PacketWriter();

            packet.Type(3228);
            packet.WriteInt(errorCode);
            
            client.Send(packet.Serialize());

            //client.Send(new ArchiveAcademyIniciarPacket());
        }
    }
}

