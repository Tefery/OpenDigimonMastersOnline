using AutoMapper;
using ODMO.Commons.DTOs.Digimon;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetAllCharactersDigimonQueryHandler : IRequestHandler<GetAllCharactersDigimonQuery, List<DigimonDTO>>
    {
        private readonly ICharacterQueriesRepository _repository;

        public GetAllCharactersDigimonQueryHandler(ICharacterQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DigimonDTO>> Handle(GetAllCharactersDigimonQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllDigimonsAsync();
        }
    }
}