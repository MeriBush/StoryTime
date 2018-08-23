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
    //Authorize student role permission
    public class StorySubmissionController : Controller
    {
        // GET: GeneratedPrompt
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StorySubmissionCreate model)
        {
            {
                if (!ModelState.IsValid) return View(model);

                var service = CreateStorySubmissionService();

                if (service.CreateStorySubmission(model))
                {
                    TempData["SaveResult"] = "Your story has been submitted.";
                    return RedirectToAction("Index");
                };

                ModelState.AddModelError("", "Your story could not be submitted.");
                return View(model);
            }
        }

        private StorySubmissionService CreateStorySubmissionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StorySubmissionService(userId);
            return service;
        }
    }
}