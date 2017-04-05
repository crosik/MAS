using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGame
{
    public class Deck
    {
        private string _deckName { get; set; }
        public string DeckName {
            get
            {
                return _deckName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Deck name cant be null");

                _deckName = value;
            }
        }

        private static List<Card> Cards = new List<Card>();

        public void AddCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("card should not be null");
            }
            else if (Cards.Count >= 30)
            {
                throw new ArgumentNullException("Maximum number of cards reached.");
            }
            else
            {
                if (!Cards.Contains(card))
                {
                    Cards.Add(card);
                    card.AddToDeck(this);
                }
            }
        }

        public void RemoveCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("card musn't be null");
            }
            else
            {
                Cards.Remove(card);
            }
        }

        public List<Card> AllCardsInDeck
        {
            get { return Cards; }
        }

        private Account acc;

        public Account GetOwner()
        {
            return acc;
        }

        public void SetOwner(Account acc)
        {
            if (this.acc != acc)
            {
                if (this.acc != null)
                {
                    this.acc.RemoveDeck(this);
                }
                this.acc = acc;
                this.acc.AddDeck(this);
            }
        }

    }
}
