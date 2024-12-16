using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonApp1.Models
{
    public class Team
    {
        public TeamLead TeamLead { get; private set; }
        public Junior Junior { get; private set; }
        public Team(TeamLead teamLead, Junior junior)
        {
            TeamLead = teamLead;
            Junior = junior;
        }
    }
}
