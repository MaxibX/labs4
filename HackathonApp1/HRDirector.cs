using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonApp1.Models;

namespace HackathonApp1
{
    public class HRDirector
    {
        public Double CalculateHarm(List<Team> teams)
        {
            double sum = 0;

            foreach (var team in teams)
            {
                int teamLeadSatisfaction = team.TeamLead.getSatisfactionIndex(team.Junior.Id);
                int juniorSatisfaction = team.Junior.getSatisfactionIndex(team.TeamLead.Id);

                double harm = 2.0 / (1.0 / teamLeadSatisfaction + 1.0 / juniorSatisfaction);
                sum += harm;
            }

            return sum / teams.Count;
        }
    }
}
