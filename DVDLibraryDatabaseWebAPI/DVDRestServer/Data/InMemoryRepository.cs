using System.Collections.Generic;
using DVDDatabaseModel;
using System.Linq;

namespace Data
{
    public class InMemoryRepository : IRepository
    {                
        private static List<DVD> _DVDs = new List<DVD>()
        {
            new DVD
            {
                DVDId = 0,
                DVDTitle = "A Great Tale",
                RealeaseYear = 2015,
                Director =  "SomeOtherGuy",
                Rating = "PG-13",
                DVDNotes = "This really is a great tale!",
            },
            new DVD
            {
                DVDId = 1,
                DVDTitle = "A Good Tale",
                RealeaseYear = 2011,
                Director = "SomeGuy",
                Rating = "PG",
                DVDNotes = "This is a good tale!"
            },
        };
        public void AddDVD(DVD dVD)
        {
            dVD.DVDId = _DVDs.Max(dvd => dvd.DVDId) + 1;
            _DVDs.Add(dVD);
        }
        public void UpdateDVD(DVD newDVD)
        {
            var originalDVD = _DVDs.FirstOrDefault(theDVD => theDVD.DVDId == newDVD.DVDId);

            originalDVD.DVDId = newDVD.DVDId;
            originalDVD.DVDTitle = newDVD.DVDTitle;
            originalDVD.Director = newDVD.Director;
            originalDVD.Rating = newDVD.Rating;
            originalDVD.RealeaseYear = newDVD.RealeaseYear;
            originalDVD.DVDNotes = newDVD.DVDNotes;
        }
        public void DeleteDVD(int id)
        {
            DVD dVD = GetAllDVDs().FirstOrDefault(dvd => dvd.DVDId == id);
            _DVDs.Remove(dVD);
        }
        public List<DVD> GetAllDVDs()
        {
            return _DVDs;
        }
        public DVD GetDVDById(int id)
        {
            return _DVDs.FirstOrDefault(dVD => dVD.DVDId == id);
        }
        public DVD GetDVDByTitle(string title)
        {
            return _DVDs.FirstOrDefault(dVD => dVD.DVDTitle == title);
        }
        public List<DVD> GetDVDsByDirector(string directorName)
        {
            return _DVDs.Where(dVD => dVD.Director == directorName).ToList();
        }
        public List<DVD> GetDVDsByRating(string movieRating)
        {
            return _DVDs.Where(dVD => dVD.Rating == movieRating).ToList();
        }
        public List<DVD> GetDVDsByReleaseYear(int releaseYear)
        {
            return _DVDs.Where(dVD => dVD.RealeaseYear == releaseYear).ToList();
        }
    }
}