using System.Linq.Expressions;
using AutoMapper;

public class GroupsService : BaseService<Group, GroupRequestDto, GroupResponseDto>
{
    public GroupsService(GroupRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<GroupResponseDto>> GetAllAsync(string Filter)
    {
        var groups = await ((GroupRepository)_repository).GetAllAsync(g => g.Course.Name == Filter);
        return _mapper.Map<IEnumerable<GroupResponseDto>>(groups);
    }
}