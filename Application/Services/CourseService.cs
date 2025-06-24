using AutoMapper;

public class CourseService : BaseService<Course, CourseRequestDto, CourseResponseDto>
{
    private readonly AuthService _authService;

    public CourseService(CourseRepository courseRepository, IMapper mapper, AuthService authService) : base(courseRepository, mapper)
    {
        _authService = authService;
    }

    public override async Task<CourseResponseDto> AddAsync(CourseRequestDto requestDto)
    {
        var userProfile = _authService.Profile();
        User? user = await _authService.GetByEmail(userProfile.Email);

        Course course = _mapper.Map<Course>(requestDto);
        course.CreatedById = user.Id;
        var result = await _repository.AddAsync(course);
        return _mapper.Map<CourseResponseDto>(result);
    }
}   