
﻿using Educon.Helpers;
using Educon.Models;
﻿using Educon.Core;
using Educon.Models;
using Educon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Educon.Controllers
{
    [Authorize]
    public class PortalController : Controller
    {
        private PortalCore Core = new PortalCore();        

        // GET: Portal
        public ActionResult Index()
        {
            User LLoggedInUser = AccountHelpers.GetSignedUser();
            return View(LLoggedInUser);
        }

        public ActionResult Quiz()
        {
            List<Question> LQuizQuestions = Core.GetQuestions(1, AgeGroup.PreTeenager, Category.Energy);

            Session["Questions"] = LQuizQuestions;
            
            return View(LQuizQuestions);
        }

        public ActionResult Ranking()
        {
            return View(Core.GetRankingList());
        }
    }
}