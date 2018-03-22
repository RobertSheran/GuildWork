using System.Collections.Generic;
using DVDDatabaseModel;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;
using System.Linq;

namespace Data
{
    public class ADORepository : IRepository
    {
        public DVD GetDVDById(int dVDId)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieDb"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", dVDId);


                return sqlConnection.Query<DVD>("GetById", parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<DVD> GetAllDVDs()
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieDb"]
                    .ConnectionString;

                return sqlConnection.Query<DVD>("GetAll",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public DVD GetDVDByTitle(string title)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieDb"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDTitle", title);


                return sqlConnection.Query<DVD>("GetByTitle", parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<DVD> GetDVDsByDirector(string director)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieDb"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@Director", director);

                return sqlConnection.Query<DVD>(
                    "GetByDirector",
                    parameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }
        public List<DVD> GetDVDsByRating(string movieRating)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieDb"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@Rating", movieRating);

                return sqlConnection.Query<DVD>(
                    "GetByRating",
                    parameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }
        public List<DVD> GetDVDsByReleaseYear(int realeaseYear)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieDb"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@RealeaseYear", realeaseYear);

                return sqlConnection.Query<DVD>(
                    "GetByRealeaseYear",
                    parameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public void AddDVD(DVD dVD)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["MovieDb"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Director", dVD.Director);
                parameters.Add("@DVDTitle", dVD.DVDTitle);
                parameters.Add("@DVDNotes", dVD.DVDNotes);
                parameters.Add("@Rating", dVD.Rating);
                parameters.Add("@RealeaseYear", dVD.RealeaseYear);

                sqlConnection.Query<DVD>(
                    "MovieInsert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateDVD(DVD dVD)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                            .ConnectionStrings["MovieDb"]
                            .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", dVD.DVDId);
                parameters.Add("@Director", dVD.Director);
                parameters.Add("@DVDTitle", dVD.DVDTitle);
                parameters.Add("@DVDNotes", dVD.DVDNotes);
                parameters.Add("@Rating", dVD.Rating);
                parameters.Add("@RealeaseYear", dVD.RealeaseYear);

                sqlConnection.Execute("MovieUpdate",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteDVD(int id)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                            .ConnectionStrings["MovieDb"]
                            .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", id);

                sqlConnection.Execute("DVDDelete",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}