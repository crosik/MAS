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
        private static List<Card> _extent = new List<Card>();
        public static List<Card> Extent
        {
            get
            {
                if (_extent == null)
                {
                    _extent = new List<Card>(Card.Extent);
                }

                return _extent;
            }
        }
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
        private int dmgModifier { get; set; }
        private int cardCurrentDMG => cardDMG + dmgModifier;
        private int hpModifier { get; set; }
        private int cardCurrentHP => cardHP + hpModifier;
        private HashSet<CardRace> cardRace { get; set; } = new HashSet<CardRace>();
        public void AddRace(CardRace Race)
        {
                this.cardRace.Add(Race);
        }

        public void DeleteRace(CardRace Race)
        {
                this.cardRace.Remove(Race); 
        }
        private Card() : base() { 
                Extent.Add(this);
            }
        public Card(CardRarity cardRarity, string cardName, int cardHP, int cardDMG, int cardCost, string cardDesc, int? cardOverload) { 
            this.cardRarity = cardRarity;
            this.cardName = cardName;
            this.cardHP = cardHP;
            this.cardDMG = cardDMG;
            this.cardCost = cardCost;
            this.cardDesc = cardDesc;
            this.cardOverload = cardOverload;
        }
        public override string ToString()
        {
            return String.Format("Card {0} is {1}, Description : {2}", this.cardName, this.cardRarity, this.cardDesc);
        }

        public static void ShowAllCards()
        {
            foreach (var card in Extent)
            {
                Console.WriteLine(card.ToString());
            }
        }

        public static List<Card> getCards()
        {
            List<Card> tmp = new List<Card>(Card.Extent);
            return tmp;
        }

        public static List<Card> getCards(int? minHP)
        {
            List<Card> tmp = new List<Card>(Card.Extent);
            if (minHP == null)
            {
                return tmp;
            }
            else
            {
                List<Card> results = new List<Card>();
                foreach (var card in Extent)
                {
                    if (card.cardCurrentHP > minHP)
                    {
                        results.Add(card);
                    }
                }
                return results;
            }
        }


        static void Main(string[] args)
        {
        }
    }
}
