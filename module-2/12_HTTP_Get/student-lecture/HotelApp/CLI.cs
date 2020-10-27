using HTTP_Web_Services_GET_lecture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTTP_Web_Services_GET_lecture
{
    public class CLI
    {
        private APIService apiService { get; }

        public CLI(APIService apiService)
        {
            this.apiService = apiService;
        }
        public void Run()
        {
            Console.WriteLine("Welcome to Online Hotels! Please make a selection:");
            MenuSelection();
        }

        public void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                const int List_Hotels = 1;
                const int List_Reviews = 2;
                const int Details_Hotel1 = 3;
                const int Reviews_Hotel1 = 4;
                const int Hotels_With_3 = 5;
                const int PubicAPI = 6;

                Console.WriteLine("");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: List Hotels");
                Console.WriteLine("2: List Reviews");
                Console.WriteLine("3: Show Details for Hotel ID 1");
                Console.WriteLine("4: List Reviews for Hotel ID 1");
                Console.WriteLine("5: List Hotels with star rating 3");
                Console.WriteLine("6: Public API Query");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Only input a number.");
                }
                else if (menuSelection == List_Hotels)
                {
                    Console.Clear();
                    PrintHotels(apiService.GetHotels());
                }
                else if (menuSelection == List_Reviews)
                {
                    Console.Clear();
                    PrintReviews(apiService.GetReviews());
                }
                else if (menuSelection == Details_Hotel1)
                {
                    Console.Clear();
                    PrintHotel(apiService.GetDetailsForHotel(1));
                }
                else if (menuSelection == Reviews_Hotel1)
                {
                    Console.Clear();
                    PrintReviews(apiService.GetReviewsForHotel(1));
                }
                else if (menuSelection == Hotels_With_3)
                {
                    Console.Clear();
                    PrintHotels(apiService.GetHotelsWithStarRating(3));
                }
                else if (menuSelection == PubicAPI)
                {
                    Console.Clear();
                    PrintCity(apiService.GetPublicAPIQuery());
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }
        }


        //Print methods:

        public void PrintHotels(List<Hotel> hotels)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotels");
            Console.WriteLine("--------------------------------------------");
            foreach (Hotel hotel in hotels ?? new List<Hotel>())
            {
                Console.WriteLine(hotel.Id + ": " + hotel.Name);
            }
        }

        public void PrintHotel(Hotel hotel)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Hotel Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + hotel?.Id);
            Console.WriteLine(" Name: " + hotel?.Name);
            Console.WriteLine(" Stars: " + hotel?.Stars);
            Console.WriteLine(" Rooms Available: " + hotel?.RoomsAvailable);
            Console.WriteLine(" Cover Image: " + hotel?.CoverImage);
        }

        public void PrintReviews(List<Review> reviews)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Review Details");
            Console.WriteLine("--------------------------------------------");
            foreach (Review review in reviews ?? new List<Review>())
            {
                Console.WriteLine(" Hotel ID: " + review.HotelID);
                Console.WriteLine(" Title: " + review.Title);
                Console.WriteLine(" Review: " + review.ReviewText);
                Console.WriteLine(" Author: " + review.Author);
                Console.WriteLine(" Stars: " + review.Stars);
                Console.WriteLine("---");
            }
        }
        public void PrintCity(City city)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("City Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Full Name: " + city?.Full_name);
            Console.WriteLine(" Geoname Id: " + city?.Geoname_id);
        }

    }
}
