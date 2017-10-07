using Educon.Core;
using Educon.Helpers;
using Educon.Models;
using Educon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Educon.Controllers
{
    public class UserController : EduconControllerBase<User>
    {
        private UserCore Core
        {
            get
            {
                return (UserCore)base.FCore;
            }
        }
        public UserController() : base(new UserCore()) { }

        public ActionResult Register()
        {
            return View("Register");
        }

        public ActionResult SignIn(string AUserName, string APassword)
        {
            User LUser = Core.GetUserByUserNamePassword(AUserName, APassword);
            AccountHelpers.SignIn(LUser);
            return Json(LUser, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignOut()
        {
            AccountHelpers.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

       
        [HttpPost]
        public ActionResult Create(string ADesName, string ADesUserName, int AAgeGroup, string ADesPassword, string ADesConfirmPassword, string ADesEmail)
        {
            ErrorType LErrorType = ErrorType.None;

            if (!ADesPassword.Equals(ADesConfirmPassword))
            {
                ModelState.AddModelError("Senha", "As senhas não coincidem.");
                LErrorType = ErrorType.Password;
            }
            if (Core.GetUserByName(ADesUserName) != null)
            {
                ModelState.AddModelError("Usuário", "O nome de usuário já existe.");
                LErrorType = ErrorType.User;
            }
            if (Core.GetUserByEmail(ADesEmail) != null)
            {
                ModelState.AddModelError("Email", "Esse email já foi utilizado.");
                LErrorType = ErrorType.Email;
            }

            AgeGroup LAgeGroup = (AgeGroup)Enum.ToObject(typeof(AgeGroup), AAgeGroup)-1;

            User LUser = new Models.User { NamPerson = ADesName, NamUser = ADesUserName, DesEmail = ADesEmail, DesPassword = ADesPassword, AgeGroup = LAgeGroup };

            if (ModelState.IsValid)
            {
            Core.Add(LUser);
                
            }

            return Json(GeneralUtils.ConvertToString(LErrorType), JsonRequestBehavior.AllowGet);

        }


    }
}