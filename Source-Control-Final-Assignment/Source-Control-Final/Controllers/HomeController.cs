using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Source_Control_Final.Models;
using log4net;
namespace Source_Control_Final.Controllers
{
    public class HomeController : Controller
    {

        EmployeeDbEntities db = new EmployeeDbEntities();
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        // GET: Home
        public ActionResult Index()
        {  
            return View();
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    string filename = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                    string extension = Path.GetExtension(e.ImageFile.FileName);
                    HttpPostedFileBase postedFile = e.ImageFile;
                    int length = postedFile.ContentLength;

                    if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
                    {
                        if (length <= 5000000)
                        {
                            filename = filename + extension;
                            e.Image_path = "~/images/" + filename;
                            filename = Path.Combine(Server.MapPath("~/images/"), filename);
                            e.ImageFile.SaveAs(filename);
                            db.Employees.Add(e);
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                TempData["SuccessMessage"] = "<script>alert('Registered Successfully')</script>";
                                ModelState.Clear();
                                return RedirectToAction("Login", "Home");
                            }
                            else
                            {
                                TempData["SuccessMessage"] = "<script>alert('Registered Not Successfully')</script>";

                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Size Should be Less than 5 MB.')</script>";

                        }

                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported')</script>";
                    }

                }
                Log.Debug("Hi I am log4net Debug Level Success Registration");
                Log.Info("Hi I am log4net Info Level  Success Registration");
                Log.Warn("Hi I am log4net Warn Level  Success Registration");
                return View();
            }
            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level Error in Registration", ex);
                Log.Fatal("Hi I am log4net Fatal Level  Error in Registration", ex);
                throw;
            }
        }
            


        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee e)
        {

            try
            {
                var data = db.Employees.Where(model => model.Email == e.Email && model.Password == e.Password).FirstOrDefault();
                if (data != null)
                {
                    Session["EmployeeId"] = data.Employee_Id.ToString();
                    Session["Name"] = data.Name;
                    Session["Age"] = data.Age.ToString();
                    Session["Gender"] = data.Gender;
                    Session["DOB"] = data.DOB.ToString();
                    Session["Designation"] = data.Designation;
                    Session["Contact_no"] = data.Contact_No.ToString();
                    Session["Email"] = data.Email;
                    Session["Address"] = data.Address;
                    Session["Image"] = data.Image_path;
                    TempData["LoginSucess"] = "<script>alert('Login Successfully')</script>";

                    Log.Debug("Hi I am log4net Debug Level Login Controller");
                    Log.Info("Hi I am log4net Info Level Login Controller");
                    Log.Warn("Hi I am log4net Warn Level Login Controller");


                    return RedirectToAction("Details", "Home");
                }
                else
                {
                    TempData["LoginSucess"] = "<script>alert('Email Or Password is Incorrect')</script>";
                    Log.Debug("Hi I am log4net Debug Level incorrect Information In Login");
                    Log.Info("Hi I am log4net Info Level incorrect Information In Login");
                    Log.Warn("Hi I am log4net Warn Level incorrect Information In Login");

                    return View();
                }
            }
            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level", ex);
                Log.Fatal("Hi I am log4net Fatal Level", ex);
                throw;
            }
        }

        public ActionResult Details()
        {
            try
            {

                if (Session["EmployeeId"] == null)
                {
                    Log.Debug("Hi I am log4net Debug Level For Details Of Employee Id");
                    Log.Info("Hi I am log4net Info Level  For Details Of Employee Id");
                    Log.Warn("Hi I am log4net Warn Level  For Details Of Employee Id");

                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    Log.Debug("Hi I am log4net Debug Level");
                    Log.Info("Hi I am log4net Info Level");
                    Log.Warn("Hi I am log4net Warn Level");

                    return View();

                }
            }

            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level Can't Get Access", ex);
                Log.Fatal("Hi I am log4net Fatal Level Can't Get Access", ex);
                throw;
            }

        }


        public ActionResult Logout()
        {

            try
            {
                Session.Abandon();
                Log.Debug("Hi I am log4net Debug Level For Logout");
                Log.Info("Hi I am log4net Info Level For Logout");
                Log.Warn("Hi I am log4net Warn Level  For Logout");

                return RedirectToAction("Login", "Home");

            }
            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level  For Logout", ex);
                Log.Fatal("Hi I am log4net Fatal Level  For Logout", ex);
                throw;
            }
        }
        }
    }