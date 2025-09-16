using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer.Combat
{
    public class SetCombatOnPacket : PacketWriter
    {
        private const int PacketNumber = 1034;

        /// <summary>
        /// Set the target as in combat.
        /// </summary>
        /// <param name="handler">The target handler to set</param>
        public SetCombatOnPacket(int handler)
        {
            Type(PacketNumber);
            WriteInt(handler);
        }
    }
}