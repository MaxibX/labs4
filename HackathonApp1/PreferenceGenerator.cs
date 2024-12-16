using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonApp1.Models;

namespace HackathonApp1
{
    public class PreferenceGenerator
    {
        public static void GenerateRandomPreferences(List<Junior> juniors, List<TeamLead> teamLeads)
        {
            var random = new Random();

            foreach (var junior in juniors)
            {
                var uniqueRatings = Enumerable.Range(1, teamLeads.Count).OrderBy(_ => random.Next()).ToList();

                for (int i = 0; i < teamLeads.Count; i++)
                {
                    junior.addToWishList(teamLeads[i].Id, uniqueRatings[i]);
                }
            }

            foreach (var teamLead in teamLeads)
            {
                var uniqueRatings = Enumerable.Range(1, juniors.Count).OrderBy(_ => random.Next()).ToList();

                for (int i = 0; i < juniors.Count; i++)
                {
                    teamLead.addToWishList(juniors[i].Id, uniqueRatings[i]);
                }
            }
        }
    }
}
