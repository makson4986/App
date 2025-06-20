using AutoMapper;

public class StudentInGroupService : BaseService<StudentInGroup, StudentRequestDto, StudentInGroupResponseDto>
{
    private readonly UserService _userService;

    public StudentInGroupService(StudentInGroupRepository repository, IMapper mapper, UserService userService) : base(repository, mapper)
    {
        _userService = userService;
    }

    public async Task<StudentInGroupResponseDto> AddStudent(int groupId, StudentRequestDto studentRequestDto)
    {
        var user = await _userService.GetByEmail(studentRequestDto.Email);
        var dto = new StudentInGroupRequestDto(groupId, user.Id);


        var response = await _repository.AddAsync(_mapper.Map<StudentInGroup>(dto));
        return _mapper.Map<StudentInGroupResponseDto>(response);
    }
}   