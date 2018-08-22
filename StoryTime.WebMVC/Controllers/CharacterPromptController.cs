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

        public ActionResult Details (int id)
        {
            var svc = CreateCharacterPromptService();
            var model = svc.GetCharacterPromptById(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = CreateCharacterPromptService();
            var detail = service.GetCharacterPromptById(id);
            var model =
                new CharacterPromptEdit
                {
                    CharacterId = detail.CharacterId,
                    Character = detail.Character
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, CharacterPromptEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CharacterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCharacterPromptService();

            if(service.UpdateCharacterPrompt(model))
            {
                TempData["SaveResult"] = "Your character was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your character could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete (int id)
        {
            var svc = CreateCharacterPromptService();
            var model = svc.GetCharacterPromptById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCharacterPromptService();
            service.DeleteCharacterPrompt(id);
            TempData["SaveResult"] = "Your character was deleted.";
            return RedirectToAction("Index");
        }

        private CharacterPromptService CreateCharacterPromptService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterPromptService(userId);
            return service;
        }
    }
}