using AutoMapper;

public class StudentInGroupService : BaseService<StudentInGroup, StudentRequestDto, StudentInGroupResponseDto>
{
    private readonly AuthService _authService;

    public StudentInGroupService(StudentInGroupRepository repository, IMapper mapper, AuthService authService) : base(repository, mapper)
    {
        _authService = authService;
    }

    public async Task<StudentInGroupResponseDto> AddStudent(int groupId, StudentRequestDto studentRequestDto)
    {
        var user = await _authService.GetByEmail(studentRequestDto.Email);

        if (user == null)
        {
            throw new KeyNotFoundException("Student isn't found!");
        }

        var dto = new StudentInGroupRequestDto(groupId, user.Id);


        var response = await _repository.AddAsync(_mapper.Map<StudentInGroup>(dto));
        return _mapper.Map<StudentInGroupResponseDto>(response);
    }
}   