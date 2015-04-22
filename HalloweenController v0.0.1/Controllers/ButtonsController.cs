using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HalloweenController_v0._0._1.Models;
using HalloweenController_v0._0._1.DAL;
using System.ComponentModel;

namespace HalloweenController_v0._0._1.Controllers
{
    public class ButtonsController : Controller
    {
        private PanelContext db = new PanelContext();


        public bool RunMessage = false;

        // GET: Buttons
        public ActionResult Index()
        {


            //SelectList ResponseTypes = new SelectList(RList);
            //ViewData["ResponseTypes"] = ResponseTypes;

            return View(db.Buttons.ToList());
        }

      public ActionResult TestClick(string URI)

        {
            bool PostSuccess = false;
            var curUser = User.Identity.Name.ToString();
            MyMethods.WriteToLog(curUser + " has pressed the button... " + URI);
            try
            {
                PostSuccess = REST.POST(URI, "", "text/plain");
            }
            catch (Exception e)
            {
                MyMethods.WriteToLog(e.ToString());
                //throw;
            }
            
            //return View();
            if (PostSuccess)
            {
                MyMethods.ShowDisplay = true;
            
              return Redirect(Request.UrlReferrer.ToString());
                //return Content("<script language='javascript' type='text/javascript'>alert('Hello world!');</script>"); 
            }
            else
            {
                MyMethods.ShowDisplay = false;
              return RedirectToAction("ErrorPanel");  
            }

            
            //return JavaScript("<script>hideDiv(\"ButtonSuccess\")</script>");
        }

        public ActionResult Panel()
        {
            ViewData["DisplayMessage"] = MyMethods.ShowDisplay;
            var curUser = User.Identity.Name.ToString();
            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\ControllerLog.txt");
            //file.WriteLine(curUser + " has accessed their panel... " + DateTime.Now.ToString());
            //file.Close();
            //MyMethods.WriteToLog(curUser + " has accessed their panel... ");

            var ButtonList = db.Buttons.ToList();
            bool UserCanUseButton = false;
            //run through each button, remove buttons whos list of users does not match current user
            try
            {
                var ButtonCount = ButtonList.Count();
                for (int  i= 0; i <= (ButtonCount - 1); i++)
                {
                    var But = ButtonList[i];

                    //Grab a list of users allowed to use this button
                    var userList = But.Users;

                    UserCanUseButton = false;
                    if (userList == null)
                    {
                       
                    }
                    else
                    {
                        string[] aUsers = userList.Split(',');

                   

                        foreach (var ForUser in aUsers)
                        {
                            if (ForUser == curUser )
                            {
                                UserCanUseButton = true;
                            }
                        }
                    }

                    if (curUser == "admin@gmail.com" | curUser == "administrator@gmail.com")
                    {
                        UserCanUseButton = true;
                    }

                    if (UserCanUseButton == false)
                    {
                        ButtonList.Remove(But);
                        i = i - 1;
                        ButtonCount = ButtonCount - 1;
                    }


                }
            }
            catch (Exception e)
            {
                MyMethods.WriteToLog(e.ToString());
                //throw;
            }
           

            //User.Identity.Name == "testKid@aol.com"
 
       
                return View(ButtonList);
          
            
        }

        public ActionResult ErrorPanel()
        {
            var curUser = User.Identity.Name.ToString();
            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\ControllerLog.txt");
            //file.WriteLine(curUser + " has accessed their panel... " + DateTime.Now.ToString());
            //file.Close();
            //MyMethods.WriteToLog(curUser + " has accessed their panel... ");

            var ButtonList = db.Buttons.ToList();
            bool UserCanUseButton = false;
            //run through each button, remove buttons whos list of users does not match current user
            try
            {
                var ButtonCount = ButtonList.Count();
                for (int i = 0; i <= ButtonCount; i++)
                {
                    var But = ButtonList[0];

                    //Grab a list of users allowed to use this button
                    var userList = But.Users;

                    UserCanUseButton = false;
                    if (userList == null)
                    {

                    }
                    else
                    {
                        string[] aUsers = userList.Split(',');



                        foreach (var ForUser in aUsers)
                        {
                            if (ForUser == curUser)
                            {
                                UserCanUseButton = true;
                            }
                        }
                    }

                    if (curUser == "pjthomas45@gmail.com" | curUser == "adamdthomas@gmail.com")
                    {
                        UserCanUseButton = true;
                    }

                    if (UserCanUseButton == false)
                    {
                        ButtonList.Remove(But);
                    }


                }
            }
            catch (Exception e)
            {
                MyMethods.WriteToLog(e.ToString());
                //throw;
            }


            //User.Identity.Name == "testKid@aol.com"
            return View(ButtonList);
        }

        // GET: Buttons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Button button = db.Buttons.Find(id);
            if (button == null)
            {
                return HttpNotFound();
            }
            return View(button);
        }

        // GET: Buttons/Create
        public ActionResult Create()
        {

            ViewBag.responselist = MyMethods.ResponseTypes();
            return View();
        }

        // POST: Buttons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ButtonID,Label,Style,URI,Response,TimeOut,Users")] Button button)
        {

            //ViewBag.responselist = MyMethods.ResponseTypes(value["responseID"]);
    



            if (ModelState.IsValid)
            {

                db.Buttons.Add(button);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(button);
        }

        // GET: Buttons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Button button = db.Buttons.Find(id);
            if (button == null)
            {
                return HttpNotFound();
            }
            return View(button);
        }

        // POST: Buttons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ButtonID,Label,Style,URI,Response,TimeOut,Users")] Button button)
        {
            if (ModelState.IsValid)
            {
                db.Entry(button).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(button);
        }

        // GET: Buttons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Button button = db.Buttons.Find(id);
            if (button == null)
            {
                return HttpNotFound();
            }
            return View(button);
        }

        // POST: Buttons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Button button = db.Buttons.Find(id);
            db.Buttons.Remove(button);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
