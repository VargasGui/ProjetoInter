using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISoccer.Infra.Models
{
    public class Game
    {
        public Game(Guid id, Guid teamOneId, Guid teamTwoId, DateTime date, string place, int statusId, int resultTeamOne, int resultTeamTwo, GameStatus gameStatus, Team teamOne, Team teamTwo)
        {
            Id = id;
            TeamOneId = teamOneId;
            TeamTwoId = teamTwoId;
            Date = date;
            Place = place;
            StatusId = statusId;
            ResultTeamOne = resultTeamOne;
            ResultTeamTwo = resultTeamTwo;
            GameStatus = gameStatus;
            TeamOne = teamOne;
            TeamTwo = teamTwo;
        }

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
