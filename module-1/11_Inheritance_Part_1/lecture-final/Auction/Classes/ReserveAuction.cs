using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionProgram.Classes
{
    public class ReserveAuction : Auction
    {
        private decimal reservePrice { get; }

        public ReserveAuction(decimal reservePrice) : base(0M)
        {
            this.reservePrice = reservePrice;
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            bool isCurrentWinningBid = false;
            if(offeredBid.bidAmount >= reservePrice)
            {
                isCurrentWinningBid = base.PlaceBid(offeredBid);
                Console.WriteLine("Reserve has been met");
                Console.WriteLine();
            }
            else
            {
                allBids.Add(offeredBid);
                isCurrentWinningBid = false;
                Console.WriteLine("Reserve has not been met");
                Console.WriteLine();

            }
            return isCurrentWinningBid;
        }

    }
}
