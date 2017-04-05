using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCardGame
{
    public class AccountGuild
    {
        private static List<AccountGuild> _extent = new List<AccountGuild>();
        public static List<AccountGuild> Extent
        {
            get
            {
                if (_extent == null)
                {
                    _extent = new List<AccountGuild>(AccountGuild.Extent);
                }

                return _extent;
            }
            set
            {
                _extent = value;
            }
        }
        private DateTime _joinDate { get; set; }
        public DateTime JoinDate
        {
            get
            {
                return _joinDate;
            }
            set => _joinDate = DateTime.Now;
        }

        public DateTime? LeaveDate { get; set; }

        private Account acc;
        private Guild guild;

        public void SetAccount(Account acc)
        {
            if (this.acc != acc)
            {
                this.acc = acc;
                this.acc.AddAccount(this);
            }
        }
        public void SetGuild(Guild guild)
        {
            if (this.guild != guild)
            {
                this.guild = guild;
                this.guild.AddGuild(this);
            }
        }
    }

}
