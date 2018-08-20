using StoryTime.Models;
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
            var model = new TwistPromptListItem[0];
            return View(model);
        }
    }
}