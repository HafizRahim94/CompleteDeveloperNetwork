using AutoMapper;
using etiqatest.Application.Common.Interfaces;
using MediatR;

namespace etiqatest.Application.Users.User.GetSkillsets
{
    public class GetSkillsetsCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetSkillsetsCommand, GetSkillsetsResponse>
    {
        public async Task<GetSkillsetsResponse> Handle(GetSkillsetsCommand request, CancellationToken cancellationToken)
        {
            var skillsets = await userRepository.GetUserSkillSetsAsync(request.UserId, cancellationToken);

            var skillsetsResponse = new GetSkillsetsResponse();

            skillsetsResponse.Skillsets = skillsets;

            return skillsetsResponse;
        }
    }
}
