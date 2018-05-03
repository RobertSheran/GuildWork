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
    public class CarModelTests
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
        public void CanAddCarModel()
        {
            var repo = new CarModelRepository();
            Assert.AreEqual(9, repo.GetAll().Count);
            repo.Add(new CarModel() { MakeId = 1, CarModelName = "Big" });
            Assert.AreEqual(10, repo.GetAll().Count);
        }
        [Test]

        public void CanGetCarModel()
        {
            var repo = new CarModelRepository();
            Assert.AreEqual("Liberty", repo.Get(1).CarModelName);
        }

        [Test]

        public void CanGetAllCarModel()
        {
            var repo = new CarModelRepository();
            Assert.AreEqual(9, repo.GetAll().Count);
        }
        [Test]

        public void CanRemoveCarModel()
        {
            var repo = new CarModelRepository();
            Assert.AreEqual(9, repo.GetAll().Count);
            repo.Remove(1);
            Assert.AreEqual(8, repo.GetAll().Count);
        }
    }
}
