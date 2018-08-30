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
        [Authorize(Roles ="Admin")]
        public ActionResult AdminIndex()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StorySubmissionService(userId);
            var model = service.GetStudentNameFromId(service.AdminGetAllStorySubmissions());
            return View(model);
        }

        // GET: GeneratedPrompt
        public ActionResult Index()
        {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var service = new StorySubmissionService(userId);
                var model = service.GetStudentNameFromId(service.GetStorySubmissions());
                return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateStorySubmissionService();
            var model = service.PromptResult();
            return View(model);
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

        public ActionResult Edit(int id)
        {
            if (User.IsInRole("Admin"))
            {
                var service = CreateStorySubmissionService();
                var detail = service.AdminGetStoryById(id);
                var model =
                    new StorySubmissionEdit
                    {
                        StoryId = detail.StoryId,
                        StoryTitle = detail.StoryTitle,
                        StoryText = detail.StoryText
                    };
                return View(model);
            }

            if (User.Identity.IsAuthenticated && !User.IsInRole("Admin"))
            {
                var service = CreateStorySubmissionService();
                var detail = service.GetStoryById(id);
                var model =
                    new StorySubmissionEdit
                    {
                        StoryId = detail.StoryId,
                        StoryTitle = detail.StoryTitle,
                        StoryText = detail.StoryText
                    };
                return View(model);
            }
            return View();    //Why is it trying to force little Timmy to login???
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StorySubmissionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateStorySubmissionService();

            //Added
            if (User.IsInRole("Admin"))  //This fixed Timmy going to login view instead of index
            {
                if (service.AdminUpdateStorySubmission(model))
                {
                    TempData["SaveResult"] = "Your comments have been recorded.";
                    return RedirectToAction("AdminIndex");
                }
            }
            //Added
            if (User.Identity.IsAuthenticated && !User.IsInRole("Admin"))   //This fixed Timmy going to login view instead of index
            {
                if (service.UpdateStorySubmission(model))
                {
                    TempData["SaveResult"] = "Your story was updated for the teacher's review.";
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Your story could not be updated.");
            return View(model);
        }

        private StorySubmissionService CreateStorySubmissionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StorySubmissionService(userId);
            return service;
        }
    }
}