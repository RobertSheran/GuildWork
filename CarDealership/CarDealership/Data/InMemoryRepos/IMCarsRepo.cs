using CarDealership.Models;
using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InMemoryRepos
{
    public class IMCarsRepo : ICarsRepository
    {
        List<Cars> Cars = new List<Cars>()
        {
            new Cars()
            {
                AspNetUserId=null,
                BodyStyleId =1,
                CarId =1,
                CarModelId =1,
                CarTypeId = 1,
                CarYear = 2000,
                ColorId =1,
                Discription = "IMCar 1",
                InteriorColorId = 1,
                Mileage = 2000,
                MSRP = 20000,
                Photo = "2012-Toyota-RAV4-SUV-Base-4dr-Front-wheel-Drive-Exterior-Front-Side-View.jpg",
                SalesPrice = 20000,
                Sold = false,
                Special = false,
                TransmissionId = 1,
                Vin = 354235
            },
            new Cars()
            {
                AspNetUserId=null,
                BodyStyleId =2,
                CarId =2,
                CarModelId =2,
                CarTypeId = 2,
                CarYear = 2000,
                ColorId =2,
                Discription = "IMCar 2",
                InteriorColorId = 2,
                Mileage = 2000,
                MSRP = 20000,
                Photo = "2012-Toyota-RAV4-SUV-Base-4dr-Front-wheel-Drive-Exterior-Front-Side-View.jpg",
                SalesPrice = 20000,
                Sold = false,
                Special = true,
                TransmissionId = 1,
                Vin = 5436454
            },
            new Cars()
            {
                AspNetUserId=null,
                BodyStyleId =3,
                CarId =3,
                CarModelId =5,
                CarTypeId = 2,
                CarYear = 2000,
                ColorId =1,
                Discription = "IMCar 3",
                InteriorColorId = 1,
                Mileage = 0,
                MSRP = 20000,
                Photo = "2012-Toyota-RAV4-SUV-Base-4dr-Front-wheel-Drive-Exterior-Front-Side-View.jpg",
                SalesPrice = 20000,
                Sold = false,
                Special = false,
                TransmissionId = 1,
                Vin = 5346546
            }
        };

        List<Financing> financings = new List<Financing>()
        {
            new Financing()
            {
                FinancingType = "f1",
                Id = 1
            },
            new Financing()
            {
                FinancingType = "f2",
                Id = 2
            },
            new Financing()
            {
                FinancingType = "f3",
                Id = 3
            },
        };

        List<Invoice> invoices = new List<Invoice>()
        {
            new Invoice()
            {
                City = "MPLS",
                StreetOne = "123 main st",
                ZipCode = "55555",
                Email = "at@at.com",
                InvoiceId = 1,
                InvoiceName = "test",
                StreetTwo = null,
                InvoiceState = "mn",
                PerchaseType = "f1",
                Phone = "9999999999",
                Price = 20000
            }
        };

        List<Contact> contacts = new List<Contact>()
        {
            new Contact()
            {
                ContactId = 1,
                ContactMessage = "hey",
                ContactName = "Bob",
                Email = "at@at.com",
                Phone = "9999999999"
            }
        };
        List<State> states = new List<State>()
        {
            new State()
            {
                StateId = 1,
                StateName = "Minnesota"
            }
        };


        public void Add(Cars car)
        {
            Cars.Add(car);
        }

        public void AddFinancing(string financing)
        {
            Financing fin = new Financing()
            {
                Id = financings.Max(c => c.Id) + 1,
                FinancingType = financing
            };
            financings.Add(fin);

        }

        public void AddInvoice(Invoice invoice)
        {
            invoices.Add(invoice);
        }

        public void AddMessage(Contact contact)
        {
            contacts.Add(contact);
        }

        public void AddState(State state)
        {
            states.Add(state);
        }

        public void Edit(Cars car)
        {
            Cars.Remove(Cars.Where(c => c.CarId == car.CarId).FirstOrDefault());
            Cars.Add(car);
        }

        public Cars Get(int id)
        {
            return Cars.Where(c => c.CarId == id).FirstOrDefault();
        }

        public List<Cars> GetAll()
        {
            return Cars;
        }

        public List<Contact> GetAllMessages()
        {
            return contacts;
        }

        public List<Cars> GetAllNew()
        {
            return Cars.Where(c => c.CarTypeId == 2).ToList();
        }

        public List<Cars> GetAllSold()
        {
            return Cars.Where(c => c.Sold == true).ToList();

        }

        public List<Cars> GetAllSpecial()
        {
            return Cars.Where(c => c.Special == true).ToList();
        }

        public List<Cars> GetAllUsed()
        {
            return Cars.Where(c => c.CarTypeId == 2).ToList();
        }

        public List<Cars> GetByMake(int id)
        {
            IMCarModelRepo carModelRepository = new IMCarModelRepo();
            return Cars.Where(c => c.CarModelId== carModelRepository.GetAll().Where(n=>n.MakeId==id).FirstOrDefault().MakeId).ToList();
        }

        public List<Cars> GetByModel(int id)
        {
            return Cars.Where(c => c.CarModelId == id).ToList();
        }

        public List<Cars> GetByPrice(int low, int high)
        {
            return Cars.Where(c => c.SalesPrice > low && c.SalesPrice < high).ToList();

        }

        public List<Cars> GetByYear(int year)
        {
           return Cars.Where(c => c.CarYear == year).ToList();
        }

        public List<Financing> GetFinancing()
        {
            return financings;
        }

        public List<State> GetStates()
        {
            return states;
        }

        public void MarkSold(int id)
        {
            var car = Cars.Where(c => c.CarId == id).FirstOrDefault();
            car.Sold = true;
            Edit(car);
        }

        public void MarkSpecial(int id)
        {
            var car = Cars.Where(c => c.CarId == id).FirstOrDefault();
            car.Special = true;
            Edit(car);
        }

        public void Remove(int id)
        {
            var car = Cars.Where(c => c.CarId == id).FirstOrDefault();
            Cars.Remove(car);
        }

        public void RemoveMessage(int id)
        {
            contacts.Remove(contacts.Where(c=>c.ContactId==id).FirstOrDefault());

        }

        public IEnumerable<ShortCar> Search(ListingSearchPerameters perameters)
        {
            List<Cars> shortCars = Cars;
            if (perameters.MaxYear != null)
            {
                shortCars = shortCars.Where(c => c.CarYear < perameters.MaxYear).ToList();
            }
            if (perameters.MinYear != null)
            {
                shortCars = shortCars.Where(c => c.CarYear > perameters.MinYear).ToList();
            }
            if (perameters.MinPrice != null)
            {
                shortCars = shortCars.Where(c => c.SalesPrice > perameters.MinPrice).ToList();
            }
            if (perameters.MaxPrice != null)
            {
                shortCars = shortCars.Where(c => c.SalesPrice < perameters.MaxPrice).ToList();
            }
            IMCarModelRepo carModelRepository = new IMCarModelRepo();
            int modelID = carModelRepository.GetAll().Where(c => perameters.MakeModel == c.CarModelName).FirstOrDefault().CarModelId;
            IMMakeRepo carMakeRepo = new IMMakeRepo();
            int makeID = carMakeRepo.GetAll().Where(c => perameters.MakeModel == c.MakeName).FirstOrDefault().MakeId;
            IMMakeRepo makeRepo = new IMMakeRepo();
            if (perameters.MakeModel != null)
            {
                shortCars = shortCars.Where(c => c.CarModelId == modelID || makeRepo.GetAll().Where(m => m.MakeId == makeID).FirstOrDefault().MakeName == perameters.MakeModel).ToList();
            }
            List<ShortCar> toReturn = new List<ShortCar>();
            foreach(var car in shortCars)
            {
                toReturn.Add(new ShortCar()
                {
                    CarId = car.CarId,
                    CarModel = carModelRepository.GetAll().Where(c => c.CarModelId == car.CarModelId).FirstOrDefault().CarModelName,
                    CarMake = carMakeRepo.Get(carModelRepository.GetAll().Where(c => c.CarModelId == car.CarModelId).FirstOrDefault().MakeId).MakeName,
                    Photo = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().Photo,
                    Price = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().SalesPrice,
                    Year = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().CarYear,
                });
            }
            return toReturn;

        }

        public IEnumerable<ShortCar> SearchNew(ListingSearchPerameters perameters)
        {
            List<Cars> shortCars = Cars.Where(c=>c.CarTypeId == 2).ToList();
            if (perameters.MaxYear != null)
            {
                shortCars = shortCars.Where(c => c.CarYear < perameters.MaxYear).ToList();
            }
            if (perameters.MinYear != null)
            {
                shortCars = shortCars.Where(c => c.CarYear > perameters.MinYear).ToList();
            }
            if (perameters.MinPrice != null)
            {
                shortCars = shortCars.Where(c => c.SalesPrice > perameters.MinPrice).ToList();
            }
            if (perameters.MaxPrice != null)
            {
                shortCars = shortCars.Where(c => c.SalesPrice < perameters.MaxPrice).ToList();
            }
            IMCarModelRepo carModelRepository = new IMCarModelRepo();
            int modelID = carModelRepository.GetAll().Where(c => perameters.MakeModel == c.CarModelName).FirstOrDefault().CarModelId;
            IMMakeRepo carMakeRepo = new IMMakeRepo();
            int makeID = carMakeRepo.GetAll().Where(c => perameters.MakeModel == c.MakeName).FirstOrDefault().MakeId;
            IMMakeRepo makeRepo = new IMMakeRepo();
            if (perameters.MakeModel != null)
            {
                shortCars = shortCars.Where(c => c.CarModelId == modelID || makeRepo.GetAll().Where(m => m.MakeId == makeID).FirstOrDefault().MakeName == perameters.MakeModel).ToList();
            }
            List<ShortCar> toReturn = new List<ShortCar>();
            foreach (var car in shortCars)
            {
                toReturn.Add(new ShortCar()
                {
                    CarId = car.CarId,
                    CarModel = carModelRepository.GetAll().Where(c => c.CarModelId == car.CarModelId).FirstOrDefault().CarModelName,
                    CarMake = carMakeRepo.Get(carModelRepository.GetAll().Where(c => c.CarModelId == car.CarModelId).FirstOrDefault().MakeId).MakeName,
                    Photo = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().Photo,
                    Price = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().SalesPrice,
                    Year = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().CarYear,
                });
            }
            return toReturn;

        }

        public IEnumerable<ShortCar> SearchUsed(ListingSearchPerameters perameters)
        {
            List<Cars> shortCars = Cars.Where(c => c.CarTypeId == 1).ToList();
            if (perameters.MaxYear != null)
            {
                shortCars = shortCars.Where(c => c.CarYear < perameters.MaxYear).ToList();
            }
            if (perameters.MinYear != null)
            {
                shortCars = shortCars.Where(c => c.CarYear > perameters.MinYear).ToList();
            }
            if (perameters.MinPrice != null)
            {
                shortCars = shortCars.Where(c => c.SalesPrice > perameters.MinPrice).ToList();
            }
            if (perameters.MaxPrice != null)
            {
                shortCars = shortCars.Where(c => c.SalesPrice < perameters.MaxPrice).ToList();
            }
            IMCarModelRepo carModelRepository = new IMCarModelRepo();
            int modelID = carModelRepository.GetAll().Where(c => perameters.MakeModel == c.CarModelName).FirstOrDefault().CarModelId;
            IMMakeRepo carMakeRepo = new IMMakeRepo();
            int makeID = carMakeRepo.GetAll().Where(c => perameters.MakeModel == c.MakeName).FirstOrDefault().MakeId;
            IMMakeRepo makeRepo = new IMMakeRepo();
            if (perameters.MakeModel != null)
            {
                shortCars = shortCars.Where(c => c.CarModelId == modelID || makeRepo.GetAll().Where(m => m.MakeId == makeID).FirstOrDefault().MakeName == perameters.MakeModel).ToList();
            }
            List<ShortCar> toReturn = new List<ShortCar>();
            foreach (var car in shortCars)
            {
                toReturn.Add(new ShortCar()
                {
                    CarId = car.CarId,
                    CarModel = carModelRepository.GetAll().Where(c => c.CarModelId == car.CarModelId).FirstOrDefault().CarModelName,
                    CarMake = carMakeRepo.Get(carModelRepository.GetAll().Where(c => c.CarModelId == car.CarModelId).FirstOrDefault().MakeId).MakeName,
                    Photo = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().Photo,
                    Price = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().SalesPrice,
                    Year = Cars.Where(c => c.CarId == car.CarId).FirstOrDefault().CarYear,
                });
            }
            return toReturn;
        }
    }
}
