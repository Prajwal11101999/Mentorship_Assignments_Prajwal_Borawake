using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackAssignmentMVC.Models
{
    public class MainFunctionFOrWinOrLoose
    {
        public string CheckGameStatus()
        {
            if (GameScore.Playerscore > 21 && GameScore.Dealerscore <= 21)
            {
                return "DealerWon,PlayerLoses";
            }
            else if (GameScore.Dealerscore < 21 && GameScore.Playerscore == 21)
            {
                return "PlayerWon,DealerLoses";
            }
            else if (GameScore.Dealerscore > 21 && GameScore.Playerscore < 21)
            {
                return "PlayerWon,DealerLoses";
            }
            else if (GameScore.Playerscore == GameScore.Dealerscore)
            {
                return "GameTie";
            }
            else if (GameScore.Playerscore <= 21)
            {
                if (GameScore.Playerscore < GameScore.Dealerscore)
                {
                    return "PlayerWon, DealerLoses";
                }
                else
                {
                    return "DealerWon,PlayerLoses";
                }
            }
            return "Oops!!Something Went Wrong";
        }

    }
}