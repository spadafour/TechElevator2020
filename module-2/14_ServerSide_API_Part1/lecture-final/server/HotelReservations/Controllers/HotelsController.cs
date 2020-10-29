using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("/")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static IHotelDao _hotelDao;
        private static IReservationDao _reservationDao;

        public HotelsController()
        {
            _hotelDao = new HotelDao();
            _reservationDao = new ReservationDao();
        }

        [HttpGet("hotels")]
        public List<Hotel> ListHotels()
        {
            return _hotelDao.List();
        }

        [HttpGet("hotels/{id}")]
        public Hotel GetHotel(int id)
        {
            Hotel hotel = _hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }

            return null;
        }

        [HttpGet("reservations")]
        public List<Reservation> GetReservations()
        {
            return _reservationDao.List();
        }

        [HttpGet("reservations/{id}")]
        public Reservation Fred(int id)
        {
            Reservation reservation = _reservationDao.Get(id);
            if (reservation != null)
            {
                return reservation;
            }
            return null;
        }

        [HttpGet("hotels/{hotelid}/reservations")]
        public List<Reservation> GetReservations(int hotelid)
        {
            return _reservationDao.FindByHotel(hotelid);
        }

        [HttpPost("reservations")]
        public Reservation AddReservation(Reservation reservation)
        {
            Reservation output = _reservationDao.Create(reservation);
            return output;
        }

        [HttpGet("hotels/filter")]
        public List<Hotel> FilterByStateOrCity(string state, string city)
        {
            List<Hotel> output = _hotelDao.FilterByStateOrCity(state, city);
            return output;
        }
    }
}
