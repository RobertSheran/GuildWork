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
    class ColorTests
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

        public void CanAddColor()
        {

            var repo = new ColorRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            repo.Add(new Color { ColorName = "Blue" });
            Assert.AreEqual(4, repo.GetAll().Count);
        }
        [Test]

        public void CanGetColor()
        {


            var repo = new ColorRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            Assert.AreEqual("BLACK", repo.Get(1).ColorName);
        }
        [Test]

        public void CanGetAllColor()
        {

            var repo = new ColorRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
        }

        [Test]
        public void CanRemoveColor()
        {

            var repo = new ColorRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            repo.Remove(1);
            Assert.AreEqual(2, repo.GetAll().Count);
        }
    }
}
