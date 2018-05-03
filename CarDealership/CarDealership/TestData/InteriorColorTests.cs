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
    class InteriorColorTests
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

        public void CanAddInteriorColors()
        {
            var repo = new InteriorColorRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            repo.Add(new InteriorColors() { InteriorColorName = "Skin" });
            Assert.AreEqual(4, repo.GetAll().Count);

        }
        [Test]

        public void CanGetInteriorColors()
        {
            var repo = new InteriorColorRepository();
            Assert.AreEqual("NEON GREEN", repo.Get(1).InteriorColorName);

        }
        [Test]

        public void CanGetAllInteriorColors()
        {
            var repo = new InteriorColorRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
        }
        [Test]

        public void CanRemoveInteriorColors()
        {
            var repo = new InteriorColorRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            repo.Remove(1);
            Assert.AreEqual(2, repo.GetAll().Count);

        }
    }
}
