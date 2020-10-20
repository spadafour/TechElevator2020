using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.DAO;

namespace WorldGeography
{
    class Program
    {
        static void Main(string[] args)
        {
            //IConfigurationBuilder builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();
            //string connectionString = configuration.GetConnectionString("World");


            ICityDAO cityDAO = new CitySqlDAO(@"Data Source=.\SQLEXPRESS;Initial Catalog=World;Integrated Security=True");
            ICountryDAO countryDAO = new CountrySqlDAO(@"Data Source=.\SQLEXPRESS;Initial Catalog=World;Integrated Security=True");
            ILanguageDAO languageDAO = null;

            WorldGeographyCLI cli = new WorldGeographyCLI(cityDAO, countryDAO, languageDAO);
            cli.RunCLI();
        }
    }
}
