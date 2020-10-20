﻿using System;
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
            throw new NotImplementedException();
        }

        public IList<Country> GetCountries(string continent)
        {
            throw new NotImplementedException();
        }
    }
}
