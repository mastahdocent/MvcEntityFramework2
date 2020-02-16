using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rozdzial2_C.Models;

namespace Rozdzial2_C.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostService _service;

        public HomeController(PostService ctx)
        {
            _service = ctx;
        }

        public IActionResult Index()
        {
            var posts = _service.GetPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("PostForm");
        }

        [HttpPost]
        public IActionResult Add(PostModel post)
        {
            if (ModelState.IsValid)
            {
                _service.AddPost(post);
                return RedirectToAction("Index");
            }
            else
            {
                return View("PostForm", post);
            }
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var post = _service.GetPost(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            _service.RemovePost(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _service.GetPost(id);
            return View("PostForm", post);
        }

        [HttpPost]
        public IActionResult Edit(PostModel post)
        {
            if (ModelState.IsValid)
            {
                _service.UpdatePost(post);
                return RedirectToAction("Index");
            }

            return View("PostForm", post);

            // rownoznaczne z:
            //
            //if (ModelState.IsValid)
            //{
            //    _service.UpdatePost(post);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View("PostForm", post);
            //}
        }
    }
}