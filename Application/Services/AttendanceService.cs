using AutoMapper;

public class AttendanceService : BaseService<Attendance, AttendanceRequestDto, AttendanceReponseDto>
{
    public AttendanceService(AttendanceRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<AttendanceReponseDto>> GetAllAsync(int lessonId)
    {
        var atts = await _repository.GetAllAsync(a => a.LessonId == lessonId);
        var result = new List<AttendanceReponseDto>();

        foreach (Attendance att in atts)
        {
            result.Add(_mapper.Map<AttendanceReponseDto>(att));
        }

        return result;
    }


    public async Task<IEnumerable<AttendanceReponseDto>> MarkBulk(int lessonId, IEnumerable<AttendanceRequestDto> attendanceRequestDto)
    {
        var entities = attendanceRequestDto.Select(dto =>
        {
            var entity = _mapper.Map<Attendance>(dto);
            entity.LessonId = lessonId;
            return entity;
        }).ToList();

        await _repository.AddRangeAsync(entities);
        return _mapper.Map<IEnumerable<AttendanceReponseDto>>(entities);
    }
}