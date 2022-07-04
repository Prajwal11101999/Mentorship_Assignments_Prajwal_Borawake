using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackAssignmentMVC.Models
{
    public class ShuffleCards
    {
        public string CName { get; set; }
        public int CVal { get; set; }

        public void RandomCards()
        {
            //Getting the data from database table Cards and taken the card randomly and stores the cardvalue and cardname into given variables
            BlackJackDatabaseEntities BJ = new BlackJackDatabaseEntities();
            List<CardPack> card = BJ.CardPacks.ToList();

            Random random = new Random(Guid.NewGuid().GetHashCode());
            int r = random.Next(card.Count);
            var res = card[r].Card_Name.ToString();
            CVal = card[r].Card_Value;
            CName = res;
        }
    }
}