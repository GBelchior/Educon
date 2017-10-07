using Educon.Core;
using Educon.Models;
using Educon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Educon.Controllers
{
    public class PortalController : Controller
    {
        private PortalCore Core = new PortalCore();        

        // GET: Portal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quiz(Category ACategory = Category.Energy, String ANamUser = "alissongiron")
        {
            // TODO: deixar o método GetUserByName estático
            
            //User LUser = Core.GetUserByName("ANamUser");
            //List<Question> LQuizQuestions = Core.GetQuestions(LUser.NidUser, LUser.AgeGroup, ACategory);

            List<Question> LQuizQuestions = Core.GetQuestions(1, AgeGroup.PreTeenager, ACategory);
            Session["Questions"] = LQuizQuestions;

            List<Question> LQuestions = (List<Question>) Session["Questions"];

            Question LQuestion = LQuestions.FirstOrDefault();
            LQuestions.Remove(LQuestion);
            Session["Questions"] = LQuestions;
            
            QuizViewModel LReturnedQuestion = new QuizViewModel(LQuestion);

            return View(LReturnedQuestion);
        }
    }
}