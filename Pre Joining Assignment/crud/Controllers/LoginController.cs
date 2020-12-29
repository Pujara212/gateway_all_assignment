using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud.Models;
using log4net;

namespace crud.Controllers
{
    public class LoginController : Controller
    {
        SignupLoginEntities db = new SignupLoginEntities();
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginController));


        // GET: Login
        public ActionResult Index()
        {
            try
            {
                Log.Debug("Hi I am log4net Debug Level logincontroller index");
                Log.Info("Hi I am log4net Info Level  logincontroller index");
                Log.Warn("Hi I am log4net Warn Level  logincontroller index");

                return View();
            }
            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level  logincontroller index", ex);
                Log.Fatal("Hi I am log4net Fatal Level  logincontroller index", ex);
                throw;

            }
            }
        [HttpPost]
        public ActionResult Index(user u)
        {
          
            var user = db.users.Where(model => model.Email == u.Email && model.Password == u.Password).FirstOrDefault();
            var Username = user.UserName.ToString();
            if (user != null)
            {
                Session["UserID"] = u.Id.ToString();
                Session["Email"] = u.Email.ToString();
                Session["Username"] = user.UserName.ToString();


                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull')</script>";
                return RedirectToAction("Index", "User");


            }
            else
            {
                ViewBag.ErrorMessage= "<script>alert('UserName & Password Are Incorrect.')</script>";
                return View();

            }
         }

        public ActionResult Signup()
        {
            try
            {
                Log.Debug("Hi I am log4net Debug Level signup Get");
                Log.Info("Hi I am log4net Info Level signup Get");
                Log.Warn("Hi I am log4net Warn Level signup Get");


                return View();
            }
            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level signup Get", ex);
                Log.Fatal("Hi I am log4net Fatal Level signup Get", ex);
                throw;

            }
        }
        [HttpPost]
        public ActionResult Signup(user u)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    db.users.Add(u);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.InsertMessage = "<script>alert('Registered Successfully')</script>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.InsertMessage = "<script>alert('Registered Failed')</script>";

                    }
                }
                Log.Debug("Hi I am log4net Debug Level signup Post");
                Log.Info("Hi I am log4net Info Level signup Post");
                Log.Warn("Hi I am log4net Warn Level signup Post");

                return View();
            }
            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level signup Post", ex);
                Log.Fatal("Hi I am log4net Fatal Level signup Post", ex);
                throw;

            }
        }

    }
}