using Data;
using DVDDatabaseModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class InMemoryTests
    {
        [Test]
        public void CanGetByID()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.AreEqual(repositoryManager.AccessGetDVDById(0).DVDTitle, "A Great Tale");
        }

        [Test]
        public void CanGetByTitle()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.AreEqual(repositoryManager.AccessDVDByTitle("A Great Tale").DVDTitle, "A Great Tale");
        }

        [Test]
        public void CanGetByDirector()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByDirector("SomeOtherGuy").Count, 1);
        }

        [Test]
        public void CanGetByYear()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByReleaseYear(2015).Count, 1);
        }

        [Test]
        public void CanGetByRating()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByRating("PG").Count, 1);
        }    

        [Test]
        public void CanAdd()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 2);
            repositoryManager.AccessAddDVD(new DVD() { DVDTitle = "testADD", Director = "YetAnotherGuy", RealeaseYear = 1993, Rating = "R",DVDNotes="A Movie Made For Testing",DVDId=2 });
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 3);
        }

        [Test]
        public void CanGetAll()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 2);
        }

        [Test]
        public void CanUpdate()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.IsTrue(repositoryManager.AccessGetDVDById(0).Director == "SomeOtherGuy");
            repositoryManager.AccessUpdateDVD(new DVD() { DVDTitle = "testADD", Director = "RobertSheran", RealeaseYear = 1993, Rating = "R", DVDNotes = "A Movie Made For Testing", DVDId = 0 });
            Assert.IsTrue(repositoryManager.AccessGetDVDById(0).Director == "RobertSheran");
        }

        [Test]
        public void CanDelete()
        {
            RepositoryManager repositoryManager = new RepositoryManager(new InMemoryRepository());
            Assert.IsNotNull(repositoryManager.AccessGetDVDById(2));
            repositoryManager.AccessDeleteDVD(2);
            Assert.IsNull(repositoryManager.AccessGetDVDById(2));
        }

    }
}
