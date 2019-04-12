using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiki.Models;
using Wiki.Services;

namespace Wiki.MVC.Controllers
{
    public class PostCommentController : Controller
    {
        // GET: PostComment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostCommentService(userId);
            var model = service.GetPosts();
            return View(model);
        }
        public ActionResult Create(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            ViewBag.PostDetails = service.GetPostById(id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCommentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostCommentService(userId);

            service.CreatePostComment(model);

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreatePostCommentService();
            var model = svc.GetPostCommentById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreatePostCommentService();
            var detail = service.GetPostCommentById(id);
            var model =
                new PostCommentEdit
                {
                    PostCommentId = detail.PostCommentId,
                    Text = detail.Text,
                    Catagory = detail.Catagory
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostCommentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PostCommentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePostCommentService();

            if (service.UpdateComment(model))
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
            var svc = CreatePostCommentService();
            var model = svc.GetPostCommentById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id)
        {
            var svc = CreatePostCommentService();
            var model = svc.DeletePostComment(id);

            return RedirectToAction("Index");
        }
        private PostCommentService CreatePostCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostCommentService(userId);
            return service;
        }
    }   
}