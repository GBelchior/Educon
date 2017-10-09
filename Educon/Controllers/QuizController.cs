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

        public ActionResult EndGame(bool AWin, int AQtyCorQuestions, int AQtyQuestions)
        {
            ViewBag.Win = AWin;
            SinglePlayerEndGameViewModel LModel = new SinglePlayerEndGameViewModel();
            LModel.QtyCorQuestions = AQtyCorQuestions;
            LModel.QtyQuestions = AQtyQuestions;
            LModel.QtyExperience = (AQtyCorQuestions * 50);

            return View(LModel);
        }

        public ActionResult Lose(int AQtyCorQuestions, int AQtyQuestions)
        {
            return Json((new { redirectUrl = Url.Action("EndGame", "Quiz", new { AWin = false, AQtyCorQuestions = AQtyCorQuestions - 1, AQtyQuestions = AQtyQuestions }) }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult NextQuestion(int AQtyQuestions)
        {
            List<Question> LQuestions = (List<Question>) Session["Questions"];

            if (LQuestions.Count == 0)
                return Json((new { redirectUrl = Url.Action("EndGame", "Quiz", new { AWin = true, AQtyCorQuestions = AQtyQuestions, AQtyQuestions = AQtyQuestions })}), JsonRequestBehavior.AllowGet);

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

            LAnswer.Answer = LQuestion.DesAnswer;
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