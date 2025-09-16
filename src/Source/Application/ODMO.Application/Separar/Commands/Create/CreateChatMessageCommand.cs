using ODMO.Commons.Models.Chat;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateChatMessageCommand : IRequest
    {
        public ChatMessageModel ChatMessage { get; private set; }

        public CreateChatMessageCommand(ChatMessageModel chatMessage)
        {
            ChatMessage = chatMessage;
        }
    }
}