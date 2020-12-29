using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
namespace crud.Controllers
{
    public class UserController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserController));

        // GET: User
        public ActionResult Index()
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();

            }
        }
        public ActionResult Logout()
        {
            try
            {


                Session.Abandon();
                Log.Debug("Hi I am log4net Debug Level logout Controller try");
                Log.Info("Hi I am log4net Info Level logout Controller try");
                Log.Warn("Hi I am log4net Warn Level logout Controller try");
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level logout Controller exception", ex);
                Log.Fatal("Hi I am log4net Fatal Level  logout Controller exception", ex);
                throw;
            }
            }
    }
}
