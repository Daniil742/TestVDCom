using Application.Models.DB;

namespace Application.Queries.LegalPersonQueries
{
    public class LegalPersonQuery
    {
        private readonly ApplicationDbContext _context;

        public LegalPersonQuery()
        {
            _context = new ApplicationDbContext();
        }
    }
}
