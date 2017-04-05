using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGame
{
    public class Account
    {

        public Account(int AccountID, string accLogin, string accPass)
        {
            this.AccountID = AccountID;
            this.AccountLogin = accLogin;
            this.Password = accPass;
            Extent.Add(this);
        }
        private static List<Account> _extent = new List<Account>();
        public static List<Account> Extent
        {
            get
            {
                if (_extent == null)
                {
                    _extent = new List<Account>(Account.Extent);
                }

                return _extent;
            }
            set
            {
                _extent = value;
            }
        }
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
                deck.RemoveOwner();
            }
        }

        private List<AccountGuild> AccountGuilds = new List<AccountGuild>();

        public List<AccountGuild> GetAccountGuilds()
        {
            return new List<AccountGuild>(AccountGuilds);
        }

        public void AddAccount(AccountGuild accG)
        {
            if (accG != null)
            {
                if (!AccountGuilds.Contains(accG))
                {
                    AccountGuilds.Add(accG);
                    accG.SetAccount(this);
                }
            }
        }

    }
}
