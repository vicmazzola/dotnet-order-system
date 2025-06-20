using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
    public class RepresentativeRepository : IRepresentativeRepository
    {
        private readonly DatabaseContext _context;

        public RepresentativeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<RepresentativeModel> GetAll() => _context.Representatives.ToList();

        public RepresentativeModel GetById(int id) => _context.Representatives.Find(id);

        public void Add(RepresentativeModel representative)
        {
            _context.Representatives.Add(representative);
            _context.SaveChanges();
        }

        public void Update(RepresentativeModel representative)
        {
            _context.Representatives.Update(representative);
            _context.SaveChanges();
        }

        public void Delete(RepresentativeModel representative)
        {
            _context.Representatives.Remove(representative);
            _context.SaveChanges();
        }
    }
}