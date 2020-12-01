using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnotationCrud.Models;
using System.IO;
using System.Data.Entity;

namespace AnnotationCrud.Controllers
{
    public class HomeController : Controller
    {
        EmployeeEntities db = new EmployeeEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Emps.ToList();
            return View(data);
        }

        public ActionResult Create()
        {

             return View();
        }

        [HttpPost]
        public ActionResult Create(Emp e)
        {
            if(ModelState.IsValid ==true)
            {
                string filename = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                string extension = Path.GetExtension(e.ImageFile.FileName);
                HttpPostedFileBase postedfile = e.ImageFile;
                int length = postedfile.ContentLength;
                if(extension.ToLower()==".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    if (length <= 5000000)
                    {

                        filename = filename + extension;
                        e.Image_path = "~/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                        e.ImageFile.SaveAs(filename);
                        db.Emps.Add(e);
                        int a=db.SaveChanges();
                        if (a>0)
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Inserted SuccessFully') </script>";
                            ModelState.Clear();
                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Not Inserted') </script>";

                        }
                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Size Must be Less than 5MB') </script>";

                    }


                }
                else
                {
                    TempData["extensionMessage"]= "<script>alert('Extension Not Supported') </script>";
                }


            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            var EmployeeRow = db.Emps.Where(model => model.Id == id).FirstOrDefault();
            Session["Image"] = EmployeeRow.Image_path;
            return View(EmployeeRow);
        }

        [HttpPost]
        public ActionResult Edit(Emp e)
        {
            
            if(ModelState.IsValid ==true)
            {
                if(e.ImageFile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                    string extension = Path.GetExtension(e.ImageFile.FileName);
                    HttpPostedFileBase postedfile = e.ImageFile;
                    int length = postedfile.ContentLength;
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (length <= 5000000)
                        {

                            filename = filename + extension;
                            e.Image_path = "~/Images/" + filename;
                            filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                            e.ImageFile.SaveAs(filename);
                            db.Entry(e).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                string Imagepath = Request.MapPath(Session["Image"].ToString());
                                if (System.IO.File.Exists(Imagepath))
                                {
                                    System.IO.File.Delete(Imagepath);
                                }
                                TempData["UpdateMessage"] = "<script>alert('Data Updated SuccessFully') </script>";
                                ModelState.Clear();
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data Not Updated') </script>";

                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Size Must be Less than 5MB') </script>";

                        }


                    }
                    else
                    {
                        TempData["extensionMessage"] = "<script>alert('Extension Not Supported') </script>";
                    }


                }
                else
                {
                    e.Image_path = Session["Image"].ToString();
                    db.Entry(e).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated SuccessFully') </script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Not Updated') </script>";

                    }

                }

            }
            return View();
        }

       
        public ActionResult Delete(int id)
        {
            if (id>0)
            {
                var Employeeraw = db.Emps.Where(model=>model.Id==id).FirstOrDefault();

                if (Employeeraw !=null)
                {
                    db.Entry(Employeeraw).State = EntityState.Deleted;
                    int a=  db.SaveChanges();
                    if (a>0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted')</script>";
                        string Imagepath = Request.MapPath(Employeeraw.Image_path.ToString());
                        if (System.IO.File.Exists(Imagepath))
                        {
                            System.IO.File.Delete(Imagepath);
                        }
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not  Deleted')</script>";

                    }

                }

            }
            return RedirectToAction("Index","Home");

        }


        public ActionResult Details(int id)
        {
            var employeerow = db.Emps.Where(model=>model.Id==id).FirstOrDefault();
            Session["Image2"] = employeerow.Image_path.ToString();
            return View(employeerow);


        }
    }
}