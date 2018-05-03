using CarDealership.Models;
using CarDealership.Models.IRepositories;
using CarDealership.Models.Responses;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class RepositoryManager: IRepositoryManager
    {
        private ITransmissionRepository transmissionRepository;
        private IMakeRepository makeRepository;
        private IInteriorColorRepository interiorColorRepository;
        private ICarTypeRepository carTypeRepository;
        private ICarsRepository carsRepository;
        private ICarModelRepository carModelRepository;
        private IBodyStyleRepository bodyStyleRepository;
        private IColorRepository colorRepository;


        public RepositoryManager(IColorRepository colorRepository,IBodyStyleRepository bodyStyleRepository,ICarModelRepository carModelRepository,ICarsRepository carsRepository,ICarTypeRepository carTypeRepository,IInteriorColorRepository interiorColorRepository,IMakeRepository makeRepository,ITransmissionRepository transmissionRepository)
        {
            this.transmissionRepository= transmissionRepository;
            this.makeRepository= makeRepository;
            this.interiorColorRepository=interiorColorRepository;
            this.carTypeRepository=carTypeRepository;
            this.carsRepository = carsRepository;
            this.carModelRepository = carModelRepository;
            this.bodyStyleRepository = bodyStyleRepository;
            this.colorRepository = colorRepository;
        }



        public Response AddTransmission(Transmission transmission)
        {
            Response response = new Response();
            if (transmissionRepository.GetAll().Any(t => t.TransmissionName == transmission.TransmissionName))
            {
                response.Success = false;
                response.Message = "ERROR: transmission name already exists";              
            }
            else
            {
                transmissionRepository.Add(transmission);
                response.Success = true;
                response.Message = "transmission added";
            }
            return response;
        }

        public IEnumerable<ShortCar> Search(ListingSearchPerameters perameters)
        {
            return carsRepository.Search(perameters);
        }

        public IEnumerable<ShortCar> SearchNew(ListingSearchPerameters perameters)
        {
            return carsRepository.SearchNew(perameters);
        }

        public IEnumerable<ShortCar> SearchUsed(ListingSearchPerameters perameters)
        {
            return carsRepository.SearchUsed(perameters);
        }

        public ResponseStates GetStates()
        {
            ResponseStates response = new ResponseStates();

            response.MyProperty = carsRepository.GetStates();
            response.Success = true;
            response.Message = "states got";
            
            return response;
        }

        public Response AddState(State state)
        {
            Response response = new Response();
            if (carsRepository.GetStates().Any(s => s.StateName == state.StateName))
            {
                response.Success = false;
                response.Message = "ERROR: state exists";
                return response;

            }
            carsRepository.AddState(state);
            response.Success = true;
            response.Message = "state added";
            return response;
        }

        public Response AddFinancing(string financing)
        {
            Response response = new Response();
            if (carsRepository.GetFinancing().Any(n => n.FinancingType == financing))
            {
                response.Success = false;
                response.Message = "ERROR: Financing Type Exists";
            }
            else
            {
                carsRepository.AddFinancing(financing);
                response.Success = true;
                response.Message = "Success";
            }
            return response;
        }

        public ResponseFinancings GetFinancings()
        {
            ResponseFinancings response = new ResponseFinancings();
            if(carsRepository.GetFinancing() == null)
            {
                response.Success = false;
                response.Message = "no financing found";

            }
            else
            {
                response.Financings=carsRepository.GetFinancing();
                response.Message = "success";
                response.Success = true;
            }
            return response;
        }


        public Response Buy(Invoice invoice)
        {
            Response response = new Response();
            if (invoice.Email == null && invoice.InvoiceName == null)
            {
                response.Success = false;
                response.Message = "ERROR: invoice must have email or name";
                return response;

            }
            carsRepository.AddInvoice(invoice);
            response.Success = true;
            response.Message = "invoice added";
            return response;
        }



        public ResponseTransmission GetTransmission(int id)
        {
            ResponseTransmission responseTransmission = new ResponseTransmission();
            if (transmissionRepository.GetAll().FirstOrDefault() == null)
            {
                responseTransmission.Success = false;
                responseTransmission.Message = "ERROR: no transmissions found";
            }
            else if (!transmissionRepository.GetAll().Any(t => t.TransmissionId == id))
            {
                responseTransmission.Success = false;
                responseTransmission.Message = "ERROR: no transmissions found with id="+id;
            }
            else
            {
                responseTransmission.Transmission= transmissionRepository.Get(id);
                responseTransmission.Success = true;
                responseTransmission.Message = "transmission found";
            }
            return responseTransmission;
        }

        public ResponseTransmissions GetAllTransmission()
        {
            ResponseTransmissions responseTransmissions = new ResponseTransmissions();
            if (transmissionRepository.GetAll().FirstOrDefault() == null)
            {
                responseTransmissions.Success = false;
                responseTransmissions.Message = "ERROR: no transmissions found";
            }
            else
            {
                responseTransmissions.Transmissions = transmissionRepository.GetAll();
                responseTransmissions.Success = true;
                responseTransmissions.Message = "transmissions found";
            }
            return responseTransmissions;
        }

        public Response RemoveTransmission(int id)
        {
            Response response = new Response();
            if (transmissionRepository.GetAll().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no transmissions found";
            }

            else if (transmissionRepository.GetAll().All(t => t.TransmissionId != id))
            {
                response.Success = false;
                response.Message="ERROR: no transmissions found with id=" + id;
            }
            else
            {
                transmissionRepository.Remove(id);
                response.Success = true;
                response.Message = "transmission removed";
            }
            return response;
        }

        public Response AddMake(Make make)
        {
            Response response = new Response();
            if (makeRepository.GetAll().Any(t => t.MakeName == make.MakeName))
            {
                response.Success = false;
                response.Message = "ERROR: make name already exists";
            }
            else
            {
                makeRepository.Add(make);
                response.Success = true;
                response.Message = "make added";
            }
            return response;
        }

        public Response RemoveMake(int id)
        {
            Response response = new Response();
            if (makeRepository.GetAll().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no makes found";
            }

            else if (makeRepository.GetAll().All(t => t.MakeId != id))
            {
                response.Success = false;
                response.Message = "ERROR: no makes found with id=" + id;
            }
            else
            {
                makeRepository.Remove(id);
                response.Success = true;
                response.Message = "make removed";
            }
            return response;
        }

        public ResponseMakes GetAllMake()
        {
            ResponseMakes responseMakes = new ResponseMakes();
            if (transmissionRepository.GetAll().FirstOrDefault() == null)
            {
                responseMakes.Success = false;
                responseMakes.Message = "ERROR: no makes found";
            }
            else
            {
                responseMakes.Makes = makeRepository.GetAll();
                responseMakes.Success = true;
                responseMakes.Message = "makes found";
            }
            return responseMakes;
        }

        public ResponseMake GetMake(int id)
        {
            ResponseMake responseMake = new ResponseMake();
            if (makeRepository.GetAll().FirstOrDefault() == null)
            {
                responseMake.Success = false;
                responseMake.Message = "ERROR: no make found";
            }
            else if (!makeRepository.GetAll().Any(t => t.MakeId == id))
            {
                responseMake.Success = false;
                responseMake.Message = "ERROR: no make found with id=" + id;
            }
            else
            {
                responseMake.Make = makeRepository.Get(id);
                responseMake.Success = true;
                responseMake.Message = "make found";
            }
            return responseMake;
        }

        public Response AddInteriorColors(InteriorColors interiorColor)
        {
            Response response = new Response();
            if (interiorColorRepository.GetAll().Any(t => t.InteriorColorName == interiorColor.InteriorColorName))
            {
                response.Success = false;
                response.Message = "ERROR: InteriorColor name already exists";
            }
            else
            {
                interiorColorRepository.Add(interiorColor);
                response.Success = true;
                response.Message = "InteriorColor added";
            }
            return response;
        }

        public Response RemoveInteriorColors(int id)
        {
            Response response = new Response();
            if (interiorColorRepository.GetAll().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no InteriorColors found";
            }

            else if (interiorColorRepository.GetAll().All(t => t.InteriorColorId != id))
            {
                response.Success = false;
                response.Message = "ERROR: no InteriorColors found with id=" + id;
            }
            else
            {
                interiorColorRepository.Remove(id);
                response.Success = true;
                response.Message = "InteriorColors removed";
            }
            return response;
        }

        public ResponseInteriorColorss GetAllInteriorColors()
        {
            ResponseInteriorColorss responseInteriorColorss = new ResponseInteriorColorss();
            if (interiorColorRepository.GetAll().FirstOrDefault() == null)
            {
                responseInteriorColorss.Success = false;
                responseInteriorColorss.Message = "ERROR: no InteriorColors found";
            }
            else
            {
                responseInteriorColorss.InteriorColorss = interiorColorRepository.GetAll();
                responseInteriorColorss.Success = true;
                responseInteriorColorss.Message = "InteriorColors found";
            }
            return responseInteriorColorss;
        }

        public ResponseInteriorColors GetInteriorColors(int id)
        {
            ResponseInteriorColors responseInteriorColors = new ResponseInteriorColors();
            if (interiorColorRepository.GetAll().FirstOrDefault() == null)
            {
                responseInteriorColors.Success = false;
                responseInteriorColors.Message = "ERROR: no InteriorColors found";
            }
            else if (!interiorColorRepository.GetAll().Any(t => t.InteriorColorId == id))
            {
                responseInteriorColors.Success = false;
                responseInteriorColors.Message = "ERROR: no InteriorColors found with id=" + id;
            }
            else
            {
                responseInteriorColors.InteriorColor = interiorColorRepository.Get(id);
                responseInteriorColors.Success = true;
                responseInteriorColors.Message = "InteriorColor found";
            }
            return responseInteriorColors;
        }

        public Response AddCarType(CarType carType)
        {
            Response response = new Response();
            if (carTypeRepository.GetAll().Any(t => t.CarTypeName == carType.CarTypeName))
            {
                response.Success = false;
                response.Message = "ERROR: CarType name already exists";
            }
            else
            {
                carTypeRepository.Add(carType);
                response.Success = true;
                response.Message = "CarType added";
            }
            return response;
        }

        public Response RemoveCarType(int id)
        {
            Response response = new Response();
            if (carTypeRepository.GetAll().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no TypeRepository found";
            }

            else if (carTypeRepository.GetAll().All(t => t.CarTypeId != id))
            {
                response.Success = false;
                response.Message = "ERROR: no TypeRepository found with id=" + id;
            }
            else
            {
                carTypeRepository.Remove(id);
                response.Success = true;
                response.Message = "TypeRepository removed";
            }
            return response;
        }

        public ResponseCarTypes GetAllCarType()
        {
            ResponseCarTypes responseCarTypes = new ResponseCarTypes();
            if (carTypeRepository.GetAll().FirstOrDefault() == null)
            {
                responseCarTypes.Success = false;
                responseCarTypes.Message = "ERROR: no CarTypes found";
            }
            else
            {
                responseCarTypes.CarTypes = carTypeRepository.GetAll();
                responseCarTypes.Success = true;
                responseCarTypes.Message = "CarTypes found";
            }
            return responseCarTypes;
        }

        public ResponseCarType GetCarType(int id)
        {
            ResponseCarType responseCarType = new ResponseCarType();
            if (carTypeRepository.GetAll().FirstOrDefault() == null)
            {
                responseCarType.Success = false;
                responseCarType.Message = "ERROR: no CarType found";
            }
            else if (!carTypeRepository.GetAll().Any(t => t.CarTypeId == id))
            {
                responseCarType.Success = false;
                responseCarType.Message = "ERROR: no CarType found with id=" + id;
            }
            else
            {
                responseCarType.CarType = carTypeRepository.Get(id);
                responseCarType.Success = true;
                responseCarType.Message = "CarType found";
            }
            return responseCarType;
        }

        public Response AddCars(Cars car)
        {
            Response response = new Response();
            if (carsRepository.GetAll().Any(t => t.Vin == car.Vin))
            {
                response.Success = false;
                response.Message = "ERROR: Vin already exists";
            }
            if (bodyStyleRepository.GetAll().All(c => c.BodyStyleId != car.BodyStyleId))
            {
                response.Success = false;
                response.Message = "ERROR: no BodyStyles have id=" + car.BodyStyleId;
            }
            
            else if (carModelRepository.GetAll().All(c => c.CarModelId != car.CarModelId))
            {
                response.Success = false;
                response.Message = "ERROR: no CarModel have id=" + car.CarId;
            }
            else if (carTypeRepository.GetAll().All(c => c.CarTypeId != car.CarTypeId))
            {
                response.Success = false;
                response.Message = "ERROR: no CarType have id=" + car.CarId;
            }
            else if (colorRepository.GetAll().All(c => c.ColorId != car.ColorId))
            {
                response.Success = false;
                response.Message = "ERROR: no Colors have id=" + car.ColorId;
            }
            else if (transmissionRepository.GetAll().All(c => c.TransmissionId != car.TransmissionId))
            {
                response.Success = false;
                response.Message = "ERROR: no Transmission have id=" + car.TransmissionId;
            }
            else if (interiorColorRepository.GetAll().All(c => c.InteriorColorId != car.InteriorColorId))
            {
                response.Success = false;
                response.Message = "ERROR: no InteriorColor have id=" + car.InteriorColorId;
            }
            else
            {
                carsRepository.Add(car);
                response.Success = true;
                response.Message = "Car added";
            }
            return response;
        }

        public Response EditCars(Cars car)
        {
            Response response = new Response();
            if (bodyStyleRepository.GetAll().All(c => c.BodyStyleId != car.BodyStyleId))
            {
                response.Success = false;
                response.Message = "ERROR: no BodyStyles have id=" + car.BodyStyleId;
            }
            else if (carsRepository.GetAll().All(c => c.CarId != car.CarId))
            {
                response.Success = false;
                response.Message = "ERROR: no Cars have id=" + car.CarId;
            }
            else if (carModelRepository.GetAll().All(c => c.CarModelId != car.CarModelId))
            {
                response.Success = false;
                response.Message = "ERROR: no CarModel have id=" + car.CarId;
            }
            else if (carTypeRepository.GetAll().All(c => c.CarTypeId != car.CarTypeId))
            {
                response.Success = false;
                response.Message = "ERROR: no CarType have id=" + car.CarId;
            }
            else if (colorRepository.GetAll().All(c => c.ColorId != car.ColorId))
            {
                response.Success = false;
                response.Message = "ERROR: no Colors have id=" + car.CarId;
            }
            else if (transmissionRepository.GetAll().All(c => c.TransmissionId != car.TransmissionId))
            {
                response.Success = false;
                response.Message = "ERROR: no Transmission have id=" + car.CarId;
            }
            else if (interiorColorRepository.GetAll().All(c => c.InteriorColorId != car.InteriorColorId))
            {
                response.Success = false;
                response.Message = "ERROR: no Transmission have id=" + car.CarId;
            }
            else
            {
                carsRepository.Edit(car);
                response.Success = true;
                response.Message = "Car edited";
            }
            return response;

        }

        public Response RemoveCars(int id)
        {
            Response response = new Response();
            if (carsRepository.GetAll().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no cars found";
            }

            else if (carsRepository.GetAll().All(t => t.CarId != id))
            {
                response.Success = false;
                response.Message = "ERROR: no cars found with id=" + id;
            }
            else
            {
                carsRepository.Remove(id);
                response.Success = true;
                response.Message = "car removed";
            }
            return response;
        }

        public Response MarkSoldCars(int id)
        {
            Response response = new Response();
            if (carsRepository.Get(id) == null)
            {
                response.Success = false;
                response.Message = "no cars with id=" + id;
            }
            else  
            {
                carsRepository.MarkSold(id);
                response.Success = true;
                response.Message = "marked sold";
            }
            return response;
        }

        public Response MarkSpecialCars(int id)
        {
            Response response = new Response();
            if (carsRepository.Get(id) == null)
            {
                response.Success = false;
                response.Message = "no cars with id=" + id;
            }
            else
            {
                carsRepository.MarkSpecial(id);
                response.Success = true;
                response.Message = "marked as special";
            }
            return response;
        }

        public ResponseCarss GetAllSoldCars()
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (carsRepository.GetAllSold().FirstOrDefault() == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no cars found";
            }
            else 
            {
                responseCarss.Carss= carsRepository.GetAllSold();
                responseCarss.Success = true;
                responseCarss.Message = "Cars found";
            }
            return responseCarss;
        }

        public ResponseCarss GetAllCars()
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (carsRepository.GetAll().FirstOrDefault()== null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no CarTypes found";
            }
            else
            {
                responseCarss.Carss = carsRepository.GetAll();
                responseCarss.Success = true;
                responseCarss.Message = "CarTypes found";
            }
            return responseCarss;
        }

        public ResponseCars GetCars(int id)
        {
            ResponseCars responseCars = new ResponseCars();
            if (carsRepository.GetAll().FirstOrDefault() == null)
            {
                responseCars.Success = false;
                responseCars.Message = "ERROR: no cars found";
            }
            else if (!carsRepository.GetAll().Any(t => t.CarId == id))
            {
                responseCars.Success = false;
                responseCars.Message = "ERROR: no Car found with id=" + id;
            }
            else
            {
                responseCars.Cars = carsRepository.Get(id);
                responseCars.Success = true;
                responseCars.Message = "Car found";
            }
            return responseCars;
        }

        public ResponseCarss GetAllNew()
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (carsRepository.GetAllNew().FirstOrDefault() == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no cars found";
            }
            else
            {
                responseCarss.Carss = carsRepository.GetAllNew();
                responseCarss.Success = true;
                responseCarss.Message = "Cars found";
            }
            return responseCarss;
        }

        public ResponseCarss GetAllUsed()
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (carsRepository.GetAllUsed().FirstOrDefault() == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no cars found";
            }
            else
            {
                responseCarss.Carss = carsRepository.GetAllUsed();
                responseCarss.Success = true;
                responseCarss.Message = "Cars found";
            }
            return responseCarss;
        }


        public ResponseCarss GetAllSpecialCars()
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (carsRepository.GetAllSpecial().FirstOrDefault() == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no cars found";
            }
            else
            {
                responseCarss.Carss = carsRepository.GetAllSpecial();
                responseCarss.Success = true;
                responseCarss.Message = "Cars found";
            }
            return responseCarss;
        }

        public ResponseCarss GetByMakeCars(int id)
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (makeRepository.Get(id) == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no makes found with id="+ id;
            }
            else if (carsRepository.GetByMake(id).FirstOrDefault() == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no cars found";
            }
            else
            {
                responseCarss.Carss = carsRepository.GetByMake(id);
                responseCarss.Success = true;
                responseCarss.Message = "Cars found";
            }
            return responseCarss;
        }

        public ResponseCarss GetByModelCars(int id)
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (carModelRepository.Get(id) == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no model found with id=" + id;
            }
            else if (carsRepository.GetByModel(id).FirstOrDefault() == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no cars found";
            }
            else
            {
                responseCarss.Carss = carsRepository.GetByModel(id);
                responseCarss.Success = true;
                responseCarss.Message = "Cars found";
            }
            return responseCarss;
        }

        public ResponseCarss GetByYearCars(int year)
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (carsRepository.GetByYear(year) == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no cars found with year=" + year;
            }
            else
            {
                responseCarss.Carss = carsRepository.GetByYear(year);
                responseCarss.Success = true;
                responseCarss.Message = "Cars found";
            }
            return responseCarss;
        }

        public ResponseCarss GetByPriceCars(int low, int high)
        {
            ResponseCarss responseCarss = new ResponseCarss();
            if (carsRepository.GetByPrice(low,high) == null)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: no cars found in price range";
            }
            else if (low<0|| high<0||low>=high)
            {
                responseCarss.Success = false;
                responseCarss.Message = "ERROR: prices must be positive, and low must be less than high";
            }
            else
            {
                responseCarss.Carss = carsRepository.GetByPrice(low,high);
                responseCarss.Success = true;
                responseCarss.Message = "Cars found";
            }
            return responseCarss;
        }

        public Response AddCarModel(CarModel carModel)
        {
            Response response = new Response();
            if (carModelRepository.GetAll().Any(t => t.CarModelName == carModel.CarModelName))
            {
                response.Success = false;
                response.Message = "ERROR: CarModel name already exists";
            }
            else
            {
                carModelRepository.Add(carModel);
                response.Success = true;
                response.Message = "CarModel added";
            }
            return response;
        }

        public Response RemoveCarModel(int id)
        {
            Response response = new Response();
            if (carModelRepository.GetAll().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no CarModel found";
            }

            else if (carModelRepository.GetAll().All(t => t.CarModelId != id))
            {
                response.Success = false;
                response.Message = "ERROR: no CarModel found with id=" + id;
            }
            else
            {
                carModelRepository.Remove(id);
                response.Success = true;
                response.Message = "CarModel removed";
            }
            return response;
        }

        public ResponseCarModels GetAllCarModel()
        {
            ResponseCarModels responseCarModels = new ResponseCarModels();
            if (carModelRepository.GetAll().FirstOrDefault() == null)
            {
                responseCarModels.Success = false;
                responseCarModels.Message = "ERROR: no CarModels found";
            }
            else
            {
                responseCarModels.CarModels = carModelRepository.GetAll();
                responseCarModels.Success = true;
                responseCarModels.Message = "CarModels found";
            }
            return responseCarModels;
        }

        public ResponseCarModel GetCarModel(int id)
        {
            ResponseCarModel responseCarModel = new ResponseCarModel();
            if (carModelRepository.GetAll().FirstOrDefault() == null)
            {
                responseCarModel.Success = false;
                responseCarModel.Message = "ERROR: no CarModels found";
            }
            else if (!carModelRepository.GetAll().Any(t => t.CarModelId == id))
            {
                responseCarModel.Success = false;
                responseCarModel.Message = "ERROR: no CarModels found with id=" + id;
            }
            else
            {
                responseCarModel.CarModel = carModelRepository.Get(id);
                responseCarModel.Success = true;
                responseCarModel.Message = "CarModel found";
            }
            return responseCarModel;
        }

        public Response AddBodyStyle(BodyStyle bodyStyle)
        {
            Response response = new Response();
            if (bodyStyleRepository.GetAll().Any(t => t.BodyStyleName == bodyStyle.BodyStyleName))
            {
                response.Success = false;
                response.Message = "ERROR: BodyStyle name already exists";
            }
            else
            {
                bodyStyleRepository.Add(bodyStyle);
                response.Success = true;
                response.Message = "BodyStyle added";
            }
            return response;
        }

        public Response RemoveBodyStyle(int id)
        {
            Response response = new Response();
            if (bodyStyleRepository.GetAll().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no BodyStyle found";
            }

            else if (bodyStyleRepository.GetAll().All(t => t.BodyStyleId != id))
            {
                response.Success = false;
                response.Message = "ERROR: no BodyStyle found with id=" + id;
            }
            else
            {
                bodyStyleRepository.Remove(id);
                response.Success = true;
                response.Message = "BodyStyle removed";
            }
            return response;
        }

        public ResponseBodyStyles GetAllBodyStyle()
        {
            ResponseBodyStyles responseBodyStyles = new ResponseBodyStyles();
            if (bodyStyleRepository.GetAll().FirstOrDefault() == null)
            {
                responseBodyStyles.Success = false;
                responseBodyStyles.Message = "ERROR: no BodyStyles found";
            }
            else
            {
                responseBodyStyles.BodyStyles = bodyStyleRepository.GetAll();
                responseBodyStyles.Success = true;
                responseBodyStyles.Message = "BodyStyles found";
            }
            return responseBodyStyles;
        }

        public ResponseBodyStyle GetBodyStyle(int id)
        {
            ResponseBodyStyle responseBodyStyle = new ResponseBodyStyle();
            if (bodyStyleRepository.GetAll().FirstOrDefault() == null)
            {
                responseBodyStyle.Success = false;
                responseBodyStyle.Message = "ERROR: no BodyStyle found";
            }
            else if (!bodyStyleRepository.GetAll().Any(t => t.BodyStyleId == id))
            {
                responseBodyStyle.Success = false;
                responseBodyStyle.Message = "ERROR: no BodyStyle found with id=" + id;
            }
            else
            {
                responseBodyStyle.BodyStyle = bodyStyleRepository.Get(id);
                responseBodyStyle.Success = true;
                responseBodyStyle.Message = "BodyStyle found";
            }
            return responseBodyStyle;
        }

        public Response AddColor(Color color)
        {
            Response response = new Response();
            if (colorRepository.GetAll().Any(t => t.ColorName == color.ColorName))
            {
                response.Success = false;
                response.Message = "ERROR: Color name already exists";
            }
            else
            {
                colorRepository.Add(color);
                response.Success = true;
                response.Message = "Color added";
            }
            return response;
        }

        public Response RemoveColor(int id)
        {
            Response response = new Response();
            if (colorRepository.GetAll().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no colors found";
            }

            else if (colorRepository.GetAll().All(t => t.ColorId != id))
            {
                response.Success = false;
                response.Message = "ERROR: no color found with id=" + id;
            }
            else
            {
                colorRepository.Remove(id);
                response.Success = true;
                response.Message = "color removed";
            }
            return response;
        }

        public ResponseColors GetAllColor()
        {
            ResponseColors responseColors = new ResponseColors();
            if (colorRepository.GetAll().FirstOrDefault() == null)
            {
                responseColors.Success = false;
                responseColors.Message = "ERROR: no color found";
            }
            else
            {
                responseColors.Colors = colorRepository.GetAll();
                responseColors.Success = true;
                responseColors.Message = "colors found";
            }
            return responseColors;
        }

        public ResponseColor GetColor(int id)
        {
            ResponseColor responseColor = new ResponseColor();
            if (colorRepository.GetAll().FirstOrDefault() == null)
            {
                responseColor.Success = false;
                responseColor.Message = "ERROR: no colors found";
            }
            else if (!colorRepository.GetAll().Any(t => t.ColorId == id))
            {
                responseColor.Success = false;
                responseColor.Message = "ERROR: no color found with id=" + id;
            }
            else
            {
                responseColor.Color= colorRepository.Get(id);
                responseColor.Success = true;
                responseColor.Message = "color found";
            }
            return responseColor;
        }

        public Response AddMessage(Contact contact)
        {
            Response response = new Response();
            
                carsRepository.AddMessage(contact);
                response.Success = true;
                response.Message = "Contact added";
            
            return response;
        }

        public Response RemoveSpecialOffer(int id)
        {
            carModelRepository.RemoveDeal(id);
            return (new Response() { Success = true, Message = "Success" });
        }

        public Response AddSpecialOffer(Special special)
        {
            carModelRepository.AddDeal(special);
            return (new Response() { Success = true, Message = "Success" });

        }
        public ResponseSpecials GetAllSpecialOffers()
        {
            return (new ResponseSpecials() {  Specials = carModelRepository.GetSpecialOffers(),Success = true, Message = "Success" });
        }


        public Response RemoveContact(int id)
        {
            Response response = new Response();
            if (carsRepository.GetAllMessages().FirstOrDefault() == null)
            {
                response.Success = false;
                response.Message = "ERROR: no contacts found";
            }

            else if (carsRepository.GetAllMessages().All(t => t.ContactId != id))
            {
                response.Success = false;
                response.Message = "ERROR: no contacts found with id=" + id;
            }
            else
            {
                carsRepository.RemoveMessage(id);
                response.Success = true;
                response.Message = "contact removed";
            }
            return response;
        }




        public ResponseContacts GetAllContacts()
        {
            ResponseContacts responseContacts = new ResponseContacts();
            if (carsRepository.GetAllMessages().FirstOrDefault() == null)
            {
                responseContacts.Success = false;
                responseContacts.Message = "ERROR: no contacts found";
            }
            else
            {
                responseContacts.Contacts = carsRepository.GetAllMessages();
                responseContacts.Success = true;
                responseContacts.Message = "Contacts found";
            }
            return responseContacts;
        }


    }
}
