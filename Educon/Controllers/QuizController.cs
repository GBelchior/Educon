using Educon.Core;
using Educon.Models;
using Educon.ViewModels;
using System;
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

            Random LRandom = new Random();
            int LIndex = LRandom.Next(LQuestions.Count);

            Question LQuestion = LQuestions.ElementAt(LIndex);
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
                Core.IncreaseUserExperience(50, ANidUser);
            }

            Core.ComputeAnswer(ANidUser, ANidQuestion);

            return Json(LAnswer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NextMultiplayerQuestion(string ANamUser1, string ANamUser2)
        {
            ICollection<Question> LMatchQuestions = ((ICollection<Question>)HttpContext.Application[$"Game-[{ANamUser1}]-{ANamUser2}"]);
            int LNextQuestion = (int)Session["NumCurrentQuestion"];
            Session["NumCurrentQuestion"] = LNextQuestion + 1;

            Question LQuestion = LMatchQuestions.ElementAt(LNextQuestion);

            return Json(new QuizViewModel(LQuestion), JsonRequestBehavior.AllowGet);
        }
    }
}