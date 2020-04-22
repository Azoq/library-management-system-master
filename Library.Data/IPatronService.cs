using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data
{
    public interface IPatronService
    {
        IEnumerable<Patron> GetAll();
        Patron Get(int id);
        void Add(Patron newBook);
    }
}