using etiqatest.Domain.Common;

namespace etiqatest.Domain.Users
{
    public class User : AuditableEntity
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public virtual ICollection<Skillset> Skillsets { get; set; }
        public string Hobby { get; set; } = string.Empty;

    }
}
