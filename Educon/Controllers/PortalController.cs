using Educon.Helpers;
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
        private static object FLock = new object();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategorySelection()
        {
            return View();
        }

        public ActionResult GetFriendsOfUser()
        {
            ICollection<User> LFriends = Core.GetFriendsOfUser(AccountHelpers.GetSignedUser().NidUser);
            ICollection<User> LUserFriends = new List<User>();
            foreach (User LUser in LFriends)
            {
                LUserFriends.Add(new User { NidUser = LUser.NidUser, NamUser = LUser.NamUser, IsOnline = LUser.IsOnline, QtdExperience = LUser.QtdExperience, NamPerson = LUser.NamPerson });
            }

            return Json(LUserFriends, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Quiz(Category? ACategory)
        {
            User LUser = AccountHelpers.GetSignedUser();
            List<Question> LQuizQuestions = Core.GetQuestions(LUser.AgeGroup, ACategory);

            Session["Questions"] = LQuizQuestions;

            List<Question> LQuestions = (List<Question>)Session["Questions"];

            Random LRandom = new Random();
            int LIndex = LRandom.Next(LQuestions.Count);

            Question LQuestion = LQuestions.ElementAt(LIndex);
            LQuestions.Remove(LQuestion);
            Session["Questions"] = LQuestions;

            QuizViewModel LReturnedQuestion = new QuizViewModel(LQuestion);
            LReturnedQuestion.QtyQuestions = (LQuestions.Count() + 1);
            LReturnedQuestion.NidUser = LUser.NidUser;

            return View(LReturnedQuestion);
        }

        public ActionResult StartGameBetween(string ANamUser1, string ANamUser2)
        {
            lock (FLock)
            {
                HttpContext.Application[$"Game-[{ANamUser1}]-{ANamUser2}"] =
                    Core.GetQuestionListForMatch(ANamUser1, ANamUser2, 15);

                HttpContext.Application["EndGame" + ANamUser1] = null;
                HttpContext.Application["EndGame" + ANamUser2] = null;

                HttpContext.Application["QtyCorAnswers" + ANamUser1] = 0;
                HttpContext.Application["QtyCorAnswers" + ANamUser2] = 0;

                Session["NumCurrentQuestion"] = 1;

                Question LFirstQuestion = ((ICollection<Question>)HttpContext.Application[$"Game-[{ANamUser1}]-{ANamUser2}"]).First();

                ViewBag.MultiPlayer = true;

                QuizViewModel LQuestion = new QuizViewModel(LFirstQuestion);
                LQuestion.NidUser = AccountHelpers.GetSignedUser().NidUser;
                LQuestion.QtyQuestions = 15 + 1 - (int)Session["NumCurrentQuestion"];

                return View("Quiz", LQuestion);
            }
        }

        public ActionResult AddFriend(string AUserName)
        {
            bool LCanAddFriend = false;
            if (VerifyUser(AUserName))
            {
                Core.AddFriend(AccountHelpers.GetSignedUser(), Core.GetUserByName(AUserName));
                LCanAddFriend = true;
            }
            return Json(LCanAddFriend, JsonRequestBehavior.AllowGet);
        }

        private bool VerifyUser(string AUserName)
        {
            User LUser = Core.GetUserByName(AUserName);

            return (LUser != null);
        }

        public ActionResult Ranking()
        {
            return View(Core.GetRankingList());
        }
    }
}