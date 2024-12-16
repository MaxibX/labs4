using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonApp1.Models;

namespace HackathonApp1
{
    public class HRManager
    {
        public List<Junior> Juniors {  get; private set; }
        public List<TeamLead> TeamLeads { get; private set; }
        public int TeamsCount { get; private set; }
        
        public HRManager(List<Junior> juniors, List<TeamLead> teamLeads, int teamsCount = 20)
        {
            Juniors = juniors;
            TeamLeads = teamLeads;
            TeamsCount = teamsCount;
        }

        public List<Team> Teams()
        {
            var teams = new List<Team>();
            var freeTeamLeads = new Queue<TeamLead>(TeamLeads);
            var juniorsPartners = new Dictionary<Junior, TeamLead>();
            var teamLeadsProposals = TeamLeads.ToDictionary(tl => tl, tl => new HashSet<string>());

            while (freeTeamLeads.Count > 0)
            {
                var teamLead = freeTeamLeads.Dequeue();

                var juniorToPropose = Juniors.Where(j => !teamLeadsProposals[teamLead].Contains(j.Id)).OrderByDescending(j => teamLead.getSatisfactionIndex(j.Id)).First();

                if (juniorToPropose == null)
                {
                    continue;
                }

                teamLeadsProposals[teamLead].Add(juniorToPropose.Id);

                if (!juniorsPartners.ContainsKey(juniorToPropose))
                {
                    juniorsPartners[juniorToPropose] = teamLead;
                    teams.Add(new Team(teamLead, juniorToPropose));
                }
                else
                {
                    var currentTeamLead = juniorsPartners[juniorToPropose];

                    if (juniorToPropose.getSatisfactionIndex(teamLead.Id) > juniorToPropose.getSatisfactionIndex(currentTeamLead.Id))
                    {
                        juniorsPartners[juniorToPropose] = teamLead;
                        freeTeamLeads.Enqueue(currentTeamLead);

                        teams.RemoveAll(t => t.TeamLead == currentTeamLead);
                        teams.Add(new Team(teamLead, juniorToPropose));
                    }
                    else
                    {
                        freeTeamLeads.Enqueue(teamLead);
                    }
                }
            }
            return teams;
        }
    }
}
