using AutoMapper;
using etiqatest.Application.Common.Interfaces;
using etiqatest.Domain.Users;
using MediatR;

namespace etiqatest.Application.Users.User.AddSkillset
{
    public class AddSkillsetCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<AddSkillsetCommand, AddSkillsetResponse>
    {
        public async Task<AddSkillsetResponse> Handle(AddSkillsetCommand request, CancellationToken cancellationToken)
        {
            var skillSet = mapper.Map<Skillset>(request);

            var result = await userRepository.AddUserSkillSetAsync(skillSet,cancellationToken);

            return mapper.Map<AddSkillsetResponse>(result);
        }
    }
}
