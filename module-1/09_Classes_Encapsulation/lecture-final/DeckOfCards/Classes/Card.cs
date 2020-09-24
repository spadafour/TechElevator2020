using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Card
    {
        // this is a backing variable
        private int _faceValue { get; set; }
        // no set means it can only be set through constuctor
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
                if (value > 13 || value < 0)
                {
                    _faceValue = -1;
                }
                else
                {
                    _faceValue = value;
                }
            }
        }

        private string _suit { get; set; }
        public string suit
        {
            get { return isFaceUp ? _suit : "Card is Face Down"; }
            set
            {
                if (suitNames.Contains(value))
                {
                    _suit = value;
                }
            }
        }

        // derived property
        // Return value based on other values
        public string Color
        {
            get
            {
                if(_suit == "Hearts" || _suit == "Diamonds")
                {
                    return "Red";
                } else
                {
                    return "Black";
                }
            }
        }
        // private means only accessible through methods in this class.
        public bool isFaceUp { get; private set; }

        public Card(int faceValue, string suitValue, bool isFaceUp)
        {
            this.faceValue = faceValue;
            suit = suitValue;
            // keyword this references the properties in THIS object
            this.isFaceUp = isFaceUp;
        }

        public Card(int cardValue, string suitValue)
        {
            faceValue = cardValue;
            suit = suitValue;
        }

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

        // overloaded method
        public void Flip(bool shouldBeFaceDown)
        {
            isFaceUp = !shouldBeFaceDown;
        }
        // short cut for creating a list with known items
        public static List<string> suitNames = new List<string>() { "Spades", "Diamonds", "Hearts", "Clubs" };

    }
}
