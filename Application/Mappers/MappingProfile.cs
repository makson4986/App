using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CourseRequestDto, Course>();
        CreateMap<Course, CourseResponseDto>();

        CreateMap<GroupRequestDto, Group>();
        CreateMap<Group, GroupResponseDto>();

        CreateMap<RegisterDto, User>();
        CreateMap<UserProfileDto, User>();
        CreateMap<User, UserProfileDto>();
    }
}
