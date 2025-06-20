using AutoMapper;

public class CourseService : BaseService<Course, CourseRequestDto, CourseResponseDto>
{
    public CourseService(CourseRepository courseRepository, IMapper mapper) : base(courseRepository, mapper)
    {

    }
}   