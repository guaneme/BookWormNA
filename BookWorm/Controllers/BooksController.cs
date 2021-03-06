﻿using BookWorm.Data.Models;
using BookWorm.Data.Services;
using BookWorm.IoC;
using BookWorm.Models;
using BookWorm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class BooksController : Controller
    {
        readonly IBookService service;
        public BooksController()
        {
            service = new BookService(
                RepositoryFactory.CreateBookDataRepository(),
                RepositoryFactory.CreateSeriesDataRepository(),
                RepositoryFactory.CreateAuthorDataRepository(),
                RepositoryFactory.CreateBookAuthorDataRepository()
                );
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = service.GetList();

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewImage(int id)
        {
            BookData db = new BookData(); //todo: replace
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
            var model = this.service.GetDetails(id);

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
        public ActionResult Create([Bind(Exclude = "coverArt")] BookEditViewModel book, HttpPostedFileBase coverArt)
        {
            if (ModelState.IsValid)
            {
                if (coverArt != null)
                {
                    //book.CoverArt = new byte[coverArt.ContentLength];
                    //coverArt.InputStream.Read(book.CoverArt, 0, coverArt.ContentLength);
                }
                this.service.SaveOrUpdate(book);
                return RedirectToAction("Details", new { id = book.ID });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = this.service.GetForEdit(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookEditViewModel book, HttpPostedFileBase coverArt)
        {
            if (ModelState.IsValid)
            {
                if (coverArt != null)
                {
                    //book.CoverArt = new byte[coverArt.ContentLength];
                    //coverArt.InputStream.Read(book.CoverArt, 0, coverArt.ContentLength);
                }
                this.service.SaveOrUpdate(book);
                return RedirectToAction("Details", new { id = book.ID });
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = this.service.GetDetails(id);
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
            this.service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}