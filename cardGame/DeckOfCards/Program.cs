using DeckOfCards.Classes;
using System;
using System.Net.Http.Headers;
using System.Reflection;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Card firstCard = new Card(8, "Hearts");

            Console.WriteLine($"The first card is the {firstCard.faceValue} of {firstCard.suit}.");

            Card secondCard = new Card(4, "Diamonds", true);

            Console.WriteLine($"The second card is the {secondCard.faceValue} of {secondCard.suit}.");

            //Flipping the card from the method in our class
            secondCard.Flip();



            //Working with a deck
            Deck deck = new Deck();
            for (int i = 0; i < deck.numberOfCardsInDeck; i++)
            {
                Card dealCard = deck.Deal1();
                dealCard.Flip();
                Console.WriteLine($"{dealCard.faceValue} of {dealCard.suit}");
            }
        }
    }
}
