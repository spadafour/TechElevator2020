using System.ComponentModel.DataAnnotations;

namespace HotelReservations.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Address Address { get; set; }
        public int Stars { get; set; }
        [Required]
        public int RoomsAvailable { get; set; }
        public decimal CostPerNight { get; set; }
        public string CoverImage { get; set; }
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        public Hotel(int id, string name, Address address, int stars, int rooms, decimal cost, string image)
        {
            Id = id;
            Name = name;
            Address = address;
            Stars = stars;
            RoomsAvailable = rooms;
            CostPerNight = cost;
            CoverImage = image;
        }

    }
}
