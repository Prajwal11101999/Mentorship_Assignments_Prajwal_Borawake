using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackAssignmentMVC.Models
{
    public class CardsDealt
    {
        public string PlayerCard1 { get; set; }
        public string PlayerCard2 { get; set; }
        public string DealerCard { get; set; }

        ShuffleCards SC = new ShuffleCards();


        public string PlayerFirstCard()
        {
            SC.RandomCards();
            PlayerCard1 = SC.CName;
            GameScore.Playerscore = GameScore.Playerscore + SC.CVal;
            return PlayerCard1;
        }


        public string PlayerSecondCard()
        {
            SC.RandomCards();
            PlayerCard2 = SC.CName;
            GameScore.Playerscore = GameScore.Playerscore + SC.CVal;
            return PlayerCard2;
        }


        public string DealerCards()
        {
            SC.RandomCards();
            DealerCard = SC.CName;
            GameScore.Dealerscore = GameScore.Dealerscore + SC.CVal;
            return DealerCard;
        }
    }
}