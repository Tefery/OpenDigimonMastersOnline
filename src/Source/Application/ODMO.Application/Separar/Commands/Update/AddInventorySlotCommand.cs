using ODMO.Commons.Models.Base;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class AddInventorySlotCommand : IRequest
    {
        public ItemModel NewSlot { get; }

        public AddInventorySlotCommand(ItemModel newSlot)
        {
            NewSlot = newSlot;
        }
    }
}