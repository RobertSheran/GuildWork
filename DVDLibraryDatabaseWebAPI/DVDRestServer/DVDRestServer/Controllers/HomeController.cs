using Data;
using DVDDatabaseModel;
using DVDWebAPI.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDById(int id)
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            return Ok(repositoryManager.AccessGetDVDById(id));
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDVDs()
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            return Ok(repositoryManager.AccessAllDVDs().Select(DvdViewModel.FromDvd));
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByTitle(string title)
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            return Ok(DvdViewModel.FromDvd(repositoryManager.AccessDVDByTitle(title)));
        }

        [Route("dvds/year/{realeaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByYear(int realeaseYear)
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            return Ok(repositoryManager.AccessDVDsByReleaseYear(realeaseYear).Select(DvdViewModel.FromDvd));
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByDirector(string directorName)
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            return Ok(repositoryManager.AccessDVDsByDirector(directorName).Select(DvdViewModel.FromDvd));
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByRating(string rating)
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            return Ok(repositoryManager.AccessDVDsByRating(rating).Select(DvdViewModel.FromDvd));
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public void AddDVD(DvdViewModel dvd)
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            repositoryManager.AccessAddDVD(dvd.ToDvd());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void EditDVD(DvdViewModel dvd)
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            repositoryManager.AccessUpdateDVD(dvd.ToDvd());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void DeleteDVD(int id)
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            repositoryManager.AccessDeleteDVD(id);
        }
    }
}
