using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Writers;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class ArchiveAcademyExtractionPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ArchiveAcademyExtraction;

        private readonly ILogger _logger;

        public ArchiveAcademyExtractionPacketProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packets = new GamePacketReader(packetData);

            _logger.Debug($"Reading Packet 3229 -> ArchiveAcademyExtraction");

            var AcademySlot = packets.ReadByte();

            _logger.Debug($"AcademySlot: {AcademySlot}");

            var packet = new PacketWriter();

            packet.Type(3229);
            packet.WriteByte(AcademySlot);

            client.Send(packet.Serialize());

            //client.Send(new ArchiveAcademyExtractionPacket());
        }
    }
}

