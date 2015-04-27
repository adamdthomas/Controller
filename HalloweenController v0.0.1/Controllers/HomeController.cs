﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HalloweenController_v0._0._1.DAL;


namespace HalloweenController_v0._0._1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["DisplayMessage"] = false;
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult AStars()
        {
            StarStats();
            return View();
        }

        public ActionResult GStars()
        {
            StarStats();
            return View();
        }

        public void StarStats()
        {
            Excel StarsSheet = new Excel("C:\\Logs\\stars.xls", "Gabriel");
            ViewBag.GTCount = StarsSheet.GetCellNumber(1, 2).ToString();
            int TR = StarsSheet.GetTodaysRow();
            ViewBag.GDCount = StarsSheet.GetCellNumber(TR, 4);
            ViewBag.GFightCount = StarsSheet.GetCellNumber(1, 8);
            ViewBag.GDollars = "$" + StarsSheet.GetCellNumber(9, 8);
            ViewBag.GFightLost = "$" + StarsSheet.GetCellNumber(10, 8);
            string FightToday = StarsSheet.GetCellString(TR, 2);
            if (FightToday != "Yes")
            {
                FightToday = "No";
            }
            ViewBag.GFightToday = FightToday;
            StarsSheet.SwitchSheet("Adrian");
            ViewBag.ATCount = StarsSheet.GetCellNumber(1, 2).ToString();
            TR = StarsSheet.GetTodaysRow();
            ViewBag.ADCount = StarsSheet.GetCellNumber(TR, 4);
            ViewBag.AFightCount = StarsSheet.GetCellNumber(1, 8);
            ViewBag.ADollars = "$" + StarsSheet.GetCellNumber(9, 8);
            ViewBag.AFightLost = "$" + StarsSheet.GetCellNumber(10, 8);
            FightToday = StarsSheet.GetCellString(TR, 2);
            if (FightToday != "Yes")
            {
                FightToday = "No";
            }
            ViewBag.AFightToday = FightToday;
            StarsSheet.SaveAndExit();
        }

        public ActionResult StarManager()
        {
            StarStats();
            return View();
        }


        public void Fight(string Account)
        {
            Excel StarsSheet = new Excel("C:\\Logs\\stars.xls", Account);
            int row = StarsSheet.GetTodaysRow();
            StarsSheet.SetCellString(row, 2, "Yes");

            //Get Stats
            StarsSheet.SwitchSheet("Gabriel");
            ViewBag.GTCount = StarsSheet.GetCellNumber(1, 2).ToString();
            int TR = StarsSheet.GetTodaysRow();
            ViewBag.GDCount = StarsSheet.GetCellNumber(TR, 4);
            ViewBag.GFightCount = StarsSheet.GetCellNumber(1,8);
            ViewBag.GDollars = "$" + StarsSheet.GetCellNumber(9, 8);
            ViewBag.GFightLost = "$" + StarsSheet.GetCellNumber(10, 8);
            string FightToday = StarsSheet.GetCellString(TR, 2);
            if (FightToday != "Yes")
            {
                FightToday = "No";
            }
            ViewBag.GFightToday = FightToday;
            StarsSheet.SwitchSheet("Adrian");
            ViewBag.ATCount = StarsSheet.GetCellNumber(1, 2).ToString();
            TR = StarsSheet.GetTodaysRow();
            ViewBag.ADCount = StarsSheet.GetCellNumber(TR, 4);
            ViewBag.AFightCount = StarsSheet.GetCellNumber(1, 8);
            ViewBag.ADollars = "$" + StarsSheet.GetCellNumber(9, 8);
            ViewBag.AFightLost = "$" + StarsSheet.GetCellNumber(10, 8);
            FightToday = StarsSheet.GetCellString(TR, 2);
            if (FightToday != "Yes")
            {
                FightToday = "No";
            }
            ViewBag.AFightToday = FightToday;
            StarsSheet.SaveAndExit();
        }


        public void Payout(string Account)
        {
            Excel StarsSheet = new Excel("C:\\Logs\\stars.xls", Account);
            int row = StarsSheet.GetFirstEmptyRow("A");
        
            double CurTotal = StarsSheet.GetCellNumber(1, 2);
            StarsSheet.SetCellNumber(row, 3, CurTotal);
            StarsSheet.SetCellString(row, 1, "Payday!");
            StarsSheet.SwitchSheet("Gabriel");
            ViewBag.GTCount = StarsSheet.GetCellNumber(1, 2).ToString();
            int TR = StarsSheet.GetTodaysRow();
            ViewBag.GDCount = StarsSheet.GetCellNumber(TR, 4);
            ViewBag.GFightCount = StarsSheet.GetCellNumber(1, 8);
            ViewBag.GDollars = "$" + StarsSheet.GetCellNumber(9, 8);
            ViewBag.GFightLost = "$" + StarsSheet.GetCellNumber(10, 8);
            string FightToday = StarsSheet.GetCellString(TR, 2);
            if (FightToday != "Yes")
            {
                FightToday = "No";
            }
            ViewBag.GFightToday = FightToday;
            StarsSheet.SwitchSheet("Adrian");
            ViewBag.ATCount = StarsSheet.GetCellNumber(1, 2).ToString();
            TR = StarsSheet.GetTodaysRow();
            ViewBag.ADCount = StarsSheet.GetCellNumber(TR, 4);
            ViewBag.AFightCount = StarsSheet.GetCellNumber(1, 8);
            ViewBag.ADollars = "$" + StarsSheet.GetCellNumber(9, 8);
            ViewBag.AFightLost = "$" + StarsSheet.GetCellNumber(10, 8);
            FightToday = StarsSheet.GetCellString(TR, 2);
            if (FightToday != "Yes")
            {
                FightToday = "No";
            }
            ViewBag.AFightToday = FightToday;
            StarsSheet.SaveAndExit();
        }



        public void AddStars(string Account, double Amount)
        {
            Excel StarsSheet = new Excel("C:\\Logs\\stars.xls", Account);
            int row = StarsSheet.GetTodaysRow();
            StarsSheet.AddToCell(row, 5, Amount);
            StarsSheet.SwitchSheet("Gabriel");
            ViewBag.GTCount = StarsSheet.GetCellNumber(1, 2).ToString();
            int TR = StarsSheet.GetTodaysRow();
            ViewBag.GDCount = StarsSheet.GetCellNumber(TR, 4);
            ViewBag.GFightCount = StarsSheet.GetCellNumber(1, 8);
            ViewBag.GDollars = "$" + StarsSheet.GetCellNumber(9, 8);
            ViewBag.GFightLost = "$" + StarsSheet.GetCellNumber(10, 8);
            string FightToday = StarsSheet.GetCellString(TR, 2);
            if (FightToday != "Yes")
            {
                FightToday = "No";
            }
            ViewBag.GFightToday = FightToday;
            StarsSheet.SwitchSheet("Adrian");
            ViewBag.ATCount = StarsSheet.GetCellNumber(1, 2).ToString();
            TR = StarsSheet.GetTodaysRow();
            ViewBag.ADCount = StarsSheet.GetCellNumber(TR, 4);
            ViewBag.AFightCount = StarsSheet.GetCellNumber(1, 8);
            ViewBag.ADollars = "$" + StarsSheet.GetCellNumber(9, 8);
            ViewBag.AFightLost = "$" + StarsSheet.GetCellNumber(10, 8);
            FightToday = StarsSheet.GetCellString(TR, 2);
            if (FightToday != "Yes")
            {
                FightToday = "No";
            }
            ViewBag.AFightToday = FightToday;
            StarsSheet.SaveAndExit();
        }


        public ActionResult MyStars()
        {
            StarStats();
            return View();
        }

        #region GabrielsStars

        public ActionResult GFight()
        {
            Fight("Gabriel");
            return View("StarManager");
        }
        public ActionResult GPayout()
        {
            Payout("Gabriel");
            return View("StarManager");
        }

        public ActionResult GAddQtr()
        {
            AddStars("Gabriel", .25);
            return View("StarManager");
        }

        public ActionResult GAddHalf()
        {
            AddStars("Gabriel", .5);
            return View("StarManager");
        }

        public ActionResult GAddOne()
        {
            AddStars("Gabriel", 1);
            return View("StarManager");
        }

        public ActionResult GAddTwo()
        {
            AddStars("Gabriel", 2);
            return View("StarManager");
        }

        public ActionResult GAddThree()
        {
            AddStars("Gabriel", 3);
            return View("StarManager");
        }

        public ActionResult GAddFour()
        {
            AddStars("Gabriel", 4);
            return View("StarManager");
        }

        public ActionResult GAddFive()
        {
            AddStars("Gabriel", 5);
            return View("StarManager");
        }

        public ActionResult GSubQtr()
        {
            AddStars("Gabriel", -.25);
            return View("StarManager");
        }

        public ActionResult GSubOne()
        {
            AddStars("Gabriel", -1);
            return View("StarManager");
        }

        #endregion


        #region AdriansStars

        public ActionResult AFight()
        {
            Fight("Adrian");
            return View("StarManager");
        }
        public ActionResult APayout()
        {
            Payout("Adrian");
            return View("StarManager");
        }

        public ActionResult AAddQtr()
        {
            AddStars("Adrian", .25);
            return View("StarManager");
        }

        public ActionResult AAddHalf()
        {
            AddStars("Adrian", .5);
            return View("StarManager");
        }

        public ActionResult AAddOne()
        {
            AddStars("Adrian", 1);
            return View("StarManager");
        }


        public ActionResult AAddTwo()
        {
            AddStars("Adrian", 2);
            return View("StarManager");
        }

        public ActionResult AAddThree()
        {
            AddStars("Adrian", 3);
            return View("StarManager");
        }

        public ActionResult AAddFour()
        {
            AddStars("Adrian", 4);
            return View("StarManager");
        }

        public ActionResult AAddFive()
        {
            AddStars("Adrian", 5);
            return View("StarManager");
        }

        public ActionResult ASubQtr()
        {
            AddStars("Adrian", -.25);
            return View("StarManager");
        }

        public ActionResult ASubOne()
        {
            AddStars("Adrian", -1);
            return View("StarManager");
        }

        #endregion

    }
}