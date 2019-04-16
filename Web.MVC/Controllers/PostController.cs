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
    [Authorize]
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            var pcservice = new PostCommentService(userId);
            var model = service.GetPosts();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid) return View(model);
             var service = CreatePostService();
             if (service.CreatePost(model))
             {
                TempData["SaveResult"] = "Your Post was created";
               return RedirectToAction("Index");
             };
            ModelState.AddModelError("", "Post could not be created");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);
            //ViewBag.PostComment = CreatePostCommentService().GetPosts(id);

            var postComments = CreatePostCommentService().GetPosts(id);
            var modelTwo = Tuple.Create(model, postComments);
            return View(modelTwo);
        }
        public ActionResult Edit(int id)
        {
            var service = CreatePostService();
            var detail = service.GetPostById(id);
            var model =
                new PostEdit
                {
                    PostId = detail.PostId,
                    Catagory = detail.Catagory,
                    Text = detail.Text
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PostId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePostService();
            if (service.UpdateNote(model))
            {
                TempData["SaveResult"] = "Your post was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your post could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var svc = CreatePostService();
            svc.DeletePost(id);
            TempData["SaveResult"] = "Your Post was deleted.";
            return RedirectToAction("Index");
        }
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }
        private PostCommentService CreatePostCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostCommentService(userId);
            return service;
        }
    }
}