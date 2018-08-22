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
    public class TwistPromptController : Controller
    {
        // GET: TwistPrompt
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TwistPromptService(userId);
            var model = service.GetTwistPrompts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TwistPromptCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateTwistPromptService();

            if (service.CreateTwistPrompt(model))
            {
                TempData["Saveresult"] = "Your plot twist was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your plot twist could not be created.");
            return View(model);
        }

        private TwistPromptService CreateTwistPromptService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TwistPromptService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTwistPromptService();
            var model = svc.GetTwistPromptById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTwistPromptService();
            var detail = service.GetTwistPromptById(id);
            var model =
                new TwistPromptEdit
                {
                    TwistId = detail.TwistId,
                    Twist = detail.Twist
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TwistPromptEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TwistId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTwistPromptService();

            if (service.UpdateTwistPrompt(model))
            {
                TempData["SaveResult"] = "Your plot twist was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plot twist could not be updated.");
            return View(model);
        }
    }
}