using ODMO.Commons.Models.Base;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class AddInventorySlotsCommand : IRequest
    {
        public List<ItemModel> Items { get; }

        public AddInventorySlotsCommand(List<ItemModel> items)
        {
            Items = items;
        }
    }
}