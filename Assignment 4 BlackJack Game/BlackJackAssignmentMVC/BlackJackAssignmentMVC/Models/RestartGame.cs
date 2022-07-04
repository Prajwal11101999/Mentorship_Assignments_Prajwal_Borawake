using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackAssignmentMVC.Models
{
    public class RestartGame
    {
        public void Restart()
        {
            GameScore.Playerscore = 0;
            GameScore.Dealerscore = 0;
            GameScore.PlayerHitCount = 0;
            GameScore.DealerHitCount = 0;
        }
    }
}