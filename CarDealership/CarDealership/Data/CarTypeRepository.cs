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
    public class CarTypeRepository : ICarTypeRepository
    {
        public void Add(CarType cars)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CarTypeId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@CarTypeName", cars.CarTypeName);
                sqlConnection.Query<CarType>("AddCarType", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public CarType Get(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                return sqlConnection.Query<CarType>("GetCarType", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<CarType> GetAll()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                return sqlConnection.Query<CarType>("GetAllCarType",
                    commandType: CommandType.StoredProcedure).AsList();
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
                sqlConnection.Query<CarType>("RemoveCarType", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
