using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Infra.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public Guid TeamOneId { get; set; }
        public Guid TeamTwoId { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public  int StatusId { get; set; }
        public int ResultTeamOne { get; set; }
        public int ResultTeamTwo { get; set;}


        public GameStatus GameStatus { get; set; }
        public Team TeamOne { get; set; }
        public Team TeamTwo { get; set; }

    }
}
