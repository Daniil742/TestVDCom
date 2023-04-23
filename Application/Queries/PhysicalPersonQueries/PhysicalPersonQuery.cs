using Application.Models.DB;

namespace Application.Queries.PhysicalPersonQueries
{
    public class PhysicalPersonQuery
    {
        private readonly ApplicationDbContext _context;

        public PhysicalPersonQuery()
        {
            _context = new ApplicationDbContext();
        }
    }
}
