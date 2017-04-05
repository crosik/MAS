using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGame
{
    public class Account
    {
        public int AccountID { get; set; }
        private string _accountLogin { get; set; }
        private GroupChat chat;
        public string AccountLogin
        {
            get
            { return _accountLogin; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Account login cant be empty");

                _accountLogin = value;
            }
        }
        private string _password { get; set; }
        public string Password
        {
            get
            { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Password cant be empty");

                _password = value;
            }
        }

        public void AddToChat(GroupChat chat)
        {
            if (chat == null)
            {
                throw new ArgumentNullException("No chat name given");
            }
            else
            {
                this.chat = chat;
                chat.AddAccount(this);
            }
        }

        private List<Deck> decks = new List<Deck>();

        public List<Deck> GetDecks()
        {
            return new List<Deck>(decks);
        }

        public void AddDeck(Deck deck)
        {
            if (deck != null)
            {
                if (!decks.Contains(deck))
                {
                    decks.Add(deck);
                    deck.SetOwner(this);
                }
            }
        }

        public void RemoveDeck(Deck deck)
        {
            if (decks.Contains(deck))
            {
                decks.Remove(deck);
                deck.SetOwner(null);
            }
        }




    }
}
