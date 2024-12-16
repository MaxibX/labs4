using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HackathonApp1
{
    public class Input
    {
        public static List<Developer> ReadParticipants<Developer>(string filePath)
        {
            var developers = new List<Developer>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var lineParts = line.Split(';');
                var developer = (Developer)Activator.CreateInstance(typeof(Developer), lineParts[0], lineParts[1]);
                developers.Add(developer);
            }
            return developers;
        }
    }
}
