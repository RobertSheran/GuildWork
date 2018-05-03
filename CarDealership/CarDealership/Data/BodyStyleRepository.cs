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
    public class BodyStyleRepository:IBodyStyleRepository
    {
        public void Add(BodyStyle bodyStyle)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@BodyStyleId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                dynamicParameters.Add("@BodyStyleName", bodyStyle.BodyStyleName);
                sqlConnection.Query<BodyStyle>("AddBodyStyle", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public BodyStyle Get(int id)
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                return sqlConnection.Query<BodyStyle>("GetBodyStyle",dynamicParameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

        }

        public List<BodyStyle> GetAll()
        {
            using (var sqlConnection = new System.Data.SqlClient.SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                return sqlConnection.Query<BodyStyle>("GetAllBodyStyle",
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
                dynamicParameters.Add("@id", id);


                sqlConnection.Query<BodyStyle>("RemoveBodyStyle", dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
