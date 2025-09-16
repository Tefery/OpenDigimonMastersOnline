using ODMO.Application;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Packets.GameServer;
using ODMO.GameHost;
using MediatR;
using Serilog;


namespace ODMO.Game.PacketProcessors
{
    public class ItemSocketInPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.ItemSocketIn;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public ItemSocketInPacketProcessor(ILogger logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var packet = new GamePacketReader(packetData);

            _ = packet.ReadInt();
            var vipEnabled = packet.ReadByte();
            int npcId = packet.ReadInt();
            short sourceSlot = packet.ReadShort();
            short destinationSlot = packet.ReadShort();
            byte socketOrder = packet.ReadByte();

            var itemInfo = client.Tamer.Inventory.FindItemBySlot(sourceSlot);
            var destinationInfo = client.Tamer.Inventory.FindItemBySlot(destinationSlot);

            if (itemInfo != null && destinationInfo != null)
            {
                var avaliableSocket = destinationInfo.SocketStatus.First(x => x.AttributeId == 0);
                var avaliableStatus = destinationInfo.AccessoryStatus.First(x => x.Value == 0);

                if (avaliableSocket != null)
                {
                    var attributeApply = itemInfo.AccessoryStatus.First(x => x.Value > 0);

                    destinationInfo.SetPower(itemInfo.Power);
                    destinationInfo.SetReroll(0);
                    avaliableSocket.SetType(attributeApply.Type);
                    avaliableSocket.SetAttributeId((short)itemInfo.ItemId);
                    avaliableSocket.SetValue(itemInfo.Power);
                    avaliableStatus.SetType(attributeApply.Type);
                    avaliableStatus.SetValue(attributeApply.Value);
                }

                client.Tamer.Inventory.RemoveOrReduceItem(itemInfo, 1, sourceSlot);
                client.Tamer.Inventory.RemoveBits(itemInfo.ItemInfo.ScanPrice / 2);

                client.Send(new ItemSocketInPacket((int)client.Tamer.Inventory.Bits));

                await _sender.Send(new UpdateItemSocketStatusCommand(destinationInfo));
                await _sender.Send(new UpdateItemAccessoryStatusCommand(destinationInfo));
                await _sender.Send(new UpdateItemsCommand(client.Tamer.Inventory));
                await _sender.Send(new UpdateItemListBitsCommand(client.Tamer.Inventory));
            }

        }


        public int GetSkillAtt(ItemModel item, int nSkillLevel, int nApplyIndex)
        {


            var Skill = item.ItemInfo.SkillInfo;

            bool bDigimonSkill = IsDigimonSkill((int)item.ItemInfo.SkillCode);

            if (!bDigimonSkill ||   // ??? ??? ????(???/???) ?
                nApplyIndex == 0)   // ??? ???? ??? ?? ?? ??
                return Skill.Apply[nApplyIndex].Value + nSkillLevel * Skill.Apply[nApplyIndex].IncreaseValue;

            //??? ???? ??? ??? 1 ??? ??
            switch ((ApplyStatusEnum)Skill.Apply[nApplyIndex].Attribute)
            {
                // ???? / ?? ?? ?? ?? 14.05.28 chu8820
                case ApplyStatusEnum.APPLY_CA:
                case ApplyStatusEnum.APPLY_EV:
                    {
                        if (Skill.Apply[nApplyIndex].Type == SkillCodeApplyTypeEnum.Unknown207)
                        {
                            int nValue = Skill.Apply[nApplyIndex].Value + (nSkillLevel - 1) * Skill.Apply[nApplyIndex].IncreaseValue;
                            return (nValue * 100);
                        }
                        else //if( pFTSkill->s_Apply[ nApplyIndex ].s_nID == 206/*nSkill::Me_206*/ )
                            return Skill.Apply[nApplyIndex].Value + (nSkillLevel - 1) * Skill.Apply[nApplyIndex].IncreaseValue;
                    }
                default:
                    return Skill.Apply[nApplyIndex].Value + (nSkillLevel - 1) * Skill.Apply[nApplyIndex].IncreaseValue;
            }

            return Skill.Apply[nApplyIndex].Value + nSkillLevel * Skill.Apply[nApplyIndex].IncreaseValue;
        }

        public bool IsDigimonSkill(int SkillId)
        {
            if (SkillId / 100 == 21134 || SkillId / 100 == 21137)// ?????, ??? ????
            {
                return true;
            }
            else
            {
                return (SkillId / 1000000 >= 3 && SkillId / 1000000 <= 7);
            }


        }
    }
}