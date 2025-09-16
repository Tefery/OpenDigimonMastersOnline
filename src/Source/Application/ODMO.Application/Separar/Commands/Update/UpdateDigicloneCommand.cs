using ODMO.Commons.Models.Digimon;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateDigicloneCommand : IRequest
    {
        public DigimonDigicloneModel Digiclone { get; set; }

        public UpdateDigicloneCommand(DigimonDigicloneModel digiclone)
        {
            Digiclone = digiclone;
        }
    }
}