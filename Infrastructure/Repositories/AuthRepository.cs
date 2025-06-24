using Microsoft.EntityFrameworkCore;

public class AuthRepository : BaseRepository<User>
{
    public AuthRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmail(string email) => await _dbSet.FirstOrDefaultAsync(user => user.Email == email);
}