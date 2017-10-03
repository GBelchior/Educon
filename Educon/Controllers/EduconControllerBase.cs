using Educon.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Educon.Controllers
{
    public class EduconControllerBase<TEntity> : Controller where TEntity : class, new()
    {
        protected readonly EduconCoreBase<TEntity> FCore;

        static readonly JsonSerializerSettings FJsonConfig = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public EduconControllerBase(EduconCoreBase<TEntity> ACore)
        {
            FCore = ACore;
        }

        protected override void Dispose(bool disposing)
        {
            FCore.Dispose();
            base.Dispose(disposing);
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Create()
        {
            return View();
        }



        protected ActionResult RedirectToSaveType(String saveType)
        {
            if (saveType.ToLowerInvariant().Equals("savenew"))
            {
                return RedirectToAction("Create");
            }

            return RedirectToAction("Index");
        }
    }
}