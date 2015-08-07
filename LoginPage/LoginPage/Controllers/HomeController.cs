using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Table t)
        {
            if (ModelState.IsValid)
            {
                using (MyDataEntities dc = new MyDataEntities())
                {
                    var v = dc.Tables.Where(a => a.UserName.Equals(t.UserName) && a.Password.Equals(t.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserId"]=v.Id.ToString();
                        Session["LogedUserFullName"]=v.FullName.ToString();
                        return RedirectToAction("AfterLogin");

                    }
                }
            }
            return View(t);
 
        }
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

           
        }
    }
}
