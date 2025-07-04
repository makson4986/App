using System.Linq.Expressions;
using AutoMapper;

public abstract class BaseService<TEntity, TRequestDto, TResponseDto> where TEntity : class
{
    protected readonly BaseRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public BaseService(BaseRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TResponseDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<TResponseDto>>(entities);
    }

    public virtual async Task<TResponseDto> GetAsync(int id)
    {
        TEntity entity = await GetEntityAsync(id);
        return _mapper.Map<TResponseDto>(entity);
    }

    public virtual async Task<TResponseDto> AddAsync(TRequestDto requestDto)
    {
        TEntity entity = _mapper.Map<TEntity>(requestDto);
        TEntity result = await _repository.AddAsync(entity);
        return _mapper.Map<TResponseDto>(result);
    }

    public virtual async Task UpdateAsync(int id, TRequestDto requestDto)
    {
        TEntity entity = await GetEntityAsync(id);

        _mapper.Map(requestDto, entity);
        await _repository.UpdateAsync(entity);
    }

    public virtual async Task RemoveAsync(int id)
    {
        TEntity entity = await GetEntityAsync(id);
        await _repository.RemoveAsync(entity);
    }

    private async Task<TEntity> GetEntityAsync(int id)
    {
        TEntity? entity = await _repository.GetAsync(id);

        if (entity == null)
        {
            throw new KeyNotFoundException("Not found!");
        }

        return entity;
    }
}