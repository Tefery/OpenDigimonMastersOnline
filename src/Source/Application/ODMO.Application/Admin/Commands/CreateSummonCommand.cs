using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Config;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateSummonCommand :IRequest<SummonDTO>
    {
        public SummonDTO Summon { get; }

        public CreateSummonCommand(SummonDTO summon)
        {
            Summon = summon;
        }
    }
}
