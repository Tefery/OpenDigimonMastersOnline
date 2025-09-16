using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Writers;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class ArchiveAcademyInsertPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ArchiveAcademyInsert;

        private readonly ILogger _logger;

        public ArchiveAcademyInsertPacketProcessor(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packets = new GamePacketReader(packetData);

            _logger.Debug($"Reading Packet 3227 -> ArchiveAcademyInsert");

            var AcademySlot = packets.ReadByte();
            var ArchiveSlot = packets.ReadUInt() - 1000;
            var InventorySlot = packets.ReadInt();

            _logger.Debug($"AcademySlot: {AcademySlot} | ArchiveSlot: {ArchiveSlot} | InventorySlot: {InventorySlot}");

            var itemUsed = client.Tamer.Inventory.FindItemBySlot(InventorySlot);

            var packet = new PacketWriter();

            packet.Type(3227);
            packet.WriteByte(AcademySlot);
            packet.WriteUInt(ArchiveSlot + 1000);
            packet.WriteInt(InventorySlot);    // 11
            packet.WriteInt(1000);

            client.Send(packet.Serialize());
            //client.Send(new ArchiveAcademyIniciarPacket());
        }

    }
}

