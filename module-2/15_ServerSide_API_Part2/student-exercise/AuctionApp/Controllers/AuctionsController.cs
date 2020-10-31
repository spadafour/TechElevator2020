using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.DAO;
using Microsoft.EntityFrameworkCore.Internal;

namespace AuctionApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionDao dao;

        public AuctionsController(IAuctionDao auctionDao)
        {
            dao = auctionDao;
        }

        [HttpGet]
        public List<Auction> List(string title_like = "", double currentBid_lte = 0)
        {
            if (title_like != "")
            {
                return dao.SearchByTitle(title_like);
            }
            if (currentBid_lte > 0)
            {
                return dao.SearchByPrice(currentBid_lte);
            }

            return dao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Auction> Get(int id)
        {
            Auction auction = dao.Get(id);
            if (auction != null)
            {
                return Ok(auction);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Auction> Create(Auction auction)
        {
            Auction added = dao.Create(auction);
            return Created($"/{added.Id}", added);
        }

        [HttpPut("{id}")]
        public ActionResult<Auction> Update(int id, Auction auction)
        {
            Auction auctionToUpdate = dao.Get(id);
            if (auctionToUpdate == null)
            {
                return NotFound($"Auction {id} does not exist.");
            }
            else
            {
                Auction updatedAuction = dao.Update(id, auction);
                return Ok(updatedAuction);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Auction auctionToDelete = dao.Get(id);
            if (auctionToDelete == null)
            {
                return NotFound($"Auction {id} does not exist.");
            }
            else
            {
                return NoContent();
            }
        }
    }
}
