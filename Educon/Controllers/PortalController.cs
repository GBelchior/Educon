﻿using Educon.Helpers;
using Educon.Models;
using Educon.Core;
using Educon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Educon.Controllers
{
    [Authorize]
    public class PortalController : Controller
    {
        private PortalCore Core = new PortalCore();        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFriendsOfUser()
        {
            ICollection<User> LFriends = Core.GetFriendsOfUser(AccountHelpers.GetSignedUser().NidUser);
            return Json(LFriends, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Quiz(Category ACategory = Category.Energy, String ANamUser = "alissongiron")
        {
            User LUser = Core.GetUserByName(ANamUser);
            List<Question> LQuizQuestions = Core.GetQuestions(LUser.NidUser, LUser.AgeGroup, ACategory);


            Session["Questions"] = LQuizQuestions;

            List<Question> LQuestions = (List<Question>) Session["Questions"];

            Question LQuestion = LQuestions.FirstOrDefault();
            LQuestions.Remove(LQuestion);
            Session["Questions"] = LQuestions;
            
            QuizViewModel LReturnedQuestion = new QuizViewModel(LQuestion);
            LReturnedQuestion.QtyQuestions = (LQuestions.Count() + 1);

            return View(LReturnedQuestion);
        }

        public ActionResult Ranking()
        {
            return View(Core.GetRankingList());
        }
    }
}