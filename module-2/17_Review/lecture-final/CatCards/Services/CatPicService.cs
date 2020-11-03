using CatCards.Models;
using RestSharp;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatPicService : ICatPicService
    {
        private readonly string API_URL = "https://random-cat-image.herokuapp.com/";
        private readonly RestClient client = new RestClient();

        public CatPic GetPic()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatPic> response = client.Get<CatPic>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new HttpRequestException("Could not contact server, please try again later.");
            }
            else if (!response.IsSuccessful)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }
            else
            {
                return response.Data;
            }

        }
    }
}
