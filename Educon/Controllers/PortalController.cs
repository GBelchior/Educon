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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFriendsOfUser()
        {
            ICollection<User> LFriends = Core.GetFriendsOfUser(AccountHelpers.GetSignedUser().NidUser);
            ICollection<User> LUserFriends = new List<User>();
            foreach(User LUser in LFriends)
            {
                LUserFriends.Add(new User { NidUser = LUser.NidUser, NamUser = LUser.NamUser, IsOnline = LUser.IsOnline, QtdExperience = LUser.QtdExperience, NamPerson = LUser.NamPerson });
            }

            return Json(LUserFriends, JsonRequestBehavior.AllowGet);
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
            return (LUser != null) ? true : false;
        }        
        public ActionResult Ranking()
        {
            return View(Core.GetRankingList());
        }
    }
}