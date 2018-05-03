using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    [TestFixture]
    class TransmissionTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "SetUpTestValues";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        [Test]

        public void CanGetUsed()
        {
           
            var repo = new CarsRepository();
            Assert.AreEqual(repo.GetAllUsed().Count, 4);

        }

        [Test]
        public void CanGetAllMessages()
        {
           
            var repo = new CarsRepository();
            Assert.AreEqual(repo.GetAllMessages().Count, 3);
        }

        [Test]
        public void CanRemoveMessage()
        {
           
            var repo = new CarsRepository();
            Assert.AreEqual(repo.GetAllMessages().Count, 3);
            repo.RemoveMessage(1);
            Assert.AreEqual(repo.GetAllMessages().Count, 2);

        }

        [Test]
        public void CanAddMessage()
        {
           
            var repo = new CarsRepository();
            Assert.AreEqual(repo.GetAllMessages().Count, 3);
            repo.AddMessage(new Contact() { ContactMessage = "this", ContactName = "bob", Email = "Bob@bob.com", Phone = "999-999-9999" });
            Assert.AreEqual(repo.GetAllMessages().Count, 4);
        }

        [Test]

        public void CanGetNew()
        {
           
            var repo = new CarsRepository();
            Assert.AreEqual(repo.GetAllNew().Count, 2);

        }
        [Test]

        public void CanAddTransmission()
        {
           
            var repo = new TransmissionRepository();
            Assert.AreEqual(4, repo.GetAll().Count);
            repo.Add(new Transmission() { TransmissionName = "Fire" });
            Assert.AreEqual(5, repo.GetAll().Count);

        }
        [Test]

        public void CanGetTransmission()
        {
           
            var repo = new TransmissionRepository();
            Assert.AreEqual("Manual Transmission", repo.Get(1).TransmissionName);
        }

        [Test]
        public void CanGetAllTransmission()
        {
           
            var repo = new TransmissionRepository();
            Assert.AreEqual(4, repo.GetAll().Count);
        }
        [Test]

        public void CanRemoveTransmission()
        {
           
            var repo = new TransmissionRepository();
            Assert.AreEqual(4, repo.GetAll().Count);
            repo.Remove(1);
            Assert.AreEqual(3, repo.GetAll().Count);
        }
    }
}
