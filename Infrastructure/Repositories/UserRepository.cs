using System.Data.Common;
using Microsoft.EntityFrameworkCore;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmail(string email) => await _dbSet.FirstOrDefaultAsync(user => user.Email == email);
}