using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Readers;

namespace ODMO.Game
{
    public class GamePacketReader : PacketReaderBase, IPacketReader
    {
        public GameServerPacketEnum Enum => (GameServerPacketEnum)Type;

        public GamePacketReader(byte[] buffer)
        {
            Packet = new(buffer);

            Length = ReadShort();

            Type = ReadShort();

            Packet.Seek(Length - 2, SeekOrigin.Begin);

            int checksum = ReadShort();

            if (checksum != (Length ^ CheckSumValidation))
                throw new Exception("Invalid packet checksum");

            Packet.Seek(4, SeekOrigin.Begin);
        }
    }
}
