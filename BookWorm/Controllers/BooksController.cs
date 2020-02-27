using BookWorm.Data.Models;
using BookWorm.Data.Services;
using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class BooksController : Controller
    {
        readonly IBookData db;
        public BooksController()
        {
            //I would use dependency injection here and get IBookData and assign it to this.db = IBookData
            db = new BookData();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Index1()
        {
            BookViewModel model = new BookViewModel();
            Book[] books = db.GetAll().ToArray();
            //model.Book = books;
            //var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewImage(int id)
        {
            var model = db.Get(id);
            if (model != null)
            {
                if (model.CoverArt != null)
                {
                    byte[] buffer = model.CoverArt;
                    return File(buffer, "image/jpg", string.Format("{0}.jpg", id));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
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
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "coverArt")] Book book, HttpPostedFileBase coverArt)
        {
            if (ModelState.IsValid)
            {
                if (coverArt != null)
                {
                    book.CoverArt = new byte[coverArt.ContentLength];
                    coverArt.InputStream.Read(book.CoverArt, 0, coverArt.ContentLength);
                }
                db.Add(book);
                return RedirectToAction("Details", new { id = book.BookId });
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
        public ActionResult Edit(Book book, HttpPostedFileBase coverArt)
        {
            if (ModelState.IsValid)
            {
                if (coverArt != null)
                {
                    book.CoverArt = new byte[coverArt.ContentLength];
                    coverArt.InputStream.Read(book.CoverArt, 0, coverArt.ContentLength);
                }
                db.Update(book);
                return RedirectToAction("Details", new { id = book.BookId });
            }
            return View(book);
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