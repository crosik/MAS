using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TradingCardGame
{
    class Card
    {
        private static List<Card> extent = new List<Card>();
        private CardRarity cardRarity {
            get
            {
                return cardRarity;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    throw new ArgumentNullException();

                cardRarity = value;
            }     
        }
        private string cardName {
            get
            { return cardName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();

                cardName = value;
            }
        }

        private int cardHP { get; set; }
        private int cardDMG { get; set; }
        private int cardCost { get; set; }

        private string cardDesc
        {
            get
            { return cardDesc; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();

                cardDesc = value;
            }
        }
        private int? cardOverload { get; set; }
        private Card()
        {
            Card.extent.Add(this);
        }
        public Card(CardRarity cardRarity, string cardName, int cardHP, int cardDMG, int cardCost, string cardDesc, int? cardOverload) {
            Card();
            this.cardRarity = cardRarity;
            this.cardName = cardName;
            this.cardHP = cardHP;
            this.cardDMG = cardDMG;
            this.cardCost = cardCost;
            this.cardDesc = cardDesc;
            this.cardOverload = cardOverload;
        }
        
        static void Main(string[] args)
        {
        }
    }
}
