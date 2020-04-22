using System.Collections.Generic;
using Library.Data.Models;

namespace Library.Data
{
    public interface ILibraryAssetService
    {
        IEnumerable<LibraryAsset> GetAll();
        LibraryAsset Get(int id);
        void Add(LibraryAsset newAsset);
        string GetType(int id);
        string GetTitle(int id);
        LibraryBranch GetCurrentLocation(int id);
    }
}