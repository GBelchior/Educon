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
    public class QuizController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EndGame()
        {
            return View();
        }

        public ActionResult NextQuestion()
        {
            List<Question> LQuestions = (List<Question>)Session["Questions"];

            if (LQuestions.Count == 0)
                RedirectToAction("EndGame");

            Question LQuestion = LQuestions.FirstOrDefault();
            LQuestions.Remove(LQuestion);
            Session["Questions"] = LQuestions;

            QuizViewModel LReturnedQuestion = new QuizViewModel(LQuestion);

            return Json(LReturnedQuestion, JsonRequestBehavior.AllowGet);
        }
    }
}