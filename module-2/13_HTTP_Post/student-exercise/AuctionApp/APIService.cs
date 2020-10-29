using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AuctionApp
{
    public class APIService
    {
        const string API_URL = "http://localhost:3000/auctions";
        readonly IRestClient client;

        public APIService()
        {
            client = new RestClient();
        }
        public APIService(IRestClient restClient)
        {
            client = restClient;
        }

        public List<Auction> GetAllAuctions()
        {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public Auction GetDetailsForAuction(int auctionId)
        {
            RestRequest requestOne = new RestRequest(API_URL + "/" + auctionId);
            IRestResponse<Auction> response = client.Get<Auction>(requestOne);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public List<Auction> GetAuctionsSearchTitle(string searchTitle)
        {
            RestRequest request = new RestRequest(API_URL + "?title_like=" + searchTitle);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public List<Auction> GetAuctionsSearchPrice(double searchPrice)
        {
            RestRequest request = new RestRequest(API_URL + "?currentBid_lte=" + searchPrice);
            IRestResponse<List<Auction>> response = client.Get<List<Auction>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public Auction AddAuction(Auction newAuction) {
            RestRequest request = new RestRequest(API_URL);
            IRestResponse<Auction> response = client.Post<Auction>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
            return null;
        }

        public Auction UpdateAuction(Auction auctionToUpdate)
        {
            RestRequest request = new RestRequest(API_URL + auctionToUpdate);
            if (auctionToUpdate.IsValid)
            {
                request.AddJsonBody(auctionToUpdate);
            }
            else
            {
                return null;
            }
            IRestResponse<Auction> response = client.Put<Auction>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }
            else if (!response.IsSuccessful)
            {
                return null;
            }
            else
            {
                return response.Data;
            }
        }

        public bool DeleteAuction(int auctionId)
        {
            RestRequest request = new RestRequest(API_URL + auctionId);
            IRestResponse response = client.Delete(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return false;
            }
            else if (!response.IsSuccessful)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
