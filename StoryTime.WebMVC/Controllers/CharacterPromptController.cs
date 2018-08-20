﻿using StoryTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoryTime.WebMVC.Controllers
{
    [Authorize]
    public class CharacterPromptController : Controller
    {
        // GET: CharacterPrompt
        public ActionResult Index()
        {
            var model = new CharacterPromptListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}