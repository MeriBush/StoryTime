using Microsoft.AspNet.Identity;
using StoryTime.Models;
using StoryTime.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoryTime.WebMVC.Controllers
{
    [Authorize]
    public class LocationPromptController : Controller
    {
        // GET: LocationPrompt
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationPromptService(userId);
            var model = service.GetLocationPrompts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationPromptCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateNoteService();

           if (service.CreateLocationPrompt(model))
            {
                TempData["Saveresult"] = "Your location was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your location could not be created.");
            return View(model);
        }

        private LocationPromptService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationPromptService(userId);
            return service;
        }
    }
}