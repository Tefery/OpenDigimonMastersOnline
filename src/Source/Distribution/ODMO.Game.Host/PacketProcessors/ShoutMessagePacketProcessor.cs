using ODMO.Application.Separar.Commands.Create;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Chat;
using ODMO.Commons.Packets.Chat;
using ODMO.GameHost;
using ODMO.GameHost.EventsServer;
using MediatR;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace ODMO.Game.PacketProcessors
{
    public class ShoutMessagePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ShoutMessage;

        private readonly MapServer _mapServer;
        private readonly DungeonsServer _dungeonServer;
        private readonly EventServer _eventServer;
        private readonly PvpServer _pvpServer;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public ShoutMessagePacketProcessor(MapServer mapServer, DungeonsServer dungeonsServer, EventServer eventServer, PvpServer pvpServer,
            ILogger logger, ISender sender)
        {
            _mapServer = mapServer;
            _dungeonServer = dungeonsServer;
            _eventServer = eventServer;
            _pvpServer = pvpServer;
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            var message = packet.ReadString();

            if (client.Tamer.Level >= 20)
            {
                _mapServer.BroadcastForMapAllChannels(client.Tamer.Location.MapId, new ChatMessagePacket(message, ChatTypeEnum.Shout, client.Tamer.Name).Serialize());
                _dungeonServer.BroadcastForMapAllChannels(client.Tamer.Location.MapId, new ChatMessagePacket(message, ChatTypeEnum.Shout, client.Tamer.Name).Serialize());
                _eventServer.BroadcastForMapAllChannels(client.Tamer.Location.MapId, new ChatMessagePacket(message, ChatTypeEnum.Shout, client.Tamer.Name).Serialize());
                _pvpServer.BroadcastForMapAllChannels(client.Tamer.Location.MapId, new ChatMessagePacket(message, ChatTypeEnum.Shout, client.Tamer.Name).Serialize());

                _logger.Verbose($"Tamer {client.TamerId} : {client.Tamer.Name} sent shout message:\n{message}.");
                //await _mapServer.CallDiscord(message, client, "f7d399", "S");
                await _sender.Send(new CreateChatMessageCommand(ChatMessageModel.Create(client.TamerId, message)));
            }
            else
            {
                client.Send(new SystemMessagePacket($"Tamer level 20 required for shout chat."));
                _logger.Verbose($"Character {client.TamerId} sent shout to map {client.Tamer.Location.MapId} but has insufficient tamer level.");
            }
        }
    }
}