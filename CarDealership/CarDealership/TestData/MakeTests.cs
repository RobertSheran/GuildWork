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
    class MakeTests
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

        public void CanAddMake()
        {
            var repo = new MakeRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            repo.Add(new Make() { MakeName = "Big" });
            Assert.AreEqual(4, repo.GetAll().Count);

        }

        [Test]

        public void CanGetMake()
        {
            var repo = new MakeRepository();
            Assert.AreEqual("Jeep", repo.Get(1).MakeName);
        }
        [Test]

        public void CanGetAllMake()
        {
            var repo = new MakeRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
        }
        [Test]

        public void CanRemoveMake()
        {
            var repo = new MakeRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            repo.Remove(1);
            Assert.AreEqual(2, repo.GetAll().Count);


        }
    }
}
