using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YasamIcin.UI.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string ErrorText)
        {
            if (ErrorText == null)
                return RedirectToAction("Anasayfa", "Home");
            ViewBag.Error = ErrorText;
            return View();
        }
    }
}