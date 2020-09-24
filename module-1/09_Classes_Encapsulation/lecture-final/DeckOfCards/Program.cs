using DeckOfCards.Classes;
using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Card firstCard = new Card(8,"Hearts",true);

            if (firstCard.isFaceUp)
            {
                Console.WriteLine($"The card you picked is the {firstCard.faceValue} of {firstCard.suit} it is a {firstCard.Color} card.");
            }
            else
            {
                Console.WriteLine("Hey, are you trying to cheat?");
            }

            Card secondCard = new Card(4,"Diamonds");

            if(secondCard.isFaceUp)
            {
                Console.WriteLine($"The card you picked is the {secondCard.faceValue} of {secondCard.suit}");
            } else
            {
                Console.WriteLine("Hey, are you trying to cheat?");
            }

            secondCard.Flip();

            if (secondCard.isFaceUp)
            {
                Console.WriteLine($"The card you picked is the {secondCard.faceValue} of {secondCard.suit}");
            }
            else
            {
                Console.WriteLine("Hey, are you trying to cheat?");
            }

            // Let's work with a deck
            Deck deck = new Deck();
            for(int i=0; i < deck.numberOfCardsInDeck; i++)
            {
                Card dealtCard = deck.DealOne();
                dealtCard.Flip(false);
                Console.WriteLine($"The card you dealt is the {dealtCard.faceValue} of {dealtCard.suit}");

            }
            Console.WriteLine();
            Console.WriteLine("Shuffling");
            deck = new Deck();
            deck.Shuffle();
            for (int i = 0; i < deck.numberOfCardsInDeck; i++)
            {
                Card dealtCard = deck.DealOne();
                dealtCard.Flip(false);
                Console.WriteLine($"The card you dealt is the {dealtCard.faceValue} of {dealtCard.suit}");

            }


        }
    }
}
