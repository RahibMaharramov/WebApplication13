using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult Teachers()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Apply()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(STUDENT stud)
        {
            using (var db = new DBGR95Entities1())
            {
                var newstudent = db.STUDENTs.Create();

                newstudent.NAME = stud.NAME;
                newstudent.SURNAME = stud.SURNAME;
                newstudent.MOBILE = stud.MOBILE;
                newstudent.EMAIL = stud.EMAIL;

                db.STUDENTs.Add(newstudent);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
        }
        public  ActionResult Approve (int id)
        {
            var db = new DBGR95Entities1();
            var student = db.STUDENTs.FirstOrDefault(a => a.ID == id);
            if(student != null)
            {
                student.APPROVED = true;
            }
            db.SaveChanges();
            return RedirectToAction("Appeals");
        }
        public ActionResult Appeals()
        {
            DBGR95Entities1 db = new DBGR95Entities1();
            var USER = db.STUDENTs.Where(a => a.APPROVED == false|| a.APPROVED == null).ToList();

            if (USER.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            
            return View(USER);
        }
    }
}