using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        private RepositoryManager carsRepository = RepositoryManagerFactory.Create();
        public ActionResult Index()
        {
            List<Cars> cars = carsRepository.GetAllSpecialCars().Carss;
            
            List<CarViewModel> carViews = new List<CarViewModel>();
            foreach (var car in cars)
            {
                if (car.Sold)
                {
                    carViews.Add(new CarViewModel()
                    {
                        Photo = "Sold.jpg",
                        CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                        CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                        Price = car.SalesPrice,
                        Year = car.CarYear,
                        CarId = car.CarId

                    });
                }
                else
                {
                    carViews.Add(new CarViewModel()
                    {
                        Photo = car.Photo,
                        CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                        CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                        Price = car.SalesPrice,
                        Year = car.CarYear,
                        CarId = car.CarId

                    });
                }


            }
            return View(carViews);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            List<Special> specials = carsRepository.GetAllSpecialOffers().Specials;
            List<SpecialViewModel> specialsView = new List<SpecialViewModel>();
            foreach (var special in specials)
            {
                specialsView.Add(new SpecialViewModel()
                {
                    SpecialId = special.SpecialId,
                    SpecialMessage = special.SpecialMessage


                });
            }
            return View(specialsView);
        }

        [HttpGet]
        public ActionResult RemoveSpecial(int id)
        {
            var car = carsRepository.GetCars(id).Cars;
            car.Special = false;
            carsRepository.EditCars(car);
            return RedirectToAction("index");
        }


        public ActionResult Details(int id)
        {
            var car = carsRepository.GetCars(id).Cars;
            return View(new DetailedCarViewModel()
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
                Discription = car.Discription,
                Mileage = car.Mileage,
                MSRP = car.MSRP,
                Transmission = carsRepository.GetTransmission(car.TransmissionId).Transmission.TransmissionName,
                Vin = car.Vin,
                BodyStyle = carsRepository.GetBodyStyle(car.BodyStyleId).BodyStyle.BodyStyleName
            });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(int? id)
        {

            if (id.HasValue)
            {
                ContactFormViewModel viewModel = new ContactFormViewModel
                {
                    ContactMessage = carsRepository.GetCars(id.Value).Cars.Vin.ToString()
                };
                return View(viewModel);
            }
            return View();

        }

        [HttpPost]
        public ActionResult Contact(ContactFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact()
                {
                    ContactMessage = viewModel.ContactMessage,
                    ContactName = viewModel.ContactName,
                    Phone = viewModel.Phone,
                    Email = viewModel.Email
                };
                if (carsRepository.AddMessage(contact).Success)
                {
                    return RedirectToAction("index");
                }
                return RedirectToAction("Contact");
            }
            else
            {
                return View(viewModel);
            }
            

        }

        public ActionResult NewCars()
        {
            List<Cars> cars = carsRepository.GetAllNew().Carss;
            List<CarViewModel> carViews = new List<CarViewModel>();
            if (cars != null)
            {
                foreach (var car in cars)
                {
                    if (car.Sold)
                    {
                        carViews.Add(new CarViewModel()
                        {
                            Photo = "Sold.jpg",
                            CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                            CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                            Price = car.SalesPrice,
                            Year = car.CarYear,
                            CarId = car.CarId
                        });
                    }
                    else
                    {
                        carViews.Add(new CarViewModel()
                        {
                            Photo = car.Photo,
                            CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                            CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                            Price = car.SalesPrice,
                            Year = car.CarYear,
                            CarId = car.CarId
                        });
                    }

                }
                return View(carViews);
            }
            else return RedirectToAction("Index");
                    
        }
        public ActionResult UsedCars()
        {
            List<Cars> cars = carsRepository.GetAllUsed().Carss;
            List<CarViewModel> carViews = new List<CarViewModel>();
            if (cars != null)
            {
                foreach (var car in cars)
                {
                    if (car.Sold)
                    {
                        carViews.Add(new CarViewModel()
                        {
                            Photo = "Sold.jpg",
                            CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                            CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                            Price = car.SalesPrice,
                            Year = car.CarYear,
                            CarId = car.CarId
                        });
                    }
                    else
                    {
                        carViews.Add(new CarViewModel()
                        {
                            Photo = car.Photo,
                            CarModel = carsRepository.GetCarModel(car.CarModelId).CarModel.CarModelName,
                            CarMake = carsRepository.GetMake(carsRepository.GetCarModel(car.CarModelId).CarModel.MakeId).Make.MakeName,
                            Price = car.SalesPrice,
                            Year = car.CarYear,
                            CarId = car.CarId
                        });
                    }
                }
                return View(carViews);
            }
            else return RedirectToAction("Index");
            
        }

        public ActionResult CreateSpecial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSpecial(SpecialViewModel viewModel)
        {
            carsRepository.AddSpecialOffer(new Special()
            {
                SpecialMessage = viewModel.SpecialMessage
            });
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSpecialOffer(int id)
        {
            carsRepository.RemoveSpecialOffer(id);
            return RedirectToAction("Index");
        }
    }
}