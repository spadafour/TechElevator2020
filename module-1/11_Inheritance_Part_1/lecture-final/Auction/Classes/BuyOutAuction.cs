using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionProgram.Classes
{
    public class BuyOutAuction : Auction
    {
        private decimal buyoutPrice { get; set; }
        public decimal BuyOutPrice
        {
            get
            {
                return buyoutPrice;
            }
            set
            {
                buyoutPrice = value;
            }
        }

        public BuyOutAuction(decimal buyoutPrice) : base(0M)
        {
            BuyOutPrice = buyoutPrice;
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            bool isCurrentWinningBid = false;
            if(!hasEnded)
            {
                if(offeredBid.bidAmount >= buyoutPrice)
                {
                    Bid buyOutBid = new Bid(offeredBid.bidder, buyoutPrice);
                    isCurrentWinningBid = base.PlaceBid(buyOutBid);
                    Console.WriteLine("Buyout met by " + offeredBid.bidder);
                    EndAuction();
                } else
                {
                    isCurrentWinningBid = base.PlaceBid(offeredBid);
                }
            }
            return isCurrentWinningBid;
        }

    }
}
