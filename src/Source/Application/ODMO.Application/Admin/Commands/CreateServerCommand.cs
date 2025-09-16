using ODMO.Commons.DTOs.Server;
using ODMO.Commons.Enums.Server;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateServerCommand : IRequest<ServerDTO>
    {
        public string Name { get; }
        public int Experience { get; }
        public ServerTypeEnum Type { get; }
        public int Port { get; }

        public CreateServerCommand(
            string name,
            int experience,
            ServerTypeEnum type,
            int port)
        {
            Name = name;
            Experience = experience;
            Type = type;
            Port = port;
        }
    }
}