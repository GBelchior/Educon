using Educon.Core;
using Educon.Models;
using Educon.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Educon.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        QuizCore Core = new QuizCore(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EndGame(bool AWin)
        {
            ViewBag.Win = AWin;
            return View();
        }

        public ActionResult NextQuestion()
        {
            List<Question> LQuestions = (List<Question>) Session["Questions"];

            if (LQuestions.Count == 0)
                RedirectToAction("EndGame", new { AWin = true });

            Question LQuestion = LQuestions.FirstOrDefault();
            LQuestions.Remove(LQuestion);
            Session["Questions"] = LQuestions;

            QuizViewModel LReturnedQuestion = new QuizViewModel(LQuestion);

            return Json(LReturnedQuestion, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidateAnswer(int ANidUser, int ANidQuestion, int ANumAnswer)
        {
            Question LQuestion = Core.GetQuestion(ANidQuestion);
            QuizAnswerViewModel LAnswer = new QuizAnswerViewModel();

            //LAnswer.Answer = LQuestion.DesAnswer;
            LAnswer.Answer = "oi tudo bom";
            LAnswer.NumCorrectAnswer = LQuestion.NumCorrectAnswer;
            LAnswer.IsCorrect = (LQuestion.NumCorrectAnswer == ANumAnswer);
                
            if (LAnswer.IsCorrect)
            {
                // Adiciona questao correta no user
            }

            return Json(LAnswer, JsonRequestBehavior.AllowGet);
        }


    }
}