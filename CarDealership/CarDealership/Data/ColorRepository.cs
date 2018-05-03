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
    public class ColorRepository : IColorRepository
    {
        public void Add(Color color)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ColorId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@ColorName", color.ColorName);
                sqlConnection.Query<Color>("AddColor", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Color Get(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);
                return sqlConnection.Query<Color>("GetColor", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Color> GetAll()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                return sqlConnection.Query<Color>("GetAllColor",
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
                sqlConnection.Query<Color>("RemoveColor", dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
