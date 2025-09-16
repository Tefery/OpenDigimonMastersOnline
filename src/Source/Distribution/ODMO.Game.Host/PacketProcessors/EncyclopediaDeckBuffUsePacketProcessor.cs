using AutoMapper;
using ODMO.Application;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Asset;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Digimon;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.Items;
using ODMO.Commons.Writers;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class EncyclopediaDeckBuffUsePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.EncyclopediaDeckBuffUse;

        private readonly AssetsLoader _assets;
        private readonly ISender _sender;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public EncyclopediaDeckBuffUsePacketProcessor(
            AssetsLoader assets,
            ISender sender,
            ILogger logger,
            IMapper mapper)
        {
            _assets = assets;
            _sender = sender;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            int deckBuffId = packet.ReadInt();

            var encyclopedia = client.Tamer.Encyclopedia;

            DeckBuffModel? deckBuff = _assets.DeckBuffs.FirstOrDefault(x => x.GroupIdX == deckBuffId);

            client.Tamer.UpdateDeckBuffId(deckBuffId == 0 ? null : deckBuffId, deckBuff);

            await _sender.Send(new UpdateCharacterDeckBuffCommand(client.Tamer));

            /*_logger.Information(
                $"\nCurrent MHP: {client.Tamer.Partner.HP}\nCurrent AS: {client.Tamer.Partner.AS}\n" +
                $"Current AT: {client.Tamer.Partner.AT}\nCurrent CD: {client.Tamer.Partner.CD}\nCurrent SCD: {client.Tamer.Partner.SCD}" +
                $"\nCurrent SK: {client.Tamer.Partner.SKD}");*/

            client.Send(new EncyclopediaDeckBuffUsePacket(client.Tamer.Partner.HP, client.Tamer.Partner.AS));
        }
    }
}