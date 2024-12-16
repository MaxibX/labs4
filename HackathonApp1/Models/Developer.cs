using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonApp1.Models
{
    public class Developer
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Dictionary<string, int> Wishlist { get; private set; }

        public Developer(string id, string name)
        {
            Id = id;
            Name = name;
            Wishlist = new Dictionary<string, int>();
        }

        public void addToWishList(string partnerId, int satisfaction)
        {
            Wishlist[partnerId] = satisfaction;
        }

        public int getSatisfactionIndex(string partnerId)
        {
            return Wishlist.TryGetValue(partnerId, out int satisfaction) ? satisfaction : 0;
        }
    }
}
