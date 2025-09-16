using ODMO.Commons.Enums.Character;
using ODMO.Commons.Writers;
using System.Net.Sockets;

namespace ODMO.Commons.Packets.GameServer
{
    public class TamerChangeNamePacket : PacketWriter
    {
        private const int PacketNumber = 1311;

        /// <summary>
        /// Load the account remaining membership time.
        /// </summary>
        /// <param name="NameType">Enum from Tamer Name Result Change.</param>
        /// <param name="tamerOldName">Old Character Name.</param>
        /// <param name="tamerNewName">New Character Name.</param>
        /// <param name="itemSlot">Inventory Item Slot.</param>
        public TamerChangeNamePacket(CharacterChangeNameType NameType, string tamerOldName,string tamerNewName,int itemSlot)
        {
             Type(PacketNumber);
             WriteInt((int)NameType);
             WriteInt(itemSlot);
             WriteString(tamerOldName);
             WriteString(tamerNewName);         
             WriteByte(1);
        }
        public TamerChangeNamePacket(CharacterChangeNameType NameType, int itemSlot, string tamerOldName, string tamerNewName)
        {
            Type(PacketNumber);
            WriteInt((int)NameType);
            WriteString(tamerOldName);
            WriteString(tamerNewName);
            WriteInt(itemSlot);
            WriteByte(1);
        }
    }
}