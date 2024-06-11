using AutoMapper;
using etiqatest.Application.Common.Interfaces;
using MediatR;

namespace etiqatest.Application.Users.User.AddUser
{
    public class AddUserCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<AddUserCommand, AddUserResponse>
    {
        public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<etiqatest.Domain.Users.User>(request);

            var addUser = await userRepository.AddUserAsync(user, cancellationToken);

            return mapper.Map<AddUserResponse>(addUser);
        }
    }
}
