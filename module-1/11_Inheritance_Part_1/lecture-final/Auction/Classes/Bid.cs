using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionProgram.Classes
{
    public class Bid
    {
        /// <summary>
        /// This holds the name of the bidder
        /// </summary>
        public string bidder { get; }
        /// <summary>
        /// This holds the amount of the bid
        /// </summary>
        public decimal bidAmount { get; }

        /// <summary>
        /// Constructer for the Bid object. Each bid requires a bidder and a bidAmount
        /// </summary>
        /// <param name="bidder">Who placed the bid</param>
        /// <param name="bidAmount">How much the bid is for</param>
        public Bid(string bidder, decimal bidAmount)
        {
            this.bidder = bidder;
            this.bidAmount = bidAmount;
        }
    }
}
