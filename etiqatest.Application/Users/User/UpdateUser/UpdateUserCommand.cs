using MediatR;

namespace etiqatest.Application.Users.User.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Hobby { get; set; } = string.Empty;
    }
}
