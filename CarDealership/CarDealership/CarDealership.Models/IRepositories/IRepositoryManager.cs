using CarDealership.Models.Responses;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.IRepositories
{
    public interface IRepositoryManager
    {

        Response AddTransmission(Transmission transmission);
        IEnumerable<ShortCar> Search(ListingSearchPerameters perameters);
        IEnumerable<ShortCar> SearchNew(ListingSearchPerameters perameters);
        IEnumerable<ShortCar> SearchUsed(ListingSearchPerameters perameters);
        ResponseStates GetStates();
        Response AddState(State state);
        Response AddFinancing(string financing);
        ResponseFinancings GetFinancings();
        Response Buy(Invoice invoice);
        ResponseTransmission GetTransmission(int id);
        ResponseTransmissions GetAllTransmission();
        Response RemoveTransmission(int id);
        Response AddMake(Make make);
        Response RemoveMake(int id);
        ResponseMakes GetAllMake();
        ResponseMake GetMake(int id);
        Response AddInteriorColors(InteriorColors interiorColor);
        Response RemoveInteriorColors(int id);
        ResponseInteriorColorss GetAllInteriorColors();
        ResponseInteriorColors GetInteriorColors(int id);
        Response AddCarType(CarType carType);
        Response RemoveCarType(int id);
        ResponseCarTypes GetAllCarType();
        ResponseCarType GetCarType(int id);
        Response AddCars(Cars car);
        Response EditCars(Cars car);
        Response RemoveCars(int id);
        Response MarkSoldCars(int id);
        Response MarkSpecialCars(int id);
        ResponseCarss GetAllSoldCars();
        ResponseCarss GetAllCars();
        ResponseCars GetCars(int id);
        ResponseCarss GetAllNew();
        ResponseCarss GetAllUsed();
        ResponseCarss GetAllSpecialCars();
        ResponseCarss GetByMakeCars(int id);
        ResponseCarss GetByModelCars(int id);
        ResponseCarss GetByYearCars(int year);
        ResponseCarss GetByPriceCars(int low, int high);
        Response AddCarModel(CarModel carModel);
        Response RemoveCarModel(int id);
        ResponseCarModels GetAllCarModel();
        ResponseCarModel GetCarModel(int id);
        Response AddBodyStyle(BodyStyle bodyStyle);
        Response RemoveBodyStyle(int id);
        ResponseBodyStyles GetAllBodyStyle();
        ResponseBodyStyle GetBodyStyle(int id);
        Response AddColor(Color color);
        Response RemoveColor(int id);
        ResponseColors GetAllColor();
        ResponseColor GetColor(int id);
        Response AddMessage(Contact contact);
        Response RemoveSpecialOffer(int id);
        Response AddSpecialOffer(Special special);
        ResponseSpecials GetAllSpecialOffers();
        Response RemoveContact(int id);
        ResponseContacts GetAllContacts();
    }
}
