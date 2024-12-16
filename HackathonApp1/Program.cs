using HackathonApp1.Models;
using HackathonApp1;

namespace HackathonApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var juniors = Input.ReadParticipants<Junior>("C:\\Users\\Mxn\\source\\repos\\labs4\\HackathonApp1\\Juniors20.csv");
            var teamLeads = Input.ReadParticipants<TeamLead>("C:\\Users\\Mxn\\source\\repos\\labs4\\HackathonApp1\\Teamleads20.csv");

            var hrManager = new HRManager(juniors, teamLeads);
            var hrDirector = new HRDirector();
            double totalHarm = 0;
            int hackathonsCount = 1000;

            for (int i = 0; i < hackathonsCount; i++)
            {
                PreferenceGenerator.GenerateRandomPreferences(juniors, teamLeads);
                var teams = hrManager.Teams();
                double harm = hrDirector.CalculateHarm(teams);
                Console.WriteLine($"Hackathon {i + 1}: {harm:F4}");
                totalHarm += harm;               
            }

            double avgHarm = totalHarm / hackathonsCount;
            Console.WriteLine($"Average harm of {hackathonsCount} hackathons: {avgHarm:F4}");
        }
    }
}