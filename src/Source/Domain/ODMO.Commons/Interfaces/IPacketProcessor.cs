using ODMO.Commons.Entities;

namespace ODMO.Commons.Interfaces
{
    public interface IPacketProcessor
    {
        public Task Process(GameClient client, byte[] packetData);
    }
}