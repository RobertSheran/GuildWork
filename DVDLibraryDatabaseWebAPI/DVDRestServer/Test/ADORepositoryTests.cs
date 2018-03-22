using Dapper;
using Data;
using DVDDatabaseModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class ADORepositoryTests
    {
        public static void ResetDb()
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                            .ConnectionStrings["MovieDb"]
                            .ConnectionString;

                sqlConnection.Execute("ResetDb",
                    commandType: CommandType.StoredProcedure);
            }
        }
        [Test]
        public void ADOCanGetByID()
        {
            ResetDb();
            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.AreEqual(repositoryManager.AccessGetDVDById(1).DVDTitle, "A Great Tale");
        }

        [Test]
        public void ADOCanGetByTitle()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.AreEqual(repositoryManager.AccessDVDByTitle("A Great Tale").DVDTitle, "A Great Tale");
        }

        [Test]
        public void ADOCanGetByDirector()
        {
            ResetDb();
            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByDirector("SomeOtherGuy").Count, 1);
        }

        [Test]
        public void ADOCanGetByYear()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByReleaseYear(2015).Count, 1);
        }

        [Test]
        public void ADOCanGetByRating()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByRating("PG").Count, 1);
        }

        [Test]
        public void ADOCanAdd()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 2);
            repositoryManager.AccessAddDVD(new DVD() { DVDTitle = "testADD", Director = "YetAnotherGuy", RealeaseYear = 1993, Rating = "R", DVDNotes = "A Movie Made For Testing"});
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 3);
        }

        [Test]
        public void ADOCanGetAll()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 2);
        }

        [Test]
        public void ADOCanUpdate()
        {
            ResetDb();
            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.IsTrue(repositoryManager.AccessGetDVDById(1).Director == "SomeOtherGuy");
            repositoryManager.AccessUpdateDVD(new DVD() { DVDTitle = "testADD", Director = "RobertSheran", RealeaseYear = 1993, Rating = "R", DVDNotes = "A Movie Made For Testing", DVDId = 1 });
            Assert.IsTrue(repositoryManager.AccessGetDVDById(1).Director == "RobertSheran");
        }

        [Test]
        public void ADOCanDelete()
        {
            ResetDb();
            RepositoryManager repositoryManager = new RepositoryManager(new ADORepository());
            Assert.IsNotNull(repositoryManager.AccessGetDVDById(2));
            repositoryManager.AccessDeleteDVD(2);
            Assert.IsNull(repositoryManager.AccessGetDVDById(2));
        }
    }
}
