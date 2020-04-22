using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class PatronService : IPatronService
    {
        private readonly LibraryDbContext _context;

        public PatronService(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(Patron newPatron)
        {
            _context.Add(newPatron);
            _context.SaveChanges();
        }

        public Patron Get(int id)
        {
            return _context.Patrons
                .Include(a => a.HomeLibraryBranch)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons
                .Include(a => a.HomeLibraryBranch);
            // Eager load this data.
        }
    }
}