using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateUserCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var dto = new UserDTO()
            {
                Username = request.UserName,
                Password = request.Password,
                AccessLevel = request.AccessLevel
            };

            return await _repository.AddUserAsync(dto);
        }
    }
}