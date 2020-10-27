using HTTP_Web_Services_GET_lecture.Data;
using System;
using System.Collections.Generic;

namespace HTTP_Web_Services_GET_lecture
{
    class Program
    {

        static void Main(string[] args)
        {
            APIService apiService = new APIService("http://localhost:3000/");
            CLI cli = new CLI(apiService);
            cli.Run();
        }

    }
}
