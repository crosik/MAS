using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGame
{
    public class Deck
    {
        private Account _owner { get; set; }
        private string _deckName { get; set; }
        private Dictionary<int,Account> AccountDecks = new Dictionary<int,Account>();
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
        public Deck(Account owner)
        {
            this._owner = owner;
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

        public void SetDeckOwner(Account acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException("No owner was given");
            }
            else
            {
                if (!AccountDecks.ContainsKey(acc.AccountID))
                {
                    AccountDecks.Add(acc.AccountID, acc);
                    acc.OwnerOfDeck(this);
                }
                else
                {
                    throw new ArgumentNullException("Already has a deck!");
                }
            }
        }

        public void RemoveOwner(Account acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException("Null account given");
            }
            else
            {
                AccountDecks.Remove(acc.AccountID);
            }
        }
    }
}
