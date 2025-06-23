
public class AttendanceRepository : BaseRepository<Attendance>
{
    public AttendanceRepository(ApplicationDbContext context) : base(context)
    {
    }
}