using AutoMapper;
using ODMO.Application.Separar.Commands.Create;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Packets.Chat;
using ODMO.Commons.Packets.GameServer;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class GuildAuthorityChangeNewMemberPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.GuildAuthorityChangeToNewMember;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ILogger _logger;
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public GuildAuthorityChangeNewMemberPacketProcessor(
            MapServer mapServer,
            DungeonsServer dungeonServer,
            EventServer eventServer,
            PvpServer pvpServer,
            ILogger logger,
            ISender sender,
            IMapper mapper)
        {
            _mapServer = mapServer;
            _dungeonServer = dungeonServer;
            _eventServer = eventServer;
            _pvpServer = pvpServer;
            _logger = logger;
            _sender = sender;
            _mapper = mapper;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var targetName = packet.ReadString();

            _logger.Debug($"Searching character by name {targetName}...");
            var targetCharacter = await _sender.Send(new CharacterByNameQuery(targetName));
            if (targetCharacter == null)
            {
                _logger.Warning($"Character not found with name {targetName}.");
                client.Send(new SystemMessagePacket($"Character not found with name {targetName}."));
                return;
            }

            _logger.Debug($"Searching guild by character id {targetCharacter.Id}...");
            var targetGuild =
                _mapper.Map<GuildModel>(await _sender.Send(new GuildByCharacterIdQuery(targetCharacter.Id)));
            if (targetGuild == null)
            {
                _logger.Warning($"Character {targetName} does not belong to a guild.");
                client.Send(new SystemMessagePacket($"Character {targetName} does not belong to a guild."));
                return;
            }

            foreach (var guildMember in targetGuild.Members)
            {
                if (guildMember.CharacterInfo == null)
                {
                    var guildMemberClient = _mapServer.FindClientByTamerId(guildMember.CharacterId);
                    if (guildMemberClient != null)
                    {
                        guildMember.SetCharacterInfo(guildMemberClient.Tamer);
                    }
                    else
                    {
                        guildMember.SetCharacterInfo(
                            _mapper.Map<CharacterModel>(
                                await _sender.Send(new CharacterByIdQuery(guildMember.CharacterId))));
                    }
                }
            }

            var targetMember = targetGuild.FindMember(targetCharacter.Id);
            if (targetMember != null)
            {
                var newAuthority = GuildAuthorityTypeEnum.NewMember;

                targetMember.SetAuthority(newAuthority);
                var newEntry = targetGuild.AddHistoricEntry((GuildHistoricTypeEnum)newAuthority, targetGuild.Master,
                    targetMember);

                targetGuild.Members
                    .ForEach(guildMember =>
                    {
                        _logger.Debug($"Sending guild historic packet for character {guildMember.CharacterId}...");
                        _mapServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildHistoricPacket(targetGuild.Historic).Serialize());

                        _dungeonServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildHistoricPacket(targetGuild.Historic).Serialize());

                        _eventServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildHistoricPacket(targetGuild.Historic).Serialize());

                        _pvpServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildHistoricPacket(targetGuild.Historic).Serialize());

                        _logger.Debug(
                            $"Sending guild authority change packet for character {guildMember.CharacterId}...");
                        _mapServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildPromotionDemotionPacket(packet.Type, targetName,
                                targetGuild.FindAuthority(newAuthority).Duty).Serialize());

                        _dungeonServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildPromotionDemotionPacket(packet.Type, targetName,
                                targetGuild.FindAuthority(newAuthority).Duty).Serialize());

                        _eventServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildPromotionDemotionPacket(packet.Type, targetName,
                                targetGuild.FindAuthority(newAuthority).Duty).Serialize());

                        _pvpServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildPromotionDemotionPacket(packet.Type, targetName,
                                targetGuild.FindAuthority(newAuthority).Duty).Serialize());
                    });

                _logger.Debug($"Saving historic entry for guild {targetGuild.Id}...");
                await _sender.Send(new CreateGuildHistoricEntryCommand(newEntry, targetGuild.Id));

                _logger.Debug($"Updating member authority for member {targetMember.Id} and guild {targetGuild.Id}...");
                await _sender.Send(new UpdateGuildMemberAuthorityCommand(targetMember));
            }
        }
    }
}