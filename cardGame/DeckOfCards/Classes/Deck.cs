using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Deck
    {
        public int numberOfCardsInDeck { get; private set; }
        
        private List<Card> AllCards { get; set; } = new List<Card>();

        public Deck()
        {
            foreach (string suit in Card.suitNames)
            {
                for (int i=1; i<14; i++)
                {
                    Card card = new Card(i, suit);
                    AllCards.Add(card);
                    numberOfCardsInDeck++;
                }
            }
        }

        public Card Deal1()
        {
            Card cardToBeDealt = AllCards[0];
            AllCards.RemoveAt(0);
            return AllCards[0];
            
        }


        public void Shuffle()
        {
            Random r = new Random();
            for (int i=0; i <100; i++)
            {
                int randomSpot1 = r.Next(AllCards.Count - 1);
                int randomSpot2 = r.Next(AllCards.Count - 1);
                //swap to cards at those spots
                Card temp = AllCards[randomSpot2];
                AllCards[randomSpot2] = AllCards[randomSpot1];
                AllCards[randomSpot1] = temp;
            }
        }
    }
}
