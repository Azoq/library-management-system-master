using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class LibraryAssetService : ILibraryAssetService
    {
        private readonly LibraryDbContext _context;

        public LibraryAssetService(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(ProfilingAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public ProfilingAsset Get(int id)
        {
            return _context.LibraryAssets
                .Include(a => a.Status)
                .Include(a => a.Location)
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<ProfilingAsset> GetAll()
        {
            return _context.LibraryAssets
                .Include(a => a.Status)
                .Include(a => a.Location);
        }


        public string GetQ1(int id)
        {
            return "Q1";
        }
        public string GetQ2(int id)
        {
            return "q2";
        }
        public string GetQ3(int id)
        {
            return "q3";
        }

        public string GetQ4(int id)
        {
            return "q4";
        }
        public string GetQ5(int id)
        {
            return "q5";
        }
        public string GetQ6(int id)
        {
            return "q6";
        }
        public string GetQ7(int id)
        {
            return "q7";
        }
        public string GetQ8(int id)
        {
            return "q8";
        }
        public string GetQ9(int id)
        {
            return "q9";
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return _context.LibraryAssets.First(a => a.Id == id).Location;
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets.First(a => a.Id == id).Title;
        }

        public string GetType(int id)
        {
            // Hack
            var book = _context.LibraryAssets
                .OfType<Profiling>().SingleOrDefault(a => a.Id == id);
            return book != null ? "Book" : "Video";
        }
    }
}