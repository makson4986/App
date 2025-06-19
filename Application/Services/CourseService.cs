using AutoMapper;

public class CourseService : BaseService<Courses, CourseRequestDto, CourseResponseDto>
{
    public CourseService(CourseRepository courseRepository, IMapper mapper) : base(courseRepository, mapper)
    {

    }
}   