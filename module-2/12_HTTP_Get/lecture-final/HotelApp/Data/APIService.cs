using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP_Web_Services_GET_lecture.Data
{
    public class APIService
    {
        private readonly string API_URL = "";
        private RestClient client = new RestClient();
        public APIService(string api_url)
        {
            API_URL = api_url;
        }

        public List<Hotel> GetHotels()
        {
            RestRequest request = new RestRequest(API_URL + "hotels");
            IRestResponse<List<Hotel>> response = client.Get<List<Hotel>>(request);
            return response.Data;
        }

        public List<Review> GetReviews()
        {
            RestRequest request = new RestRequest(API_URL + "reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            return response.Data;
        }

        public Hotel GetDetailsForHotel(int hotelID)
        {
            RestRequest request = new RestRequest(API_URL + "hotels/" + hotelID);
            IRestResponse<Hotel> response = client.Get<Hotel>(request);
            return response.Data;
        }

        public List<Review> GetReviewsForHotel(int hotelID)
        {
            RestRequest request = new RestRequest(API_URL + "hotels/" + hotelID + "/reviews");
            IRestResponse<List<Review>> response = client.Get<List<Review>>(request);
            return response.Data;
        }

        public City GetPublicAPIQuery()
        {
            RestRequest request = new RestRequest("https://api.teleport.org/api/cities/geonameid:5206379");
            IRestResponse<City> response = client.Get<City>(request);
            return response.Data;
        }
    }
}
