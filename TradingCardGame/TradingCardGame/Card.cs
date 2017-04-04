using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace TradingCardGame
{
    public enum CardRace
    {
        Dragon, Totem, Beast, Demon, Elemental, Mech, Pirate
    }
    public enum CardRarity
    {
        COMMON, RARE, EPIC, LEGENDARY
    }
    public class Card
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
            set
            {
                _extent = value;
            }
        }
        private CardRarity CardRarity { get; set; }
        private string _cardName { get; set; }
        public string CardName {
            get
            { return _cardName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Card name cant be empty");

                _cardName = value;

            }
        }

        public int CardHP { get; set; }
        public int CardDMG { get; set; }
        public int CardCost { get; set; }
        private string _cardEffect { get; set; }
        public string CardEffect
        {
            get
            { return _cardEffect; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Card effect cant be empty");

                _cardEffect = value;
            }
        }
        private string _cardDesc { get; set; }

        public string CardDesc
        {
            get
            { return _cardDesc; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Card description cant be empty");

                _cardDesc = value;
            }
        }
        public class CardText : System.Attribute {
            private string CardEffect { get; set; }
            private string CardDesc { get; set; }
            public CardText(string cardEffect, string cardDesc)
            {
                this.CardDesc = cardDesc;
                this.CardEffect = cardEffect;
            }
            public override string ToString()
            {
                return String.Format("{0} , {1}", this.CardEffect, this.CardDesc);
            }
        }
        private CardText CardTextz { get; set; }
        public int? CardOverload { get; set; }
        public int DmgModifier { get; set; }
        public int CardCurrentDMG => CardDMG + DmgModifier;
        public int HpModifier { get; set; }
        public int CardCurrentHP => CardHP + HpModifier;
        public HashSet<CardRace> CardRace { get; set; } = new HashSet<CardRace>();
        public int? CardCurrentCost => CardCost + CardOverload;
        public void AddRace(CardRace Race)
        {
            this.CardRace.Add(Race);
        }

        public void DeleteRace(CardRace Race)
        {
            this.CardRace.Remove(Race);
        }

        public Card(CardRarity cardRarity, string cardName, int cardHP, int cardDMG, int cardCost, string cardDesc, string cardEffect, int? cardOverload) {
            this.CardRarity = cardRarity;
            this.CardName = cardName;
            this.CardHP = cardHP;
            this.CardDMG = cardDMG;
            this.CardCost = cardCost;
            this.CardOverload = cardOverload;
            this.CardDesc = cardDesc;
            this.CardEffect = cardEffect;
            this.CardTextz = new CardText(cardEffect, cardDesc);
            Extent.Add(this);
        }
        private Card()
        {
            Extent.Add(this);
        }
        public override string ToString()
        {
            return String.Format("Card {0} is {1}, Description : {2}", this.CardName, this.CardRarity, this.CardDesc);
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
                    if (card.CardCurrentHP > minHP)
                    {
                        results.Add(card);
                    }
                }
                return results;
            }
           
            

        }

        public static void Save(List<Card> listOfCards)
        {
            string path = @"C:\Users\xross\Desktop\test.txt";
            FileStream outFile = File.Create(path);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Card>));
            formatter.Serialize(outFile, listOfCards);
        }
        public static void Load()
        {
            string file = @"C:\Users\xross\Desktop\test.txt";
            List<Card> listofa = new List<Card>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Card>));
            FileStream aFile = new FileStream(file, FileMode.Open);
            byte[] buffer = new byte[aFile.Length];
            aFile.Read(buffer, 0, (int)aFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            Extent = (List<TradingCardGame.Card>)formatter.Deserialize(stream);
        }

        //CARD -> DECK
        private HashSet<Deck> Decks = new HashSet<Deck>();
        public void AddToDeck(Deck deck)
        {
            if (deck == null)
            {
                throw new ArgumentNullException("deck cant be null");
            }
            else
            {
                if (!Decks.Contains(deck))
                {
                    Decks.Add(deck);
                    deck.AddCard(this);
                }
            }
        }





        static void Main(string[] args)
        {
            //Card xd = new Card(CardRarity.COMMON, "Stronk", 10, 10, 10, "Mocna karta", "Podpalenie", 2);
            //Card xp = new Card(CardRarity.RARE, "Stornker", 20, 20, 20, "Mocniejsza karta", "Stun", 2);
            //Card xz = new Card(CardRarity.EPIC, "Stronkiests", 30, 30, 30, "Najmocniejsza karta jk", "Taunt", 2);
            //Card xc = new Card(CardRarity.COMMON, "Cos", 10, 10, 10, "Jakis opis", "Silence", 2);
            //Card xa = new Card(CardRarity.COMMON, "Tutaj", 10, 10, 10, "watever", "Deathrattle", 2);
            //Card xw = new Card(CardRarity.COMMON, "Nie Gra", 10, 10, 10, "xdxp", "Random", 2);
            //Save(Extent);
            Load();
            
            ShowAllCards();
            Thread.Sleep(500000);
            
           
            
 

        }
    }
}
