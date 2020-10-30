using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservations.Dao;
using HotelReservations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private static IReservationDao reservationDao;

        public ReservationsController(IReservationDao _reservationDao)
        {
            reservationDao = _reservationDao;
        }

        [HttpGet]
        public List<Reservation> ListReservations()
        {
            return reservationDao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {
            Reservation reservation = reservationDao.Get(id);

            if (reservation != null)
            {
                return reservation;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Reservation> AddReservation(Reservation reservation)
        {
            if(reservation.CheckinDate == null)
            {
                return BadRequest();
            }
            Reservation added = reservationDao.Create(reservation);
            return Created($"/reservations/{added.Id}", added);
        }

        [HttpPut("{id}")]
        public ActionResult<Reservation> UpdateReseravtion(int id, Reservation reservation)
        {
            Reservation existingReservation = reservationDao.Get(id);
            if (existingReservation == null)
            {
                return NotFound($"Reservation id {id} doesn't exist");
            }

            Reservation result = reservationDao.Update(id, reservation);
            return Ok(result);
        }

    }
}
