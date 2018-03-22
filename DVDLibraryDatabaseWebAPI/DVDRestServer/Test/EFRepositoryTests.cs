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
    public class EFRepositoryTests
    {
        public static void ResetDb()
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                            .ConnectionStrings["EFRepository"]
                            .ConnectionString;

                sqlConnection.Execute("ResetDbEF",
                    commandType: CommandType.StoredProcedure);
            }
        }
        [Test]
        public void EFCanGetByID()
        {
            ResetDb();
            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.AreEqual(repositoryManager.AccessGetDVDById(1).DVDTitle, "A Great Tale");
        }

        [Test]
        public void EFCanGetByTitle()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.AreEqual(repositoryManager.AccessDVDByTitle("A Great Tale").DVDTitle, "A Great Tale");
        }

        [Test]
        public void EFCanGetByDirector()
        {

            ResetDb();
            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByDirector("SomeOtherGuy").Count, 1);
        }

        [Test]
        public void EFCanGetByYear()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByReleaseYear(2015).Count, 1);
        }

        [Test]
        public void EFCanGetByRating()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.AreEqual(repositoryManager.AccessDVDsByRating("PG").Count, 1);
        }

        [Test]
        public void EFCanAdd()
        {
            ResetDb();


            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 2);
            repositoryManager.AccessAddDVD(new DVD() { DVDTitle = "testADD", Director = "YetAnotherGuy", RealeaseYear = 1993, Rating = "R", DVDNotes = "A Movie Made For Testing" });
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 3);
        }

        [Test]
        public void EFCanGetAll()
        {
            ResetDb();


            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.AreEqual(repositoryManager.AccessAllDVDs().Count, 2);
        }

        [Test]
        public void EFCanUpdate()
        {
            ResetDb();

            ResetDb();
            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.IsTrue(repositoryManager.AccessGetDVDById(1).Director == "SomeOtherGuy");
            repositoryManager.AccessUpdateDVD(new DVD() { DVDTitle = "testADD", Director = "RobertSheran", RealeaseYear = 1993, Rating = "R", DVDNotes = "A Movie Made For Testing", DVDId = 1 });
            Assert.IsTrue(repositoryManager.AccessGetDVDById(1).Director == "RobertSheran");
        }

        [Test]
        public void EFCanDelete()
        {
            ResetDb();

            RepositoryManager repositoryManager = new RepositoryManager(new EFRepository());
            Assert.IsNotNull(repositoryManager.AccessGetDVDById(2));
            repositoryManager.AccessDeleteDVD(2);
            Assert.IsNull(repositoryManager.AccessGetDVDById(2));
        }
    }
}
