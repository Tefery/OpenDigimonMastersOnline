using AutoMapper;
using ODMO.Application.Separar.Commands.Create;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.Character;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.MapServer;
using ODMO.Commons.Utils;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class GuildCreatePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.CreateGuild;

        private readonly MapServer _mapServer;
        private readonly EventServer _eventServer;
        private readonly DungeonsServer _dungeonsServer;
        private readonly PvpServer _pvpServer;
        private readonly ISender _sender;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GuildCreatePacketProcessor(
            MapServer mapServer,
            EventServer eventServer,
            DungeonsServer dungeonsServer,
            PvpServer pvpServer,
            ISender sender,
            ILogger logger,
            IMapper mapper
        )
        {
            _mapServer = mapServer;
            _eventServer = eventServer;
            _dungeonsServer = dungeonsServer;
            _pvpServer = pvpServer;
            _sender = sender;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var guildName = packet.ReadString();

            packet.Skip(1);

            var itemSlot = packet.ReadShort();
            var npcId = packet.ReadInt();

            //_logger.Information($"GuildName: {guildName} | itemSlot: {itemSlot} | Npc: {npcId}");

            var nameTaken = await _sender.Send(new GuildByGuildNameQuery(guildName)) != null;
            var guildPermit = client.Tamer.Inventory.FindItemBySlot(itemSlot);

            if (guildPermit == null || guildPermit.Amount <= 0 || nameTaken)
            {
                _logger.Debug($"Sending guild create fail packet for character {client.TamerId}...");
                client.Send(new GuildCreateFailPacket(client.Tamer.Name, guildName));
                return;
            }

            var guild = GuildModel.Create(guildName);

            guild.AddMember(client.Tamer, GuildAuthorityTypeEnum.Master);
            guild.AddHistoricEntry(GuildHistoricTypeEnum.GuildCreate, guild.Master, guild.Master);

            client.Tamer.SetGuild(guild);

            await _sender.Send(new CreateGuildCommand(guild));

            _logger.Debug($"Sending guild create success packet for character {client.TamerId}...");
            client.Send(new GuildCreateSuccessPacket(client.Tamer.Name, itemSlot, guildName));

            _logger.Debug($"Sending guild information packet for character {client.TamerId}...");
            client.Send(new GuildInformationPacket(guild));

            _logger.Debug($"Sending guild historic packet for character {client.TamerId}...");
            client.Send(new GuildHistoricPacket(client.Tamer.Guild!.Historic));

            _logger.Debug($"Getting guild rank position for guild {client.Tamer.Guild.Id}...");

            var guildRank = await _sender.Send(new GuildCurrentRankByGuildIdQuery(client.Tamer.Guild.Id));

            if (guildRank > 0 && guildRank <= 100)
            {
                _logger.Debug($"Sending guild rank packet for character {client.TamerId}...");
                client.Send(new GuildRankPacket(guildRank));
            }

            _logger.Verbose(
                $"Character {client.TamerId} created guild {client.Tamer.Guild.Id} {client.Tamer.Guild.Name}.");

            _mapServer.BroadcastForTargetTamers(client.TamerId, UtilitiesFunctions.GroupPackets(
                new UnloadTamerPacket(client.Tamer).Serialize(),
                new LoadTamerPacket(client.Tamer).Serialize(),
                new LoadBuffsPacket(client.Tamer).Serialize()
            ));

            _pvpServer.BroadcastForTargetTamers(client.TamerId, UtilitiesFunctions.GroupPackets(
                new UnloadTamerPacket(client.Tamer).Serialize(),
                new LoadTamerPacket(client.Tamer).Serialize(),
                new LoadBuffsPacket(client.Tamer).Serialize()
            ));

            _eventServer.BroadcastForTargetTamers(client.TamerId, UtilitiesFunctions.GroupPackets(
                new UnloadTamerPacket(client.Tamer).Serialize(),
                new LoadTamerPacket(client.Tamer).Serialize(),
                new LoadBuffsPacket(client.Tamer).Serialize()
            ));

            _dungeonsServer.BroadcastForTargetTamers(client.TamerId, UtilitiesFunctions.GroupPackets(
                new UnloadTamerPacket(client.Tamer).Serialize(),
                new LoadTamerPacket(client.Tamer).Serialize(),
                new LoadBuffsPacket(client.Tamer).Serialize()
            ));

            client.Tamer.Inventory.RemoveOrReduceItem(guildPermit, 1);
            await _sender.Send(new UpdateItemCommand(guildPermit));
        }
    }
}