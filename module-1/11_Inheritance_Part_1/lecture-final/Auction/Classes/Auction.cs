using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionProgram.Classes
{
    public class Auction
    {
        public Auction(decimal startingPoint)
        {
            currentHighBid = new Bid("", startingPoint);
        }
        /// <summary>
        /// Holds all bids made. Property is private to protect the list
        /// </summary>
        protected List<Bid> allBids { get; set; } = new List<Bid>();
        /// <summary>
        /// Holds the current high bid. It is private to protect the data integrity
        /// </summary>
        private Bid currentHighBid { get; set; } = new Bid("", 0);
        /// <summary>
        /// Public drived property to get the current high bid
        /// </summary>
        public Bid CurrentHighBid
        {
            get
            {
                return currentHighBid;
            }
        }

        /// <summary>
        /// This derived property allows access to the data in the allBids list
        /// </summary>
        public Bid[] AllBids
        {
            get { return allBids.ToArray(); }
        }

        public virtual bool PlaceBid(Bid offeredBid)
        {
            bool isBidPlaced = false;
            Console.WriteLine("Placing a bid by " + offeredBid.bidder + " for $" + offeredBid.bidAmount);
            if(!hasEnded)
            {
                // Record the bid
                allBids.Add(offeredBid);

                // Find out if the new bid is the highest bid
                if(offeredBid.bidAmount > currentHighBid.bidAmount)
                {
                    currentHighBid = offeredBid;
                    isBidPlaced = true;
                }

                Console.WriteLine("Current high bid is " + currentHighBid.bidder + " for $" + currentHighBid.bidAmount);
            }
            return isBidPlaced;
        }
        public bool hasEnded { get; private set; }
        /// <summary>
        /// Method to end the auction
        /// </summary>
        protected void EndAuction()
        {
            hasEnded = true;
            Console.WriteLine($"The winning bid goes to {currentHighBid.bidder} for {currentHighBid.bidAmount:C2}");
        }
    }
}
