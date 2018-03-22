using DVDDatabaseModel;
using System.Collections.Generic;

namespace Data
{
    public class RepositoryManager
    {
        private IRepository _repository;
        public RepositoryManager(IRepository repository)
        {
            _repository = repository;
        }

        public DVD AccessGetDVDById(int dVDId)
        {
            return _repository.GetDVDById(dVDId);
        }
        public List<DVD> AccessAllDVDs()
        {
            return _repository.GetAllDVDs();
        }
        public DVD AccessDVDByTitle(string title)
        {
            return _repository.GetDVDByTitle(title);
        }
        public List<DVD> AccessDVDsByReleaseYear(int releaseYear)
        {
            return _repository.GetDVDsByReleaseYear(releaseYear);
        }
        public List<DVD> AccessDVDsByDirector(string directorName)
        {
            return _repository.GetDVDsByDirector(directorName);
        }
        public List<DVD> AccessDVDsByRating(string movieRating)
        {
            return _repository.GetDVDsByRating(movieRating);
        }
        public void AccessAddDVD(DVD dVD)
        {
            _repository.AddDVD(dVD);
        }
        public void AccessUpdateDVD(DVD dVD)
        {
            _repository.UpdateDVD(dVD);
        }
        public void AccessDeleteDVD(int id)
        {
            _repository.DeleteDVD(id);
        }
    }
}