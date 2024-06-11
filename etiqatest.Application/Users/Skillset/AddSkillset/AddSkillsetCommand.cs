using MediatR;

namespace etiqatest.Application.Users.User.AddSkillset
{
    public class AddSkillsetCommand : IRequest<AddSkillsetResponse>
    {
        public int UserId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
    }
}
