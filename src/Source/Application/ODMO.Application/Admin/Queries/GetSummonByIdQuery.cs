using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMO.Application.Admin.Queries
{
    public class GetSummonByIdQuery : IRequest<GetSummonByIdQueryDto>
    {
        public long Id { get; }

        public GetSummonByIdQuery(long id)
        {
            Id = id;
        }
    }
}
