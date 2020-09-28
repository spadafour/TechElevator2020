using AuctionProgram.Classes;
using System;
using System.Runtime.CompilerServices;

namespace AuctionProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting a general auction");

            Auction generalAuction = new Auction(0M);

            Bid openingBid = new Bid("Henry", 10M);
            generalAuction.PlaceBid(openingBid);
            generalAuction.PlaceBid(new Bid("Mimi", 15M));
            generalAuction.PlaceBid(new Bid("Eddie", 12M));


            Console.WriteLine("==========================");
            Console.WriteLine("Starting a reserve auction");
            ReserveAuction reserveAuction = new ReserveAuction(50M);
            reserveAuction.PlaceBid(new Bid("Henry", 25));
            reserveAuction.PlaceBid(new Bid("Mimi", 49));
            reserveAuction.PlaceBid(new Bid("Eddie", 56));
            reserveAuction.PlaceBid(new Bid("Henry", 52));

            Console.WriteLine("==========================");
            Console.WriteLine("Starting a buyout auction");
            BuyOutAuction buyOutAuction = new BuyOutAuction(75M);
            buyOutAuction.PlaceBid(new Bid("Henry", 25));
            buyOutAuction.PlaceBid(new Bid("Mimi", 49));
            buyOutAuction.PlaceBid(new Bid("Eddie", 56));
            buyOutAuction.PlaceBid(new Bid("Henry", 125));
            buyOutAuction.PlaceBid(new Bid("Eddie", 135));


        }
    }
}
