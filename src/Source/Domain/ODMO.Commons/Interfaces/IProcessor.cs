using ODMO.Commons.Entities;

namespace ODMO.Commons.Interfaces
{
    public interface IProcessor
    {
        Task ProcessPacketAsync(GameClient client, byte[] data);
    }
}
