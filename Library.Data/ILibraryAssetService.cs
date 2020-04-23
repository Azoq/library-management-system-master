using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data
{
    public interface ILibraryAssetService
    {
        IEnumerable<ProfilingAsset> GetAll();
        ProfilingAsset Get(int id);
        void Add(ProfilingAsset newAsset);
        string GetType(int id);
        string GetTitle(int id);
        LibraryBranch GetCurrentLocation(int id);
    }
}