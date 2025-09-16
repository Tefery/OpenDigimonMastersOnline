using ODMO.Commons.Writers;

namespace ODMO.Commons.Packets.GameServer.Combat
{
    public class SetCombatOffPacket : PacketWriter
    {
        private const int PacketNumber = 1035;

        /// <summary>
        /// Set the target as out of combat.
        /// </summary>
        /// <param name="handler">The target handler to set</param>
        public SetCombatOffPacket(int handler)
        {
            Type(PacketNumber);
            WriteInt(handler);
        }
    }
}