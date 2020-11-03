using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatCards.DAO;
using CatCards.Models;
using CatCards.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICatCardDAO cardDAO;
        private readonly ICatFactService catFactService;
        private readonly ICatPicService catPicService;

        public CardsController(ICatCardDAO _cardDAO, ICatFactService _catFact, ICatPicService _catPic)
        {
            catFactService = _catFact;
            catPicService = _catPic;
            cardDAO = _cardDAO;
        }

        [HttpGet]
        public ActionResult<List<CatCard>> GetAllCards()
        {
            return Ok(cardDAO.GetAllCards());
        }

        [HttpGet("{id}")]
        public ActionResult<CatCard> GetKittyCat(int id)
        {
            CatCard card = cardDAO.GetCard(id);
            if (card != null)
            {
                return Ok(card);
            } else
            {
                return NotFound();
            }
        }

        [HttpGet("random")]
        public ActionResult<CatCard> GetRandomCatCard()
        {
            try
            {
                CatFact fact = catFactService.GetFact();
                CatPic pic = catPicService.GetPic();

                CatCard card = new CatCard()
                {
                    CatFact = fact.Text,
                    ImgUrl = pic.File
                };

                return Ok(card);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public ActionResult<CatCard> SaveCard(CatCard incomingCard)
        {
            CatCard newCard = cardDAO.SaveCard(incomingCard);
            return Created("/api/cards/" + newCard.CatCardId, newCard);
        }

        [HttpPut("{id}")]
        public ActionResult<CatCard> UpdateCatCard(int id, CatCard changedCard)
        {
            if (cardDAO.GetCard(id) != null)
            {
                if (changedCard.CatCardId == id)
                {
                    return Ok(cardDAO.UpdateCard(changedCard));
                }
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCard(int id)
        {
            if (cardDAO.GetCard(id) != null)
            {
                if (cardDAO.RemoveCard(id))
                {
                    return NoContent();
                }
            } else
            {
                return NotFound();
            }
            return BadRequest();
        }
    }
}
