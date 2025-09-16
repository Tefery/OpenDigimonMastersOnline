using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Enums.Party;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Game.Managers;
using ODMO.GameHost;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class PartyChangeLootTypePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.PartyConfigChange;

        private readonly PartyManager _partyManager;
        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;
        private readonly ILogger _logger;

        public PartyChangeLootTypePacketProcessor(
            PartyManager partyManager,
            MapServer mapServer,
            DungeonsServer dungeonServer,
            ILogger logger)
        {
            _partyManager = partyManager;
            _mapServer = mapServer;
            _dungeonServer = dungeonServer;
            _logger = logger;
        }


        public Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);
            var lootType = (PartyLootShareTypeEnum)packet.ReadInt();
            var rareType = (PartyLootShareRarityEnum)packet.ReadByte();

            var party = _partyManager.FindParty(client.TamerId);

            if(party != null)
            {
                party.ChangeLootType(lootType, rareType);

                foreach (var target in party.Members.Values)
                {

                    var targetClient = _mapServer.FindClientByTamerId(target.Id);
                    if (targetClient == null) targetClient = _dungeonServer.FindClientByTamerId(target.Id);

                    if (targetClient == null)
                        continue;

                    targetClient.Send(new PartyChangeLootTypePacket(lootType, rareType));
                }
            }
            return Task.CompletedTask;
        }
    }
}