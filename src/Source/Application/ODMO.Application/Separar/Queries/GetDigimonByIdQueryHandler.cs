using AutoMapper;
using ODMO.Commons.DTOs.Digimon;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetDigimonByIdQueryHandler : IRequestHandler<GetDigimonByIdQuery, DigimonDTO?>
    {
        private readonly ICharacterQueriesRepository _repository;

        public GetDigimonByIdQueryHandler(ICharacterQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<DigimonDTO?> Handle(GetDigimonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDigimonByIdAsync(request.DigimonId);
        }
    }
}