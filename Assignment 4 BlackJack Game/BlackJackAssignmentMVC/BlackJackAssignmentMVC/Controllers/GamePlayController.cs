using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackJackAssignmentMVC.Models;

namespace BlackJackAssignmentMVC.Controllers
{
    public class GamePlayController : Controller
    {
        BlackJackDatabaseEntities bjde = new BlackJackDatabaseEntities();
        
        // GET: GamePlay
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GameStart()
        {
            CardsDealt cd = new CardsDealt();
            TempData["PlayerCard1"] = cd.PlayerFirstCard();
            TempData["PlayerCard2"] = cd.PlayerSecondCard();
            TempData["DealerCard"] = cd.DealerCards();
            return View();
        }

        public ActionResult Hit()
        {
            HitFunction hf = new HitFunction();
            if (GameScore.PlayerHitCount < 1)
            {
                TempData["PlayerHitCard1"] = hf.PlayerHit();
                GameScore.PlayerHitCount = GameScore.PlayerHitCount + 1;
            }

            else if (GameScore.PlayerHitCount < 2)
            {
                TempData["PlayerHitCard2"] = hf.PlayerHit();
                GameScore.PlayerHitCount = GameScore.PlayerHitCount + 1;
            }

            else if (GameScore.PlayerHitCount < 3)
            {
                TempData["PlayerHitCard3"] = hf.PlayerHit();
            }
            return View("GameStart");
        }

        public ActionResult Stand()
        {
            MainFunctionFOrWinOrLoose mfwl = new MainFunctionFOrWinOrLoose();
            HitFunction hf = new HitFunction();
            while (GameScore.Dealerscore <= 17)
            {
                if (GameScore.DealerHitCount < 1)
                {
                    TempData["DealerHitCard1"] = hf.DealerHit();
                    GameScore.DealerHitCount = GameScore.DealerHitCount + 1;
                }

                else if (GameScore.DealerHitCount < 2)
                {
                    TempData["DealerHitCard2"] = hf.DealerHit();
                    GameScore.DealerHitCount = GameScore.DealerHitCount + 1;
                }
                else if (GameScore.DealerHitCount < 3)
                {
                    TempData["DealerHitCard3"] = hf.DealerHit();
                    GameScore.DealerHitCount = GameScore.DealerHitCount + 1;
                }
                else if (GameScore.DealerHitCount < 4)
                {
                    TempData["DealerHitCard4"] = hf.DealerHit();
                }
            }
            if (GameScore.Dealerscore >= 17 || GameScore.Playerscore >= 21)
            {
                ViewData["GameStatus"] = mfwl.CheckGameStatus();
            }
            return View("GameStart");
        }

        public ActionResult PlayAgain()
        {
            RestartGame rg = new RestartGame();
            rg.Restart();
            TempData.Remove("PlayerhitCard1");
            TempData.Remove("PlayerhitCard2");
            TempData.Remove("PlayerhitCard3");
            TempData.Remove("DealerhitCard1");
            TempData.Remove("DealerhitCard2");
            TempData.Remove("DealerhitCard3");
            TempData.Remove("DealerhitCard4");
            return RedirectToAction("GameStart");
        }

        public ActionResult SessionReport()
        {
            List<SessionTable> session = bjde.SessionTables.ToList();
            return View(session);
        }

        public ActionResult GameSave()
        {
            MainFunctionFOrWinOrLoose mfwl = new MainFunctionFOrWinOrLoose();
            SessionTable ss = new SessionTable();
            ss.PlayerScore = GameScore.Playerscore;
            ss.DealerScore = GameScore.Dealerscore;
            ss.GameResult = mfwl.CheckGameStatus();
            bjde.SessionTables.Add(ss);
            bjde.SaveChanges();
            return View("GameStart");
        }
    }
}
