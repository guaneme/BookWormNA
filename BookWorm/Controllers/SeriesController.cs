using BookWorm.Data.Models;
using BookWorm.Data.Services;
using BookWorm.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class SeriesController : Controller
    {
        readonly ISeriesData db;
        public SeriesController()
        {
            //I would use dependency injection here and get ISeriesData and assign it to this.db = ISeriesData
            db = RepositoryFactory.CreateSeriesDataRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return View("NotFound");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Series series)
        {
            if (ModelState.IsValid)
            {
                db.Add(series);
                return RedirectToAction("Details", new { id = series.SeriesId });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Series series)
        {
            if (ModelState.IsValid)
            {
                db.Update(series);
                return RedirectToAction("Details", new { id = series.SeriesId });
            }
            return View(series);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}