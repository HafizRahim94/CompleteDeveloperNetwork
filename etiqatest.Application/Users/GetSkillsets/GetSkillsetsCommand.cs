using MediatR;

namespace etiqatest.Application.Users.User.GetSkillsets
{
    public class GetSkillsetsCommand : IRequest<GetSkillsetsResponse>
    {
        public int UserId { get; set; }
    }
}
