using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGame
{
    public class GroupChat
    {
        private string _chatName { get; set; }
        public string ChatName
        {
            get
            {
                return _chatName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("");
                _chatName = value;
            }
        }
        private Dictionary<int, Account> AccountGroups = new Dictionary<int, Account>();
        public Account GetAccount(int AccountID) 
        {
            if (AccountGroups.ContainsKey(AccountID))
                return AccountGroups[AccountID];
            return null;
        }

        public void AddAccount(Account acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException("No acc was given");
            }
            else
            {
                if (!AccountGroups.ContainsKey(acc.AccountID))
                {
                    AccountGroups.Add(acc.AccountID, acc);
                    acc.AddToChat(this);
                }
                else
                {
                    throw new ArgumentNullException("Already belongs to an Chat");
                }
            }
        }

        public void RemoveAccount(Account acc)
        {
            if (acc == null)
            {
                throw new ArgumentNullException("Null account given");
            }
            else
            {
                AccountGroups.Remove(acc.AccountID);
            }
        }
    }
}
