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
    [Authorize(Roles = "Admin")]
    public class CharacterPromptController : Controller
    {
        // GET: CharacterPrompt
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterPromptService(userId);
            var model = service.GetCharacterPrompts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterPromptCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCharacterPromptService();

            if (service.CreateCharacterPrompt(model))
            {
                TempData["SaveResult"] = "Your character was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your character could not be created.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var svc = CreateCharacterPromptService();
            var model = svc.GetCharacterPromptById(id);   //This method doesn't exist yet. Oi Vey.

            return View(model);
        }

        private CharacterPromptService CreateCharacterPromptService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterPromptService(userId);
            return service;
        }
    }
}