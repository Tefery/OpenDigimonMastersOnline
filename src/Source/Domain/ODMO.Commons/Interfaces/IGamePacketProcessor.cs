using ODMO.Commons.Enums.PacketProcessor;

namespace ODMO.Commons.Interfaces
{
    public interface IGamePacketProcessor : IPacketProcessor
    {
        public GameServerPacketEnum Type { get; }
    }
}
