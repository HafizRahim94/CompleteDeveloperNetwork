using AutoMapper;
using etiqatest.Application.Common.Interfaces;
using MediatR;

namespace etiqatest.Application.Auth.Login
{
    public class LoginCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordHasher passwordHasher, ITokenService tokenService) : IRequestHandler<LoginCommand, LoginResponse>
    {
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByEmail(request.Email);

            if (user is null)
                throw new Exception("user does not exists");


            var IsPasswordCorrect = passwordHasher.VerifyPassword(request.Password, user.Password, user.Salt);

            if (!IsPasswordCorrect)
            {
                throw new Exception("Login unsuccesful, password is incorrect!");
            }

            return new LoginResponse() { BearerToken = tokenService.GenerateToken(user.Id.ToString(), user.Username) };
        }
    }
}
