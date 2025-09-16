using ODMO.Commons.Models.Base;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateItemSocketStatusCommand : IRequest
    {
        public ItemModel Item { get; }

        public UpdateItemSocketStatusCommand(ItemModel item)
        {
            Item = item;
        }
    }
}