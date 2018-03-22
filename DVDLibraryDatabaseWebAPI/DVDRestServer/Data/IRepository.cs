using DVDDatabaseModel;
using System.Collections.Generic;

namespace Data
{
    public interface IRepository
    {
        DVD GetDVDById(int dVDId);
        List<DVD> GetAllDVDs();
        DVD GetDVDByTitle(string title);
        List<DVD> GetDVDsByReleaseYear(int releaseYear);
        List<DVD> GetDVDsByDirector(string directorName);
        List<DVD> GetDVDsByRating(string movieRating);

        void AddDVD(DVD dVD);
        void UpdateDVD(DVD dVD);
        void DeleteDVD(int id);
    }
}