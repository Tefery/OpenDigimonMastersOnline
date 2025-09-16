using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class DigimonBaseInfoQuery : IRequest<DigimonBaseInfoAssetDTO?>
    {
        public int Type { get; private set; }

        public DigimonBaseInfoQuery(int type)
        {
            Type = type;
        }
    }
}

