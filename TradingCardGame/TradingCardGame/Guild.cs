using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGame
{
    public enum GuildRank
    {
        GM, GMAssist, Private
    }

    public class Guild
    {
        private static List<Guild> _extent = new List<Guild>();
        public static List<Guild> Extent
        {
            get
            {
                if (_extent == null)
                {
                    _extent = new List<Guild>(Guild.Extent);
                }

                return _extent;
            }
            set
            {
                _extent = value;
            }
        }
        private string _guildName { get; set; }
        public string GuildName
        {
            get
            {
                return _guildName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("");
                _guildName = value;
            }
        }
        private DateTime _createDate { get; set; }
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set => _createDate = DateTime.Now;
        }
         public GuildRank GuildRank { get; set; }

        private List<AccountGuild> AccountGuilds = new List<AccountGuild>();

        public List<AccountGuild> GetAccountGuilds()
        {
            return new List<AccountGuild>(AccountGuilds);
        }

        public void AddGuild(AccountGuild accG)
        {
            if (accG != null)
            {
                if (!AccountGuilds.Contains(accG))
                {
                    AccountGuilds.Add(accG);
                    accG.SetGuild(this);
                }
            }
        }
    }
}
