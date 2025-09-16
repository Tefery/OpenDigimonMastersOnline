using ODMO.Commons.Models.Base;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Utils;
using ODMO.Commons.Writers;
using System.Collections.Generic;
using ODMO.Commons.Models.Digimon;
using static System.Reflection.Metadata.BlobBuilder;

namespace ODMO.Commons.Packets.GameServer
{
    public class EncyclopediaDeckBuffUsePacket : PacketWriter
    {
        private const int PacketNumber = 3236;

        public EncyclopediaDeckBuffUsePacket(int deckBuffHpCalculation, int deckBuffAsCalculation)
        {
            Type(PacketNumber);

            WriteInt(deckBuffHpCalculation);
            WriteShort((short)deckBuffAsCalculation);
        }
    }
}