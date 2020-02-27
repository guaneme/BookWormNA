using BookWorm.Data.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            db = new BookData();
        }

        readonly IBookData db;

        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is Book Work application that was created by Natan Aronov.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "123 Brodway, New York, NY";

            return View();
        }
    }
}