using AutoMapper;
using etiqatest.Application.Common.Interfaces;
using etiqatest.Application.Users.User.GetUser;
using MediatR;

namespace etiqatest.Application.Users.User.GetUsers
{
    public class GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetUsersQuery, GetUsersResponse>
    {
        public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetUsersAsync(cancellationToken);

            var usersResponse = new GetUsersResponse();

            users.ForEach(x =>
            {
                usersResponse.Users.Add(mapper.Map<GetUserResponse>(x));
            });

            return usersResponse;
        }
    }
}
