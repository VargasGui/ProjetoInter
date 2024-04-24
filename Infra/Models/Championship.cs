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
        public int Rounds { get; set; }

        public Game Games { get; set; }
        public Team Teams { get; set; }
        public List<Game> GamesList { get; set; } = new List<Game>();
        public List<Team> Teamslist { get; set; } = new List<Team>();
    }
}



//comments added