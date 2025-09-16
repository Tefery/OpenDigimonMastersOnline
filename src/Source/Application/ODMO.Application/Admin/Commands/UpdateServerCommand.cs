using ODMO.Commons.Enums.Server;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateServerCommand : IRequest
    {
        public long Id { get; }
        public string Name { get; }
        public int Experience { get; }
        public bool Maintenance { get; }
        public ServerTypeEnum Type { get; }
        public int Port { get; }

        public UpdateServerCommand(
            long id,
            string name,
            int experience,
            bool maintenance,
            ServerTypeEnum type,
            int port)
        {
            Id = id;
            Name = name;
            Experience = experience;
            Maintenance = maintenance;
            Type = type;
            Port = port;
        }
    }
}