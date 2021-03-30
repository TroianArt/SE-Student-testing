using AutoMapper;
using BLL.DTO;
using DAL.Domain;
using DAL.Enums;

namespace BLL.MapperConfig
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Answer, AnswerDto>()
                .ReverseMap();

            CreateMap<Group, GroupDto>()
                .ReverseMap();

            CreateMap<Question, QuestionDto>()
                .ReverseMap();

            CreateMap<QuestionType, QuestionTypeDto>()
                .ReverseMap();

            CreateMap<Role, RoleDto>()
                .ReverseMap();

            CreateMap<Test, TestDto>()
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<UserTest, UserTestDto>()
                .ReverseMap();
        }
    }
}