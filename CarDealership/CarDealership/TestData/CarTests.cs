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
    class CarTests
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
        public void CanSearch()
        {
            
            var repo = new CarsRepository();
            var found = repo.Search(new CarDealership.Models.ListingSearchPerameters { MinPrice = 20000 });
            Assert.AreEqual(2, found.Count());
            found = repo.Search(new CarDealership.Models.ListingSearchPerameters { MakeModel = "Jeep" });
            Assert.AreEqual(2, found.Count());
            found = repo.Search(new CarDealership.Models.ListingSearchPerameters { MakeModel = "Ford" });
            Assert.AreEqual(0, found.Count());

        }

        [Test]
        public void CanGetAllDeal()
        {
            
            var repo = new CarModelRepository();
            Assert.AreEqual(3, repo.GetSpecialOffers().Count);
        }



        [Test]
        public void CanRemoveDeal()
        {
            
           
            var repo = new CarModelRepository();
            Assert.AreEqual(3, repo.GetSpecialOffers().Count);
            repo.RemoveDeal(repo.GetSpecialOffers().FirstOrDefault().SpecialId);
            Assert.AreEqual(2, repo.GetSpecialOffers().Count);

        }

        [Test]
        public void CanAddDeal()
        {
            
            var repo = new CarModelRepository();
            Assert.AreEqual(3, repo.GetSpecialOffers().Count);
            repo.AddDeal(new Special() { SpecialMessage = "gogog"});
            Assert.AreEqual(4, repo.GetSpecialOffers().Count);
        }




        [Test]

        public void CanAddCars()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(6, repo.GetAll().Count);
            repo.Add(new Cars() { AspNetUserId = "Seller@Seller.com", BodyStyleId = 1, CarModelId = 1, CarTypeId = 1, CarYear = 1992, ColorId = 1, Discription = "Good car", InteriorColorId = 1, Mileage = 20000, MSRP = 2, SalesPrice = 20000, Special = true, TransmissionId = 1, Vin = 8 });
            Assert.AreEqual(7, repo.GetAll().Count);
        }

        [Test]
        public void CanEditCars()
        {
            
            var repo = new CarsRepository();
            repo.Edit(new Cars() { CarId = 1, AspNetUserId = "Seller@Seller.com", BodyStyleId = 1, CarModelId = 1, CarTypeId = 1, ColorId = 1, InteriorColorId = 1, Discription = "test", Photo = "Go", SalesPrice = 100, TransmissionId = 1, Special = false, Vin = 1, MSRP = 1, Mileage = 1, CarYear = 1992 });
            Assert.AreEqual("Seller@Seller.com", repo.Get(1).AspNetUserId);
        }
        [Test]
        public void CanGetCar()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(2, repo.Get(2).CarId);
        }

        [Test]

        public void CanGetAllCars()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(6, repo.GetAll().Count);
        }

        [Test]
        public void CanGetByMake()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(2, repo.GetByMake(1).Count);
            
        }
        [Test]

        public void CanGetByModel()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(2, repo.GetByModel(1).Count);
        }
        [Test]

        public void CanGetByPrice()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(4, repo.GetByPrice(1000,25000).Count);
        }

        [Test]
        public void CanBuy()
        {
            
            var repo = new CarsRepository();
            repo.AddInvoice(new Invoice() { City="My",Email="some",StreetOne="go",StreetTwo="go",InvoiceState="Mn",InvoiceName="bob",PerchaseType="yellow",Phone="9999999999",Price=99999,ZipCode="55555"});
        }


        [Test]
        public void CanGetFinancing()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(3, repo.GetFinancing().Count);
        }
        [Test]
        public void CanAddFinancing()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(3, repo.GetFinancing().Count);
            repo.AddFinancing("Tulips");
            Assert.AreEqual(4, repo.GetFinancing().Count);
        }

        [Test]
        public void CanGetStates()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(3, repo.GetStates().Count);
        }

        [Test]
        public void CanAddStates()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(3, repo.GetStates().Count);
            repo.AddState(new State() { StateName = "bob" });
            Assert.AreEqual(4, repo.GetStates().Count);
        }

        [Test]
        public void CanGetByYear()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(2, repo.GetByYear(1993).Count);
        }
        [Test]

        public void CanMarkSold()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(0,repo.GetAllSold().Count);
            repo.MarkSold(1);
            Assert.AreEqual(1, repo.GetAllSold().Count);

        }
        [Test]

        public void CanMarkSpecial()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(6, repo.GetAllSpecial().Count);
            repo.MarkSpecial(2);
            Assert.AreEqual(6, repo.GetAllSpecial().Count);


        }


        [Test]


        public void CanRemoveCar()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(6, repo.GetAll().Count);
            repo.Remove(1);
            Assert.AreEqual(5, repo.GetAll().Count);
        }

        [Test]
        public void CanGetAllSpecial()
        {        
            
            var repo = new CarsRepository();
            Assert.AreEqual(6, repo.GetAllSpecial().Count);
        }

        [Test]
        public void CanGetAllSold()
        {
            
            var repo = new CarsRepository();
            Assert.AreEqual(0, repo.GetAllSold().Count);
        }
    }
}
