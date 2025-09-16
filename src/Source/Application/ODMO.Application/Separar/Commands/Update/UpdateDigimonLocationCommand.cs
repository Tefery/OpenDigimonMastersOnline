using ODMO.Commons.Models.Digimon;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateDigimonLocationCommand : IRequest
    {
        public DigimonLocationModel Location { get; set; }

        public UpdateDigimonLocationCommand(DigimonLocationModel location)
        {
            Location = location;
        }
    }
}