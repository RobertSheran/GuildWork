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
    class CarTypeTests
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
        public void CanAddCarType()
        {
            
            var repo = new CarTypeRepository();
            Assert.AreEqual(2,repo.GetAll().Count);
            repo.Add(new CarType() { CarTypeName = "Restored" });
            Assert.AreEqual(3, repo.GetAll().Count);
        }

        [Test]
        public void CanGetCarType()
        {
            
            CarTypeRepository repo = new CarTypeRepository();
            Assert.AreEqual("Used",repo.Get(1).CarTypeName);
        }

        [Test]
        public void CanGetAllCarType()
        {
            
            var repo = new CarTypeRepository();
            Assert.AreEqual(2, repo.GetAll().Count);
            Assert.AreEqual("Used", repo.GetAll().FirstOrDefault().CarTypeName);
        }

        [Test]
        public void CanRemoveCarType()
        {
            
            var repo = new CarTypeRepository();
            Assert.AreEqual(2, repo.GetAll().Count);
            repo.Remove(1);
            Assert.AreEqual(1, repo.GetAll().Count);
        }
    }
}
