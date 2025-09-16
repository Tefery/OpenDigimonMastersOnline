using MediatR;
using ODMO.Commons.DTOs.Digimon;

namespace ODMO.Application.Separar.Queries
{
    public class GetAllCharactersDigimonQuery : IRequest<List<DigimonDTO>>
    {
        public GetAllCharactersDigimonQuery()
        {
            
        }
    }
}