using RestSharp;
using System;
using System.Collections.Generic;

namespace AuctionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            AuctionCLI auctionCLI = new AuctionCLI();
            auctionCLI.Run();
        }
    }
}
