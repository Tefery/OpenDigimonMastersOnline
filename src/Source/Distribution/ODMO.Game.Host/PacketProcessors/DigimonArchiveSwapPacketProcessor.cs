using AutoMapper;
using ODMO.Application.Separar.Commands.Update;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.Entities;
using ODMO.Commons.Enums.PacketProcessor;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Digimon;
using ODMO.Commons.Packets.GameServer;
using ODMO.Commons.Writers;
using ODMO.Game.Managers;
using ODMO.GameHost;
using MediatR;
using Serilog;

namespace ODMO.Game.PacketProcessors
{
    public class DigimonArchiveSwapPacketProcessor : IGamePacketProcessor
    {
        public GameServerPacketEnum Type => GameServerPacketEnum.DigimonArchiveSwap;

        private readonly StatusManager _statusManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ISender _sender;

        public DigimonArchiveSwapPacketProcessor(
            StatusManager statusManager,
            IMapper mapper,
            ILogger logger,
            ISender sender)
        {
            _statusManager = statusManager;
            _mapper = mapper;
            _logger = logger;
            _sender = sender;
        }

        public async Task Process(GameClient client, byte[] packetData)
        {
            var pack = new GamePacketReader(packetData);

            var vipEnabled = Convert.ToBoolean(pack.ReadByte());

            var OldSlot = pack.ReadInt() - 1000;
            var NewSlot = pack.ReadInt() - 1000;
            int npcId = pack.ReadInt();


            // Verificar se os slots estão dentro dos limites válidos
            if (OldSlot >= 0 && NewSlot >= 0)
            {
                var Receiver = client.Tamer.DigimonArchive.DigimonArchives.FirstOrDefault(x => x.Slot == NewSlot);
                var Older = client.Tamer.DigimonArchive.DigimonArchives.FirstOrDefault(x => x.Slot == OldSlot);
                var ReceiverB = Receiver.DigimonId;
                var OlderB = Older.DigimonId;

                // Verificar se os Digimons existem nos slots especificados
                if (Receiver != null && Older != null)
                {
                    //Limpar Slots
                    Receiver.RemoveDigimon();
                    Older.RemoveDigimon();
                    // Trocar os slots
                    Receiver.AddDigimon(OlderB);
                    Older.AddDigimon(ReceiverB);


                    await _sender.Send(new UpdateCharacterDigimonArchiveItemCommand(Older));
                    await _sender.Send(new UpdateCharacterDigimonArchiveItemCommand(Receiver));

                }
                /*var packet = new PacketWriter();
                packet.Type(3243);
                packet.WriteInt(OldSlot + 1000);
                packet.WriteInt(NewSlot + 1000);

                client.Send(packet.Serialize());*/
                client.Send(new DigimonArchivePacket(OldSlot, NewSlot));
            }
        }
    }
}