using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.TabelModels;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class SellerController : Controller
    {
        private RepositoryManager carsRepository = RepositoryManagerFactory.Create();

        // GET: Seller
        public ActionResult Index()
        {
            List<Cars> cars = carsRepository.GetAllCars().Carss.Where(c => c.Sold == false).ToList();
            
            List<DetailedCarViewModel> carViews = new List<DetailedCarViewModel>();
            foreach (var car in cars)
            {
                carViews.Add(new DetailedCarViewModel()
                {
                    Photo = car.Photo,
                    CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                    CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                    Price = car.SalesPrice,
                    Year = car.CarYear,
                    CarId = car.CarId,
                    CarType = carsRepository.GetCarType(car.CarTypeId).CarType.CarTypeName,
                    Color = carsRepository.GetColor(car.ColorId).Color.ColorName,
                    InteriorColor = carsRepository.GetInteriorColors(car.InteriorColorId).InteriorColor.InteriorColorName,
                    Mileage = car.Mileage,
                    MSRP = car.MSRP,
                    Transmission = carsRepository.GetTransmission(car.TransmissionId).Transmission.TransmissionName,
                    Vin = car.Vin,
                    BodyStyle = carsRepository.GetBodyStyle(car.BodyStyleId).BodyStyle.BodyStyleName
                });
            }
            return View(carViews);
        }

        public ActionResult Buy(int id)
        {
            Cars car = carsRepository.GetCars(id).Cars;
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel()
            {

                Car = new DetailedCarViewModel()
                {
                    Photo = car.Photo,
                    CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                    CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                    Price = car.SalesPrice,
                    Year = car.CarYear,
                    CarId = car.CarId,
                    CarType = carsRepository.GetCarType(car.CarTypeId).CarType.CarTypeName,
                    Color = carsRepository.GetColor(car.ColorId).Color.ColorName,
                    InteriorColor = carsRepository.GetInteriorColors(car.InteriorColorId).InteriorColor.InteriorColorName,
                    Mileage = car.Mileage,
                    MSRP = car.MSRP,
                    Transmission = carsRepository.GetTransmission(car.TransmissionId).Transmission.TransmissionName,
                    Vin = car.Vin,
                    Discription= car.Discription,
                    BodyStyle = carsRepository.GetBodyStyle(car.BodyStyleId).BodyStyle.BodyStyleName
                    
                },
                States = carsRepository.GetStates().MyProperty.Select(m => new SelectListItem
                {
                    Text = m.StateName,
                    Value = m.StateId.ToString()
                }),

                PaymentTypes = carsRepository.GetFinancings().Financings.Select(m => new SelectListItem
                {
                    Text = m.FinancingType,
                    Value = m.Id.ToString()
                }),
                CarId = id
                
            };
            
            return View(purchaseViewModel);
        }

        [HttpPost]
        public ActionResult Buy(PurchaseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Cars cars = carsRepository.GetCars(viewModel.CarId).Cars;
                cars.AspNetUserId = User.Identity.Name;
                cars.Photo = "Sold.jpg";
                carsRepository.EditCars(cars);
                carsRepository.Buy(viewModel);
                carsRepository.MarkSoldCars(viewModel.CarId);

                return RedirectToAction("Index");
            }
            else
            {
                Cars car = carsRepository.GetCars(viewModel.CarId).Cars;
                PurchaseViewModel purchaseViewModel = new PurchaseViewModel()
                {

                    Car = new DetailedCarViewModel()
                    {
                        Photo = car.Photo,
                        CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                        CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                        Price = car.SalesPrice,
                        Year = car.CarYear,
                        CarId = car.CarId,
                        CarType = carsRepository.GetCarType(car.CarTypeId).CarType.CarTypeName,
                        Color = carsRepository.GetColor(car.ColorId).Color.ColorName,
                        InteriorColor = carsRepository.GetInteriorColors(car.InteriorColorId).InteriorColor.InteriorColorName,
                        Mileage = car.Mileage,
                        MSRP = car.MSRP,
                        Transmission = carsRepository.GetTransmission(car.TransmissionId).Transmission.TransmissionName,
                        Vin = car.Vin,
                        Discription = car.Discription,
                        BodyStyle = carsRepository.GetBodyStyle(car.BodyStyleId).BodyStyle.BodyStyleName

                    },
                    States = carsRepository.GetStates().MyProperty.Select(m => new SelectListItem
                    {
                        Text = m.StateName,
                        Value = m.StateId.ToString()
                    }),

                    PaymentTypes = carsRepository.GetFinancings().Financings.Select(m => new SelectListItem
                    {
                        Text = m.FinancingType,
                        Value = m.Id.ToString()
                    }),
                    CarId = viewModel.CarId

                };

                return View(purchaseViewModel);
            }
                
        }

    }
}