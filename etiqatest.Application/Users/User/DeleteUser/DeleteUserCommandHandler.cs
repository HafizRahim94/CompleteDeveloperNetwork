using AutoMapper;
using etiqatest.Application.Common.Interfaces;
using MediatR;

namespace etiqatest.Application.Users.User.DeleteUser
{
    public class DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await userRepository.DeleteUserAsync(request.UserId , cancellationToken);

            return new DeleteUserResponse { isSuccess = isDeleted };
        }
    }
}
