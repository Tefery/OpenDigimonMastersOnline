using ODMO.Commons.Models.Digimon;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateDigimonBuffListCommand : IRequest
    {
        public DigimonBuffListModel BuffList { get; set; }

        public UpdateDigimonBuffListCommand(DigimonBuffListModel buffList)
        {
            BuffList = buffList;
        }
    }
}