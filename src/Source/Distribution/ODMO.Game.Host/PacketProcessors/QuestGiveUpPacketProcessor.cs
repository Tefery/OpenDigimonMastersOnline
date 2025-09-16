using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class QuestGiveUpPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.QuestGiveUp;

        private readonly ILogger _logger;
        private readonly ISender _sender;

        public QuestGiveUpPacketProcessor(
            ILogger logger,
            ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var questId = packet.ReadShort();

            _logger.Verbose($"Character {client.TamerId} gave up quest {questId}.");

            var id = client.Tamer.Progress.RemoveQuest(questId);

            await _sender.Send(new RemoveActiveQuestCommand(id));
        }
    }
}
