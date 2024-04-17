using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Infra.Models
{
    public class Championship
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<string> TeamsId { get; set; } = new List<string>();
        public int Rounds { get; set; }
        public List<string> GamesId { get; set; } = new List<string>();
    }
}
