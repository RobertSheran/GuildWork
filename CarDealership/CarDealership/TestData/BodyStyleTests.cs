using CarDealership.Models.TabelModels;
using Dapper;
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
    public class BodyStyleTests
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
        public void CanAddBodyStyle()
        {
            BodyStyleRepository repo = new BodyStyleRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            repo.Add(new BodyStyle { BodyStyleName = "Big" });
            Assert.AreEqual(4, repo.GetAll().Count);
        }

        [Test]
        public void CanGetBodyStyle()
        {
            BodyStyleRepository repo = new BodyStyleRepository();
            Assert.AreEqual("Space Wagon", repo.Get(1).BodyStyleName);
        }


        [Test]
        public void CanGetAllBodyStyle()
        {
            BodyStyleRepository repo = new BodyStyleRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            Assert.AreEqual("Space Wagon", repo.GetAll().FirstOrDefault().BodyStyleName);
        }

        [Test]
        public void CanRemoveBodyStyle()
        {
            BodyStyleRepository repo = new BodyStyleRepository();
            Assert.AreEqual(3, repo.GetAll().Count);
            repo.Remove(1);
            Assert.AreEqual(2, repo.GetAll().Count);
            Assert.IsFalse(repo.GetAll().Any(bs=>bs.BodyStyleId==1));
        }

    }
}
