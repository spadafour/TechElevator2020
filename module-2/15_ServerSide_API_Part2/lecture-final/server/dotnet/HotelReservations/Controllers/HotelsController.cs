using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;
using System.Linq;

namespace HotelReservations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static IHotelDao hotelDao;
        private static IReservationDao reservationDao;

        public HotelsController(IHotelDao _hotelDao, IReservationDao _reservationDao)
        {
            hotelDao = _hotelDao;
            reservationDao = _reservationDao;
        }

        [HttpGet]
        public List<Hotel> ListHotels()
        {
            return hotelDao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            Hotel hotel = hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("filter")]
        public List<Hotel> FilterByStateAndCity(string state, string city)
        {
            List<Hotel> filteredHotels = new List<Hotel>();

            List<Hotel> hotels = ListHotels();
            // return hotels that match state
            List<Hotel> filteredByCity = hotels.Where(h => h.Address.City.ToLower().Equals(city?.ToLower())).ToList();

            //List<Hotel> filteredAgain = hotels.Where(h => HasCity(h, city)).ToList();

            //foreach (Hotel item in hotels)
            //{
            //    if (HasCity(item,city))
            //    {
            //        filteredHotels.Add(item);
            //    }
            //}
            List<Hotel> filteredByState = hotels.Where(h => h.Address.State.ToLower().Equals(state?.ToLower() ?? "")).ToList();

            filteredHotels.AddRange(filteredByCity);
            filteredHotels.AddRange(filteredByState);

            foreach (Hotel hotel in hotels)
            {
                if (city != null)
                {
                    // if city was passed we don't care about the state filter
                    if (hotel.Address.City.ToLower().Equals(city.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
                else
                {
                    if (hotel.Address.State.ToLower().Equals(state.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
            }
            return filteredHotels;
        }

        [HttpGet("{hotelId}/reservations")]
        public ActionResult<List<Reservation>> ListReservationsByHotel(int hotelId)
        {
            Hotel hotel = hotelDao.Get(hotelId);
            if (hotel == null)
            {
                return NotFound("Hotel Id is invalid");
            }
            return reservationDao.FindByHotel(hotelId);
        }

        private bool HasCity(Hotel hotel, string city)
        {
            return hotel.Address.City.ToLower().Equals(city?.ToLower());
        }

    }
}
