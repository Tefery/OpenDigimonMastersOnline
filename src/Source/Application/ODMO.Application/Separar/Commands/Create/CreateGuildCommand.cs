using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.DTOs.Mechanics;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateGuildCommand : IRequest<GuildDTO>
    {
        public GuildModel Guild { get; set; }

        public CreateGuildCommand(GuildModel guild)
        {
            Guild = guild;
        }
    }
}