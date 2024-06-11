using MediatR;

namespace etiqatest.Application.Users.User.AddUser
{
    public class AddUserCommand : IRequest<AddUserResponse>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
