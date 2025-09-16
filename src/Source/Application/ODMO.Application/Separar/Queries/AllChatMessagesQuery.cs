using ODMO.Commons.DTOs.Chat;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AllChatMessagesQuery : IRequest<IList<ChatMessageDTO>>
    {
    }
}