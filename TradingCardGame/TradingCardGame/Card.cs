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
        //composition
        private HashSet<ArtDetail> CardArtDetails = new HashSet<Card.ArtDetail>();
        private class ArtDetail
        {
            private string _name { get; set; }
            private string _imgUrl { get; set; }

            public string Name
            {
                get
                { return _name; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentNullException("Name of detail cant be empty");

                    _name = value;

                }
            }

            public string ImgUrl
            {
                get
                { return _imgUrl; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentNullException("Name of detail cant be empty");

                    _imgUrl = value;

                }
            }
            public ArtDetail(string name, string imgUrl)
            {
                this.Name = name;
                this.ImgUrl = imgUrl;
            }
        }

        public void AddArtDetail(string name, string imgUrl)
        {
            CardArtDetails.Add(new ArtDetail(name, imgUrl));
        }

        public void RemoveArtDetail(string name)
        {
            if (name != null)
            {
                foreach (var ArtDetail in CardArtDetails)
                {
                    if (ArtDetail.Name.Equals(name))
                    {
                        CardArtDetails.Remove(ArtDetail);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Name should not be null");
            }
        }

        public List<String> GetCardArtDetails()
        {
            List<String> tmp = new List<String>();
            foreach(var ArtDetail in CardArtDetails)
            {
                tmp.Add(String.Format("Detail Name: {0}, ImageUrl: {1}", ArtDetail.Name, ArtDetail.ImgUrl));
            }
            return tmp;
        }

        //end of composition
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





        
    }
}
