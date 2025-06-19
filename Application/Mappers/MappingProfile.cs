using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CourseRequestDto, Courses>();
        CreateMap<Courses, CourseResponseDto>();

        CreateMap<GroupRequestDto, Groups>();
        CreateMap<Groups, GroupResponseDto>();
    }
}
