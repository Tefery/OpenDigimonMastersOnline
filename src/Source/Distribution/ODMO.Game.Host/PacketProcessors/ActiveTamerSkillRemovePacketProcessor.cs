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
    public class ActiveTamerSkillRemovePacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ActiveTamerCashSkillRemove;

        private readonly ISender _sender;


        public ActiveTamerSkillRemovePacketProcessor(
            ISender sender)
        {
            _sender = sender;
        }
        public async Task Process(GameClient client, byte[] packetData)
        {

            var packet = new GamePacketReader(packetData);

            int skillId = packet.ReadInt();

            var activeSkill = client.Tamer.ActiveSkill.FirstOrDefault(x => x.SkillId == skillId);

            activeSkill.SetTamerSkill(0, 0, Commons.Enums.ClientEnums.TamerSkillTypeEnum.Normal);

            client?.Send(new ActiveTamerCashSkillRemove(skillId));
            await _sender.Send(new UpdateTamerSkillCooldownByIdCommand(activeSkill));

        }


    }

}

