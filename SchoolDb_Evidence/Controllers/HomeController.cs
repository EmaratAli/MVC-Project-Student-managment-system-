using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolDb_Evidence.Models;

namespace SchoolDb_Evidence.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult AddImage()
        {
            StudentImage img = new StudentImage();
            return View(img);
        }
        [HttpPost]
        public ActionResult AddImage(StudentImage model, HttpPostedFileBase image1)
        {
            var db = new StudentInformationDbEntities1();
            if (image1 != null)
            {
                model.Picture = new byte[image1.ContentLength];
                image1.InputStream.Read(model.Picture, 0, image1.ContentLength);
            }
            image1.SaveAs(Server.MapPath("~/Images/" + image1.FileName));
            db.StudentImages.Add(model);
                db.SaveChanges();
            return View(model);
        }
        public ActionResult Index1()
        {
            var db = new StudentInformationDbEntities1();
            var item = (from d in db.StudentImages
                        select d).ToList();
            return View(item);
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
    }
}