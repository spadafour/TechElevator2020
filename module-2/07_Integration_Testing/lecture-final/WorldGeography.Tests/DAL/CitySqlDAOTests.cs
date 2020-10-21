using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using WorldGeography.DAL;
using WorldGeography.Models;
using WorldGeography.Tests.DAL;

namespace WorldGeography.Tests
{
    [TestClass]
    public class CitySqlDAOTests 
    {
        private TransactionScope transaction { get; set; }
        private string connectionString = @"Data Source=.\SQLEXpress;Initial Catalog=World;Integrated Security=true";
        private string countryCodeToTest = "USA";

        [TestInitialize]
        public void Initialize()
        {
            // create a new transaction. Like begin transaction in SSMS
            transaction = new TransactionScope();

            // put some data in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // check if country code YYZ already exists since I can't add a duplicate
                string sqlSelect = $"Select count(*) from country where code = '{countryCodeToTest}'";
                SqlCommand cmd = new SqlCommand(sqlSelect, connection);
                int countryCount = Convert.ToInt32(cmd.ExecuteScalar());
                if(countryCount == 0)
                {
                    string insert = $"insert into country values('{countryCodeToTest}', 'Tech Elevator', 'North America', 'United States', 40, 2015, 42, 112, 1, 1, 'TE', 'Dictatorship', 'Jennifer', null, 'TE')";
                    cmd = new SqlCommand(insert, connection);
                    cmd.ExecuteNonQuery();
                }

                // let's add city
                string sqlCityInsert = $"insert into city Values('Gotham City','{countryCodeToTest}','Pennsylvania',50000);select scope_identity();";
                cmd = new SqlCommand(sqlCityInsert, connection);
                int testCityId = Convert.ToInt32(cmd.ExecuteScalar());

            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        [DataRow("USA", 1)]
        public void GetCitiesByCountryCode_Should_ReturnRightNumberOfCities(string countryCode, int expectedCityCount)
        {
            // Arrange
            CitySqlDAO dao = new CitySqlDAO(connectionString);

            // Act
            IList<City> cities = dao.GetCitiesByCountryCode(countryCode);

            // Assert
            Assert.IsTrue(cities.Count >= expectedCityCount);

        }

        [TestMethod]
        public void AddCity_Should_IncreaseCountBy1()
        {
            // Arrange
            City city = new City();
            city.CountryCode = countryCodeToTest;
            city.Name = "Doesn't matter";
            city.Population = 1;
            city.District = "Doesn't matter";
            CitySqlDAO dao = new CitySqlDAO(connectionString);
            int startingRowCount = GetRowCount("city");

            // Act
            dao.AddCity(city);

            // Assert
            int endingRowCount = GetRowCount("city");
            Assert.AreNotEqual(startingRowCount, endingRowCount);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddCity_Should_Fail_IfCountryDoesNotExist()
        {
            // Arrange
            City city = new City();
            city.CountryCode = "XYZ";
            city.Name = "Doesn't matter";
            city.Population = 1;
            city.District = "Doesn't matter";
            CitySqlDAO dao = new CitySqlDAO(connectionString);

            // Act
            dao.AddCity(city);

            // Assert
            // SqlException is expected to be thrown
        }

        private int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand($"select count(*) from {table}", conn);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
        }
    }
}
