using AutoMapper;
using etiqatest.Application.Users.User.AddSkillset;
using etiqatest.Application.Users.User.AddUser;
using etiqatest.Application.Users.User.DeleteSkillset;
using etiqatest.Application.Users.User.DeleteUser;
using etiqatest.Application.Users.User.GetSkillset;
using etiqatest.Application.Users.User.GetSkillsets;
using etiqatest.Application.Users.User.GetUser;
using etiqatest.Application.Users.User.GetUsers;
using etiqatest.Application.Users.User.UpdateSkillset;
using etiqatest.Application.Users.User.UpdateUser;
using etiqatest.Domain.Users;

namespace etiqatest.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetUserQuery>().ReverseMap();

            CreateMap<User, GetUserResponse>().ReverseMap();

            CreateMap<User, AddUserCommand>().ReverseMap();

            CreateMap<User, AddUserResponse>().ReverseMap();

            CreateMap<User, DeleteUserCommand>().ReverseMap();

            CreateMap<User, UpdateUserCommand>().ReverseMap();

            CreateMap<User, UpdateUserResponse>().ReverseMap();

            CreateMap<Skillset, GetSkillsetResponse>().ReverseMap();

            CreateMap<Skillset, AddSkillsetCommand>().ReverseMap();

            CreateMap<Skillset, AddSkillsetResponse>().ReverseMap();

            CreateMap<Skillset, DeleteSkillsetCommand>().ReverseMap();

            CreateMap<Skillset, UpdateSkillsetCommand>().ReverseMap();

            CreateMap<Skillset, UpdateSkillsetResponse>().ReverseMap();

            CreateMap<Skillset, AddSkillsetResponse>().ReverseMap();

            CreateMap<List<Skillset>, GetSkillsetsResponse>().ReverseMap();
        }
    }
}