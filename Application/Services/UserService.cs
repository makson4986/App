using AutoMapper;

public class UserService : BaseService<User, UserRequestDto, UserReponseDto>
{
    public UserService(UserRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<UserReponseDto> GetByEmail(string email)
    {
        User? user = await ((UserRepository)_repository).GetByEmail(email);

        if (user == null)
        {
            throw new KeyNotFoundException("Not found!");
        }

        return _mapper.Map<UserReponseDto>(user);
    }
}