using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.Models;

namespace WorldGeography.DAO
{
    public class CountrySqlDAO : ICountryDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based country dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CountrySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }        

        public IList<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlText = "Select * from country";
                    // step 3-5
                    SqlCommand sqlCommand = new SqlCommand(sqlText, conn);

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Country country = ConvertReaderToCountry(reader);
                        countries.Add(country);
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

            return countries;
        }

        public IList<Country> GetCountries(string continent)
        {
            List<Country> countries = new List<Country>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlText = "select * from country where continent = @continentFromUser";
                    SqlCommand sqlCommand = new SqlCommand(sqlText, conn);
                    sqlCommand.Parameters.AddWithValue("@continentFromUser", continent);

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        countries.Add(ConvertReaderToCountry(sqlDataReader));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return countries;
        }

        private Country ConvertReaderToCountry(SqlDataReader reader)
        {
            Country output = new Country();

            output.Code = Convert.ToString(reader["code"]);
            output.Name = Convert.ToString(reader["name"]);
            output.Continent = Convert.ToString(reader["continent"]);
            output.Region = Convert.ToString(reader["region"]);
            output.SurfaceArea = Convert.ToDouble(reader["surfacearea"]);
            output.Population = Convert.ToInt32(reader["population"]);
            output.GovernmentForm = Convert.ToString(reader["governmentform"]);

            return output;

        }
    }
}
