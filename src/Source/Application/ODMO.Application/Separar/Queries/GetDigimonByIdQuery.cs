using MediatR;
using ODMO.Commons.DTOs.Digimon;

namespace ODMO.Application.Separar.Queries
{
    public class GetDigimonByIdQuery : IRequest<DigimonDTO?>
    {
        public long DigimonId { get; }

        public GetDigimonByIdQuery(long digimonId)
        {
            DigimonId = digimonId;
        }
    }
}