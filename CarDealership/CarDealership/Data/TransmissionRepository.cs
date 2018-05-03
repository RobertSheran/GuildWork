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
    public class TransmissionRepository : ITransmissionRepository
    {
        public void Add(Transmission transmission)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TransmissionId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@TransmissionName", transmission.TransmissionName);
                sqlConnection.Query<Transmission>("AddTransmission", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Transmission Get(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                return sqlConnection.Query<Transmission>("GetTransmission", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Transmission> GetAll()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                return sqlConnection.Query<Transmission>("GetAllTransmission",
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
                sqlConnection.Query<Transmission>("RemoveTransmission", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
