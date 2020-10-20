using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAO
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public void AddCity(City city)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string sqlText = "insert into city values(@name, @countrycode, @district, @population)";
                    SqlCommand command = new SqlCommand(sqlText, sqlConnection);
                    command.Parameters.AddWithValue("@name", city.Name);
                    command.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    command.Parameters.AddWithValue("@district", city.District);
                    command.Parameters.AddWithValue("@population", city.Population);

                    int rowsImpacted = command.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddCityAsCapital(City city, string countryCode)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    // I need to get back the id of the newly inserted city
                    string sqlText = "insert into city values(@name, @countrycode, @district, @population);select SCOPE_IDENTITY();";
                    SqlCommand command = new SqlCommand(sqlText, sqlConnection);
                    command.Parameters.AddWithValue("@name", city.Name);
                    command.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    command.Parameters.AddWithValue("@district", city.District);
                    command.Parameters.AddWithValue("@population", city.Population);

                    int cityId = Convert.ToInt32(command.ExecuteScalar());

                    sqlText = $"update country set capital={cityId} where code=@countrycode";
                    command = new SqlCommand(sqlText, sqlConnection);
                    command.Parameters.AddWithValue("@countrycode", countryCode);

                    int rowsImpacted = command.ExecuteNonQuery();
                    if(rowsImpacted == 0)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> output = new List<City>();

            try
            {
                // step 1 create connection
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                // step 2
                sqlConnection.Open();
                //step 3
                SqlCommand sqlCommand = new SqlCommand();
                // step 4
                string sqlText = $"select * from city where countryCode = @countryCode";
                sqlCommand.CommandText = sqlText;
                sqlCommand.Parameters.AddWithValue("@countryCode", countryCode);
                // step 5
                sqlCommand.Connection = sqlConnection;
                // step 6
                SqlDataReader reader = sqlCommand.ExecuteReader();
                // as long as there are records to read, get one
                while(reader.Read())
                {
                    City city = new City();
                    city.CityId = Convert.ToInt32(reader["id"]);
                    city.Name = Convert.ToString(reader["name"]);
                    city.CountryCode = Convert.ToString(reader["countrycode"]);
                    city.District = Convert.ToString(reader["district"]);
                    city.Population = Convert.ToInt32(reader["population"]);
                    output.Add(city);
                }

                //step 7
                sqlConnection.Close();
            }
            catch (Exception e)
            {

                throw;
            }
            return output;
        }

    }
}
