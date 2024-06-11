namespace etiqatest.Application.Users.User.UpdateUser
{
    public class UpdateUserResponse
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public string Hobby { get; set; } = string.Empty;
    }
}
