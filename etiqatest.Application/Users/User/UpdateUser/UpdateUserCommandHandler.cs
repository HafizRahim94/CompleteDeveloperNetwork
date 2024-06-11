using AutoMapper;
using etiqatest.Application.Common.Interfaces;
using MediatR;

namespace etiqatest.Application.Users.User.UpdateUser
{
    public class UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUser = mapper.Map<Domain.Users.User>(request);
            var updatedUser = await userRepository.UpdateUserAsync(updateUser, cancellationToken);

            return mapper.Map<UpdateUserResponse>(updatedUser);

        }
    }
}
