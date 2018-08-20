﻿using StoryTime.Models;
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
            var model = new LocationPromptListItem[0];
            return View(model);
        }
    }
}