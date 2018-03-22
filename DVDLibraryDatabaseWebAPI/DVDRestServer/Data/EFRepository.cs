using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DVDDatabaseModel;

namespace Data
{
    public class EFRepository : IRepository
    {
        public DVD GetDVDById(int dVDId)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["EFRepository"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", dVDId);


                return sqlConnection.Query<DVD>("EFGetById", parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<DVD> GetAllDVDs()
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["EFRepository"]
                    .ConnectionString;

                return sqlConnection.Query<DVD>("EFGetAll",
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public DVD GetDVDByTitle(string title)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["EFRepository"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDTitle", title);


                return sqlConnection.Query<DVD>("EFGetByTitle", parameters,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public List<DVD> GetDVDsByDirector(string director)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["EFRepository"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@Director", director);

                return sqlConnection.Query<DVD>(
                    "EFGetByDirector",
                    parameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }
        public List<DVD> GetDVDsByRating(string movieRating)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["EFRepository"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@Rating", movieRating);

                return sqlConnection.Query<DVD>(
                    "EFGetByRating",
                    parameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }
        public List<DVD> GetDVDsByReleaseYear(int realeaseYear)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["EFRepository"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@RealeaseYear", realeaseYear);

                return sqlConnection.Query<DVD>(
                    "EFGetByRealeaseYear",
                    parameters,
                    commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public void AddDVD(DVD dVD)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                    .ConnectionStrings["EFRepository"]
                    .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Director", dVD.Director);
                parameters.Add("@DVDTitle", dVD.DVDTitle);
                parameters.Add("@DVDNotes", dVD.DVDNotes);
                parameters.Add("@Rating", dVD.Rating);
                parameters.Add("@RealeaseYear", dVD.RealeaseYear);

                sqlConnection.Query<DVD>(
                    "EFMovieInsert",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void UpdateDVD(DVD dVD)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                            .ConnectionStrings["EFRepository"]
                            .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", dVD.DVDId);
                parameters.Add("@Director", dVD.Director);
                parameters.Add("@DVDTitle", dVD.DVDTitle);
                parameters.Add("@DVDNotes", dVD.DVDNotes);
                parameters.Add("@Rating", dVD.Rating);
                parameters.Add("@RealeaseYear", dVD.RealeaseYear);

                sqlConnection.Execute("EFMovieUpdate",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteDVD(int id)
        {
            using (var sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = ConfigurationManager
                            .ConnectionStrings["EFRepository"]
                            .ConnectionString;

                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", id);

                sqlConnection.Execute("EFDVDDelete",
                    parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}