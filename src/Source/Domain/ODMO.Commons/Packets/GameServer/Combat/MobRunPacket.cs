using ODMO.Commons.Models.Config;
using ODMO.Commons.Models.Config.Events;
using ODMO.Commons.Models.Summon;
using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer.Combat
{
    public class MobRunPacket : PacketWriter
    {
        private const int PacketNumber = 1006;

        /// <summary>
        /// Default mob movimentation packet.
        /// </summary>
        /// <param name="mob">The mob that is moving</param>
        public MobRunPacket(MobConfigModel mob)
        {
            Type(PacketNumber);
            WriteByte(6);
            WriteShort(1);
            WriteUInt((uint)mob.GeneralHandler);
            WriteInt(mob.CurrentLocation.X);
            WriteInt(mob.CurrentLocation.Y);
            WriteInt(0);
        }
        public MobRunPacket(SummonMobModel mob)
        {
            Type(PacketNumber);
            WriteByte(6);
            WriteShort(1);
            WriteUInt((uint)mob.GeneralHandler);
            WriteInt(mob.CurrentLocation.X);
            WriteInt(mob.CurrentLocation.Y);
            WriteInt(0);
        }
        public MobRunPacket(EventMobConfigModel mob)
        {
            Type(PacketNumber);
            WriteByte(6);
            WriteShort(1);
            WriteUInt((uint)mob.GeneralHandler);
            WriteInt(mob.CurrentLocation.X);
            WriteInt(mob.CurrentLocation.Y);
            WriteInt(0);
        }
        public MobRunPacket(int X,int Y, uint Handler)
        {
            Type(PacketNumber);
            WriteByte(6);
            WriteShort(1);
            WriteUInt((uint)Handler);
            WriteInt(X);
            WriteInt(Y);
            WriteInt(0);
        }
    }
}