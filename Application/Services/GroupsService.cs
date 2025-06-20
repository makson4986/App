using System.Linq.Expressions;
using AutoMapper;

public class GroupsService : BaseService<Group, GroupRequestDto, GroupResponseDto>
{
    public GroupsService(GroupRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<GroupResponseDto>> GetAllAsync(string Filter)
    {
        var groups = await _repository.GetAllAsync(g => g.Course.Name == Filter);
        var result = new List<GroupResponseDto>();

        foreach (Group group in groups)
        {
            result.Add(_mapper.Map<GroupResponseDto>(group));
        }

        return result;
    }
}