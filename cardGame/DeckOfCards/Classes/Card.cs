using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Card
    {
        public int faceValue
        {
            get
            {
                if (!isFaceUp)
                {
                    return -1;
                }
                else
                {
                    return _faceValue;

                }
            }
            private set
            {
                if (value>13 || value <0)
                {
                    _faceValue = 0;
                }
                else
                {
                    _faceValue = value;
                }
            }
        }
        //this is a backing variable
        private int _faceValue { get; set; }





        public static List<string> suitNames = new List<string>()
        {
            "Spades", "Hearts", "Diamonds", "Clubs"
        };
        private string _suit { get; set; }
        public string suit
        {
            get { return isFaceUp ? _suit : "Card is not face up"; }
            set
            {
                if (suitNames.Contains(value))
                {
                    _suit = value;
                }
            }
        }
    
        public string color
        {
            get
            {
                if (_suit=="Hearts" || _suit=="Diamonds")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            } 
        }



        //{get; set;} means this info can be set at any time, not just at declaration
        public bool isFaceUp { get; private set; }
        //if you want variable only changeable and accessible within methods in class itself: { get; private set; }

        public void Flip()
        {
            if (isFaceUp)
            {
                isFaceUp = false;
            }
            else
            {
                isFaceUp = true;
            }
        }

        public Card(int cardValue, string suitValue)
        {
            faceValue = cardValue;
            suit = suitValue;
        }

        public Card (int cardValue, string suitValue, bool isFaceUp)
        {
            faceValue = cardValue;
            suit = suitValue;
            //keyword 'this' references the properties in THIS object
            this.isFaceUp = isFaceUp;
        }

       

 
    }
}
