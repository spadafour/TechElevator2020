using CatCards.Models;
using RestSharp;
using System.Net.Http;

namespace CatCards.Services
{
    public class CatFactService : ICatFactService
    {
        private readonly string API_URL = "https://cat-fact.herokuapp.com/facts/random";
        private readonly RestClient client = new RestClient();

        public CatFact GetFact()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<CatFact> response = client.Get<CatFact>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new HttpRequestException("Could not contact server, please try again later.");
            }
            else if (!response.IsSuccessful)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            } else
            {
                return response.Data;
            }
        }
    }
}
