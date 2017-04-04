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
        private Deck deck;
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

        public void OwnerOfDeck(Deck deck)
        {
            if (deck == null)
            {
                throw new ArgumentNullException("Null company given");
            }
            else
            {
                this.deck = deck;
                deck.SetDeckOwner(this);
            }
        }



    }
}
