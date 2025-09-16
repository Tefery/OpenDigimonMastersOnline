using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class GuildNoticeUpdatePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.GuildNoticeUpdate;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ISender _sender;
        private readonly ILogger _logger;

        public GuildNoticeUpdatePacketProcessor(
            MapServer mapServer,
            DungeonsServer dungeonServer,
            EventServer eventServer,
            PvpServer pvpServer,
            ISender sender,
            ILogger logger)
        {
            _mapServer = mapServer;
            _dungeonServer = dungeonServer;
            _eventServer = eventServer;
            _pvpServer = pvpServer;
            _sender = sender;
            _logger = logger;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var newMessage = packet.ReadString();

            if (string.IsNullOrEmpty(newMessage))
                return;

            if (client.Tamer.Guild != null)
            {
                client.Tamer.Guild.SetNotice(newMessage);

                client.Tamer.Guild.Members
                    .ToList()
                    .ForEach(guildMember =>
                    {
                        _logger.Debug($"Sending guild notice update packet for character {guildMember.CharacterId}...");
                        _mapServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildNoticeUpdatePacket(newMessage).Serialize());
                        _dungeonServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildNoticeUpdatePacket(newMessage).Serialize());
                        _eventServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildNoticeUpdatePacket(newMessage).Serialize());
                        _pvpServer.BroadcastForUniqueTamer(guildMember.CharacterId,
                            new GuildNoticeUpdatePacket(newMessage).Serialize());
                    });

                await _sender.Send(new UpdateGuildNoticeCommand(client.Tamer.Guild.Id, newMessage));
            }
        }
    }
}