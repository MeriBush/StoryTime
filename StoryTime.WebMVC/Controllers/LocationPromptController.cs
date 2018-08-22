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

            var service = CreateLocationPromptService();

           if (service.CreateLocationPrompt(model))
            {
                TempData["Saveresult"] = "Your location was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your location could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLocationPromptService();
            var model = svc.GetLocationPromptById(id);

            return View(model);
        }

        private LocationPromptService CreateLocationPromptService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LocationPromptService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLocationPromptService();
            var detail = service.GetLocationPromptById(id);
            var model =
                new LocationPromptEdit
                {
                    LocationId = detail.LocationId,
                    Location = detail.Location
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LocationPromptEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LocationId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLocationPromptService();

            if (service.UpdateLocationPrompt(model))
            {
                TempData["SaveResult"] = "Your location was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your location could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateLocationPromptService();
            var model = svc.GetLocationPromptById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateLocationPromptService();
            service.DeleteLocationPrompt(id);
            TempData["SaveResult"] = "Your location was deleted.";
            return RedirectToAction("Index");
        }
    }
}