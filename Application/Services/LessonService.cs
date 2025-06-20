using AutoMapper;

public class LessonsService : BaseService<Lesson, LessonRequestDto, LessonResponseDto>
{
    public LessonsService(LessonRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<LessonResponseDto>> GetByFilter(int? courseId = null, int? groupId = null)
    {
        IEnumerable<Lesson> lessons;
        var result = new List<LessonResponseDto>();

        if (courseId == null)
        {
            lessons = await _repository.GetAllAsync(l => l.GroupId == groupId);
        }
        else if (groupId == null)
        {
            lessons = await _repository.GetAllAsync(l => l.Group.CourseId == courseId);
        }
        else
        {
            lessons = await _repository.GetAllAsync(l => l.GroupId == groupId && l.Group.CourseId == courseId);
        }

        foreach (Lesson lesson in lessons)
        {
            result.Add(_mapper.Map<LessonResponseDto>(lesson));
        }

        return result;
    }
}