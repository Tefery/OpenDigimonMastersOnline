using ODMO.Application;
using ODMO.Application.Admin.Commands;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.Character;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Packets.MapServer;
using ODMO.GameHost;
using MediatR;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class ChangeTamerModelProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.TamerChangeModel;


        private readonly MapServer _mapServer;
        private readonly IConfiguration _configuration;
        private readonly ISender _sender;
        private readonly ILogger _logger;

        private const string GameServerAddress = "GameServer:Address";
        private const string GamerServerPublic = "GameServer:PublicAddress";
        private const string GameServerPort = "GameServer:Port";

        public ChangeTamerModelProcessor(
            MapServer mapServer,
            IConfiguration configuration,
            ISender sender,
            ILogger logger)
        {
            _configuration = configuration;
            _mapServer = mapServer;
            _sender = sender;
            _logger = logger;
        }
        public async Task Process(GameClient client, byte[] packetData)
        {

            var packet = new GamePacketReader(packetData);

            int newModel = packet.ReadInt();
            short itemSlot = packet.ReadShort();

            var inventoryItem = client.Tamer.Inventory.FindItemBySlot(itemSlot);

            if (inventoryItem != null)
            {
                client.Tamer.Inventory.RemoveOrReduceItem(inventoryItem, 1, itemSlot);

                client.Tamer.RemovePartnerPassiveBuff();
                client.Tamer.SetPartnerPassiveBuff((CharacterModelEnum)newModel);

                var ActiveSkill = client.Tamer.ActiveSkill.Where(x => x.Type == Commons.Enums.ClientEnums.TamerSkillTypeEnum.Normal && x.SkillId > 0).ToList();

                if (ActiveSkill.Count > 0)
                {
                    foreach (var skill in ActiveSkill)
                    {
                        var activeSkill = client.Tamer.ActiveSkill.FirstOrDefault(x => x.Id == skill.Id);
                        activeSkill.SetTamerSkill(0, 0, Commons.Enums.ClientEnums.TamerSkillTypeEnum.Normal);

                        await _sender.Send(new UpdateTamerSkillCooldownByIdCommand(activeSkill));
                    }
                }

                await _sender.Send(new ChangeTamerModelByIdCommand(client.Tamer.Id, (CharacterModelEnum)newModel));
                await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));
                await _sender.Send(new UpdateDigimonBuffListCommand(client.Partner.BuffList));
               

                client.Send(new ChangeTamerModelPacket(newModel, itemSlot));
                _logger.Verbose($"Character {client.TamerId} Changed Model {client.Tamer.Model} to {(CharacterModelEnum)newModel}.");

                _mapServer.RemoveClient(client);

               
                client.Tamer.NewLocation(client.Tamer.Location.MapId, client.Tamer.Location.X, client.Tamer.Location.Y);
                await _sender.Send(new UpdateCharacterLocationCommand(client.Tamer.Location));

                client.Tamer.Partner.NewLocation(client.Tamer.Location.MapId, client.Tamer.Location.X, client.Tamer.Location.Y);
                await _sender.Send(new UpdateDigimonLocationCommand(client.Tamer.Partner.Location));

                client.Tamer.UpdateState(CharacterStateEnum.Loading);
                await _sender.Send(new UpdateCharacterStateCommand(client.TamerId, CharacterStateEnum.Loading));

                client.SetGameQuit(false);

                client.Send(new MapSwapPacket(
                    _configuration[GamerServerPublic],
                    _configuration[GameServerPort],
                    client.Tamer.Location.MapId,
                    client.Tamer.Location.X,
                    client.Tamer.Location.Y)
                    .Serialize());

                
            }

        }
    }
}