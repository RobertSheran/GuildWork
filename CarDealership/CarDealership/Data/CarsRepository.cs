using CarDealership.Models;
using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CarsRepository : ICarsRepository
    {
        public void Add(Cars car)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CarId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@CarModelId", car.CarModelId);
                dynamicParameters.Add("@Vin", car.Vin);
                dynamicParameters.Add("@SalesPrice", car.SalesPrice);
                dynamicParameters.Add("@MSRP", car.MSRP);
                dynamicParameters.Add("@CarYear", car.CarYear);
                dynamicParameters.Add("@Mileage", car.Mileage);
                dynamicParameters.Add("@Special", car.Special);
                dynamicParameters.Add("@Photo", car.Photo);
                dynamicParameters.Add("@Discription", car.Discription);
                dynamicParameters.Add("@BodyStyleId", car.BodyStyleId);
                dynamicParameters.Add("@ColorId", car.ColorId);
                dynamicParameters.Add("@CarTypeId", car.CarTypeId);
                dynamicParameters.Add("@TransmissionId", car.TransmissionId);
                dynamicParameters.Add("@InteriorColorId", car.InteriorColorId);
                dynamicParameters.Add("@CarModelId", car.CarModelId);
                dynamicParameters.Add("@Sold", car.Sold);
                dynamicParameters.Add("AspNetUserId", car.AspNetUserId);

                sqlConnection.Query<Cars>("AddCars", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveMessage(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                sqlConnection.Query<Contact>("RemoveMessage", dynamicParameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public void AddMessage(Contact contact)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ContactId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@ContactMessage", contact.ContactMessage);
                dynamicParameters.Add("@ContactName", contact.ContactName);
                dynamicParameters.Add("@Email", contact.Email);
                dynamicParameters.Add("@Phone", contact.Phone);

                sqlConnection.Query<Cars>("AddMessage", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Contact> GetAllMessages()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                return sqlConnection.Query<Contact>("GetAllMessages",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<Financing> GetFinancing()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                return sqlConnection.Query<Financing>("GetFinancing",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public void AddInvoice(Invoice invoice)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@InvoiceId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@InvoiceName", invoice.InvoiceName);
                dynamicParameters.Add("@Phone", invoice.Phone);
                dynamicParameters.Add("@Email", invoice.Email);
                dynamicParameters.Add("@StreetOne", invoice.StreetOne);
                dynamicParameters.Add("@StreetTwo", invoice.StreetTwo);
                dynamicParameters.Add("@City", invoice.City);
                dynamicParameters.Add("@InvoiceState", invoice.InvoiceState);
                dynamicParameters.Add("@ZipCode", invoice.ZipCode);
                dynamicParameters.Add("@Price", invoice.Price);
                dynamicParameters.Add("@PerchaseType", invoice.PerchaseType);


                sqlConnection.Query<Contact>("Purchase", dynamicParameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public void AddFinancing(string v)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@FinancingType", v);

                sqlConnection.Query<Financing>("AddFinancing", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<State> GetStates()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;


                return sqlConnection.Query<State>("GetStates",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<Cars> GetAllNew()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;


                return sqlConnection.Query<Cars>("GetAllNew",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }
        public List<Cars> GetAllUsed()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;


                return sqlConnection.Query<Cars>("GetAllUsed",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }
        public void Edit(Cars car)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CarId", car.CarId);
                dynamicParameters.Add("@Sold", car.Sold);
                dynamicParameters.Add("@CarModelId", car.CarModelId);
                dynamicParameters.Add("@Vin", car.Vin);
                dynamicParameters.Add("@SalesPrice", car.SalesPrice);
                dynamicParameters.Add("@MSRP", car.MSRP);
                dynamicParameters.Add("@CarYear", car.CarYear);
                dynamicParameters.Add("@Mileage", car.Mileage);
                dynamicParameters.Add("@Special", car.Special);
                dynamicParameters.Add("@Photo", car.Photo);
                dynamicParameters.Add("@Discription", car.Discription);
                dynamicParameters.Add("@BodyStyleId", car.BodyStyleId);
                dynamicParameters.Add("@ColorId", car.ColorId);
                dynamicParameters.Add("@CarTypeId", car.CarTypeId);
                dynamicParameters.Add("@TransmissionId", car.TransmissionId);
                dynamicParameters.Add("@InteriorColorId", car.InteriorColorId);
                dynamicParameters.Add("@CarModelId", car.CarModelId);
                dynamicParameters.Add("AspNetUserId", car.AspNetUserId);

                sqlConnection.Query<Cars>("EditCars", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<Cars> GetAll()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                return sqlConnection.Query<Cars>("GetAllCars",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<Cars> GetByMake(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("id", id);

                return sqlConnection.Query<Cars>("GetByMake", dynamicParameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<Cars> GetByModel(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("id", id);

                return sqlConnection.Query<Cars>("GetByModel", dynamicParameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<Cars> GetByPrice(int low, int high)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("low", low);
                dynamicParameters.Add("high", high);

                return sqlConnection.Query<Cars>("GetByPrice", dynamicParameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<Cars> GetByYear(int year)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("year", year);

                return sqlConnection.Query<Cars>("GetByYear", dynamicParameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<Cars> GetAllSold()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                return sqlConnection.Query<Cars>("GetAllSold",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public Cars Get(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return sqlConnection.Query<Cars>("GetCars", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void MarkSold(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                sqlConnection.Query<Cars>("MarkSold", dynamicParameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public void MarkSpecial(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                sqlConnection.Query<Cars>("MarkSpecial", dynamicParameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public void Remove(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                sqlConnection.Query<Cars>("RemoveCars", dynamicParameters,
                   commandType: CommandType.StoredProcedure);
            }
        }


        public List<Cars> GetAllSpecial()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                return sqlConnection.Query<Cars>("GetAllSpecial",
                   commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public void AddState(State state)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@StateId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@StateName", state.StateName);

                sqlConnection.Query<Cars>("AddState", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ShortCar> Search(ListingSearchPerameters perameters)
        {
            List<ShortCar> listings = new List<ShortCar>();

            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {

                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                string query = "Select CarId, Photo, CarModelName, MakeName, SalesPrice, CarYear from Cars inner join CarModel on Cars.CarModelId = CarModel.CarModelId inner join Make on CarModel.MakeId = Make.MakeId where 1 = 1 ";
                if (!string.IsNullOrEmpty(perameters.MakeModel))
                {
                    query += "And CarModelName like @ModelName ";
                    command.Parameters.AddWithValue("@ModelName", perameters.MakeModel);
                    query += "Or MakeName like @MakeName ";
                    command.Parameters.AddWithValue("@MakeName", perameters.MakeModel);
                }

                if (perameters.MinPrice.HasValue)
                {
                    query += "AND SalesPrice >= @MinPrice ";
                    command.Parameters.AddWithValue("@MinPrice", perameters.MinPrice.Value);
                }

                if (perameters.MinYear.HasValue)
                {
                    query += "AND CarYear >= @MinYear ";
                    command.Parameters.AddWithValue("@MinYear", perameters.MinYear.Value);
                }

                if (perameters.MaxPrice.HasValue)
                {
                    query += "AND SalesPrice <= @MaxPrice ";
                    command.Parameters.AddWithValue("@MaxPrice", perameters.MaxPrice.Value);
                }
                if (perameters.MaxYear.HasValue)
                {
                    query += "AND CarYear <= @MaxYear ";
                    command.Parameters.AddWithValue("@MaxYear", perameters.MaxYear.Value);
                }

                command.CommandText = query;
                sqlConnection.Open();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ShortCar row = new ShortCar();
                        row.CarId = (int)dr["CarId"];
                        row.CarMake = dr["MakeName"].ToString();
                        row.Year = (int)dr["CarYear"];
                        row.Price = (int)dr["SalesPrice"];
                        row.CarModel = dr["CarModelName"].ToString();
                        if (dr["Photo"] != DBNull.Value)
                        {
                            row.Photo = dr["Photo"].ToString();
                        }
                        listings.Add(row);
                    }
                }
                return listings;
            }
        }

        public IEnumerable<ShortCar> SearchNew(ListingSearchPerameters perameters)
        {
            List<ShortCar> listings = new List<ShortCar>();

            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {

                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                string query = "Select CarId, Photo, CarModelName, MakeName, SalesPrice, CarYear from Cars inner join CarModel on Cars.CarModelId = CarModel.CarModelId inner join Make on CarModel.MakeId = Make.MakeId where 1 = 1 ";
                query += "And CarTypeId = 2 ";

                if (!string.IsNullOrEmpty(perameters.MakeModel))
                {
                    query += "And CarModelName like @ModelName ";
                    command.Parameters.AddWithValue("@ModelName", perameters.MakeModel);
                    query += "Or MakeName like @MakeName ";
                    command.Parameters.AddWithValue("@MakeName", perameters.MakeModel);
                }


                if (perameters.MinPrice.HasValue)
                {
                    query += "AND SalesPrice >= @MinPrice ";
                    command.Parameters.AddWithValue("@MinPrice", perameters.MinPrice.Value);
                }

                if (perameters.MinYear.HasValue)
                {
                    query += "AND CarYear >= @MinYear ";
                    command.Parameters.AddWithValue("@MinYear", perameters.MinYear.Value);
                }

                if (perameters.MaxPrice.HasValue)
                {
                    query += "AND SalesPrice <= @MaxPrice ";
                    command.Parameters.AddWithValue("@MaxPrice", perameters.MaxPrice.Value);
                }
                if (perameters.MaxYear.HasValue)
                {
                    query += "AND CarYear <= @MaxYear ";
                    command.Parameters.AddWithValue("@MaxYear", perameters.MaxYear.Value);
                }

                command.CommandText = query;
                sqlConnection.Open();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                       
                            ShortCar row = new ShortCar();
                            row.CarId = (int)dr["CarId"];
                            row.CarMake = dr["MakeName"].ToString();
                            row.Year = (int)dr["CarYear"];
                            row.Price = (int)dr["SalesPrice"];
                            row.CarModel = dr["CarModelName"].ToString();
                            if (dr["Photo"] != DBNull.Value)
                            {
                                row.Photo = dr["Photo"].ToString();
                            }
                            listings.Add(row);
                                         
                    }
                }
                return listings;
            }
        }
        public IEnumerable<ShortCar> SearchUsed(ListingSearchPerameters perameters)
        {
            List<ShortCar> listings = new List<ShortCar>();

            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {

                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                string query = "Select CarId, Photo, CarModelName, MakeName, SalesPrice, CarYear from Cars inner join CarModel on Cars.CarModelId = CarModel.CarModelId inner join Make on CarModel.MakeId = Make.MakeId where 1 = 1 ";
                query += "And CarTypeId = 1 ";

                if (!string.IsNullOrEmpty(perameters.MakeModel))
                {
                    query += "And CarModelName like @ModelName ";
                    command.Parameters.AddWithValue("@ModelName", perameters.MakeModel);
                    query += "Or MakeName like @MakeName ";
                    command.Parameters.AddWithValue("@MakeName", perameters.MakeModel);
                }

                if (perameters.MinPrice.HasValue)
                {
                    query += "AND SalesPrice >= @MinPrice ";
                    command.Parameters.AddWithValue("@MinPrice", perameters.MinPrice.Value);
                }

                if (perameters.MinYear.HasValue)
                {
                    query += "AND CarYear >= @MinYear ";
                    command.Parameters.AddWithValue("@MinYear", perameters.MinYear.Value);
                }

                if (perameters.MaxPrice.HasValue)
                {
                    query += "AND SalesPrice <= @MaxPrice ";
                    command.Parameters.AddWithValue("@MaxPrice", perameters.MaxPrice.Value);
                }
                if (perameters.MaxYear.HasValue)
                {
                    query += "AND CarYear <= @MaxYear ";
                    command.Parameters.AddWithValue("@MaxYear", perameters.MaxYear.Value);
                }

                command.CommandText = query;
                sqlConnection.Open();

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        ShortCar row = new ShortCar();
                        row.CarId = (int)dr["CarId"];
                        row.CarMake = dr["MakeName"].ToString();
                        row.Year = (int)dr["CarYear"];
                        row.Price = (int)dr["SalesPrice"];
                        row.CarModel = dr["CarModelName"].ToString();
                        if (dr["Photo"] != DBNull.Value)
                        {
                            row.Photo = dr["Photo"].ToString();
                        }
                        listings.Add(row);

                    }
                }
                return listings;
            }
        }
    }
}
