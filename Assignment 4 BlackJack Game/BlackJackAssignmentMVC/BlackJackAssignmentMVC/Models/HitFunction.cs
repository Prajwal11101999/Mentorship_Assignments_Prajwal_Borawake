using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackAssignmentMVC.Models
{
    public class HitFunction
    {
        public string hitcard { get; set; }


        ShuffleCards SC = new ShuffleCards();


        public string PlayerHit()
        {
            if (GameScore.Playerscore <= 21)
            {
                SC.RandomCards();
                hitcard = SC.CName;
                GameScore.Playerscore = GameScore.Playerscore + SC.CVal;
            }
            else
            {
                return "No Card Will be Generated because PlayerScore must be Lessthan 21";
            }
            return hitcard;
        }


        public string DealerHit()
        {
            if (GameScore.Dealerscore <= 17)
            {
                SC.RandomCards();
                hitcard = SC.CName;
                GameScore.Dealerscore = GameScore.Dealerscore + SC.CVal;
            }
            return hitcard;
        }
    }
}