using CarDealership.Models.IRepositories;
using CarDealership.Models.TabelModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CarModelRepository : ICarModelRepository
    {
        public void Add(CarModel carModel)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CarModelId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@MakeId", carModel.MakeId);
                dynamicParameters.Add("@CarModelName", carModel.CarModelName);
                sqlConnection.Query<CarModel>("AddCarModel", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void AddDeal(Special special)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SpecialId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@SpecialMessage", special.SpecialMessage);
                sqlConnection.Query<CarModel>("AddDeal", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public CarModel Get(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                return sqlConnection.Query<CarModel>("GetCarModel", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<CarModel> GetAll()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                return sqlConnection.Query<CarModel>("GetAllCarModel",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<Special> GetSpecialOffers()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                return sqlConnection.Query<Special>("GetAllDeals",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public void RemoveDeal(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                sqlConnection.Query<Special>("RemoveDeal", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
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
                dynamicParameters.Add("@Id", id);
                sqlConnection.Query<CarModel>("RemoveCarModel", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
