public class GroupRepository : BaseRepository<Group>
{
    public GroupRepository(ApplicationDbContext context) : base(context)
    {
    }
}