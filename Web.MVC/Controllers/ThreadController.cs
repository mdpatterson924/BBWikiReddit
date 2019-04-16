﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiki.Models.Thread;
using Wiki.Services;

namespace Wiki.MVC.Controllers
{
    public class ThreadController : Controller
    {
        // GET: Thread
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ThreadService(userId);
            var model = service.GetThreads();
            return View(model);
        }
        public ActionResult Create(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostCommentService(userId);
            ViewBag.PostCommentDetails = service.GetPostCommentById(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThreadCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ThreadService(userId);

            service.CreateThread(model);

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateThreadService();
            var model = svc.GetThreadById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateThreadService();
            var detail = service.GetThreadById(id);
            var model =
                new ThreadEdit
                {
                    ThreadId = detail.ThreadId,
                    Text = detail.Text,
                    
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ThreadEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ThreadId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateThreadService();

            if (service.UpdateThread(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateThreadService();
            var model = svc.GetThreadById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteThread(int id)
        {
            var svc = CreateThreadService();
            var model = svc.DeleteThread(id);

            return RedirectToAction("Index");
        }
        public ThreadService CreateThreadService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ThreadService(userId);
            return service;
        }
    }
}