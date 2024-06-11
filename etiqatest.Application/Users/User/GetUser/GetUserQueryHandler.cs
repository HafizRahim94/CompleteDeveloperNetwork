using AutoMapper;
using etiqatest.Application.Common.Interfaces;
using MediatR;

namespace etiqatest.Application.Users.User.GetUser
{
    public class GetUserQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserAsync(request.Id, cancellationToken);

            return mapper.Map<GetUserResponse>(user);
        }
    }
}
