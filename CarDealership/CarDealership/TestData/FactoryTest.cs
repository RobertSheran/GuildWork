using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
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
    public class FactoryTest
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
        public void ADOFactoryTest()
        {
            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            Assert.IsTrue(repositoryManager.GetAllCars().Carss.Count == 6);
        }
    }
}
