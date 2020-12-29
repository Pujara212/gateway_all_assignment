using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud.Models;
using System.IO;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using log4net;

namespace crud.Controllers
{
    public class HomeController : Controller
    {
        crudDbEntities db = new crudDbEntities();
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        // GET: Home
        public ActionResult Index(string SearchBy, string search, int? page, string sortBy)
        {
            try
            {


                ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";
                ViewBag.SortCategoryParameter = sortBy == "Category" ? "Category desc" : "Category";

                var product = db.products.AsQueryable();



                if (SearchBy == "Product_name")
                {
                    product = product.Where(model => model.Product_name.StartsWith(search) || search == null);
                }
                else
                {
                    product = product.Where(model => model.Product_Category == search || search == null);

                }
                switch (sortBy)
                {
                    case "Name desc":
                        product = product.OrderByDescending(model => model.Product_name);
                        break;

                    case "Category desc":
                        product = product.OrderByDescending(model => model.Product_Category);
                        break;

                    case "Category":
                        product = product.OrderBy(model => model.Product_Category);
                        break;

                    default:
                        product = product.OrderBy(model => model.Product_name);
                        break;

                }
                Log.Debug("Hi I am log4net Debug Level in Index Controller try block");
                Log.Info("Hi I am log4net Info Level in Index Controller try block");
                Log.Warn("Hi I am log4net Warn Level in Index Controller try block");
                return View(product.ToPagedList(page ?? 1, 3));
            }
            catch(Exception ex)
            {
                Log.Error("Hi I am log4net Error Level in Index Controller Exception", ex);
                Log.Fatal("Hi I am log4net Fatal Level in Index Controller Exception", ex);
                throw;
            }
            }
        public ActionResult Create()
        {
            try
            {
                Log.Debug("Hi I am log4net Debug Level in Create Controller try block Get");
                Log.Info("Hi I am log4net Info Level  in Create Controller try block Get");
                Log.Warn("Hi I am log4net Warn Level  in Create Controller try block Get");
                return View();
            }
            catch (Exception ex)
            {
                Log.Error("Hi I am log4net Error Level  in Create Controller Catch block Get", ex);
                Log.Fatal("Hi I am log4net Fatal Level   in Create Controller Catch block Get", ex);
                throw;
            }
           
        }
        [HttpPost]

        public ActionResult Create(product p)
        {
            try
            {


                if (ModelState.IsValid == true)
                {
                    string filename = Path.GetFileNameWithoutExtension(p.SImageFile.FileName);
                    string extension = Path.GetExtension(p.SImageFile.FileName);
                    HttpPostedFileBase postedFile = p.SImageFile;
                    int length = postedFile.ContentLength;

                    string filename1 = Path.GetFileNameWithoutExtension(p.LImageFile.FileName);
                    string extension1 = Path.GetExtension(p.LImageFile.FileName);
                    HttpPostedFileBase postedFile1 = p.LImageFile;
                    int length1 = postedFile.ContentLength;



                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png" && extension1.ToLower() == ".png" || extension1.ToLower() == ".jpeg" || extension1.ToLower() == ".jpg")
                    {
                        if (length <= 1000000 && length1 <= 100000000)
                        {
                            filename = filename + extension;
                            p.Small_Image_path = "~/SImages/" + filename;
                            filename = Path.Combine(Server.MapPath("~/SImages/"), filename);
                            p.SImageFile.SaveAs(filename);

                            filename1 = filename1 + extension1;
                            p.Large_Image_path = "~/LImages/" + filename1;
                            filename1 = Path.Combine(Server.MapPath("~/LImages/"), filename1);
                            p.LImageFile.SaveAs(filename1);

                            db.products.Add(p);
                            int a = db.SaveChanges();

                            if (a > 0)
                            {
                                TempData["CreateMessage"] = "<script>alert('Data Inserted Successfully') </script>";
                                ModelState.Clear();
                                return RedirectToAction("index", "Home");
                            }
                            else
                            {
                                TempData["CreateMessage"] = "<script>alert('Data Not Inserted') </script>";

                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size Should be less than 5 MB') </script>";

                        }

                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported') </script>";
                    }
                }
                Log.Debug("Hi I am log4net Debug Level  in Create Controller try block post");
                Log.Info("Hi I am log4net Info Level  in Create Controller try block post");
                Log.Warn("Hi I am log4net Warn Level  in Create Controller try block post");
              
                return View();
            }
            catch(Exception ex)
            {
                Log.Error("Hi I am log4net Error Level  in Create Controller Catch block post", ex);
                Log.Fatal("Hi I am log4net Fatal Level  in Create Controller Catch block post", ex);
                throw;
            }

            }

        public ActionResult Edit(int id)
        {
            try
            {


                var productrow = db.products.Where(model => model.Product_id == id).FirstOrDefault();
                Session["Simage"] = productrow.Small_Image_path;
                Session["Limage"] = productrow.Large_Image_path;

                Log.Debug("Hi I am log4net Debug Level  in Edit  Controller try block get");
                Log.Info("Hi I am log4net Info Level  in   Edit  Controller try block  get");
                Log.Warn("Hi I am log4net Warn Level  in  Edit  Controller try block post");

                return View(productrow);
            }
            catch(Exception ex)
            {
                Log.Error("Hi I am log4net Error Level  in Edit Controller Catch block get", ex);
                Log.Fatal("Hi I am log4net Fatal Level  in  Edit Controller Catch block get", ex);
                throw;

            }
        }
        [HttpPost]
        public ActionResult Edit(product p)
        {
            if (ModelState.IsValid == true)
            {
                if (p.SImageFile != null & p.LImageFile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(p.SImageFile.FileName);
                    string extension = Path.GetExtension(p.SImageFile.FileName);
                    HttpPostedFileBase postedFile = p.SImageFile;
                    int length = postedFile.ContentLength;

                    string filename1 = Path.GetFileNameWithoutExtension(p.LImageFile.FileName);
                    string extension1 = Path.GetExtension(p.LImageFile.FileName);
                    HttpPostedFileBase postedFile1 = p.LImageFile;
                    int length1 = postedFile.ContentLength;



                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            filename = filename + extension;
                            p.Small_Image_path = "~/SImages/" + filename;
                            filename = Path.Combine(Server.MapPath("~/SImages/"), filename);
                            p.SImageFile.SaveAs(filename);

                            filename1 = filename1 + extension1;
                            p.Large_Image_path = "~/LImages/" + filename1;
                            filename1 = Path.Combine(Server.MapPath("~/LImages/"), filename1);
                            p.SImageFile.SaveAs(filename1);

                            db.Entry(p).State = EntityState.Modified;
                            int a = db.SaveChanges();

                            if (a > 0)
                            {
                                string S_image_path = Request.MapPath(Session["Simage"].ToString());
                                string L_image_path = Request.MapPath(Session["Limage"].ToString());

                                if (System.IO.File.Exists(S_image_path) & System.IO.File.Exists(L_image_path))
                                {
                                    System.IO.File.Delete(S_image_path);
                                    System.IO.File.Delete(L_image_path);

                                }
                                TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully') </script>";
                                ModelState.Clear();
                                return RedirectToAction("index", "Home");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data Not Updated') </script>";


                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size Should be less than 5 MB') </script>";

                        }

                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported') </script>";
                    }
                }
                else
                {
                    p.Small_Image_path = Session["Simage"].ToString();
                    p.Large_Image_path = Session["Limage"].ToString();

                    db.Entry(p).State = EntityState.Modified;
                    int a = db.SaveChanges();

                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully') </script>";
                        ModelState.Clear();
                        return RedirectToAction("index", "Home");
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
            if (id > 0)
            {
                var productraw = db.products.Where(model => model.Product_id == id).FirstOrDefault();
                if (productraw != null)
                {
                    db.Entry(productraw).State = EntityState.Deleted;

                    int a = db.SaveChanges();
                    if (a > 0)
                    {

                        TempData["DeleteMessage"] = "<script>alert('Data Deleted Succesfully')</script>";
                        string S_image_path = Request.MapPath(productraw.Small_Image_path.ToString());
                        string L_image_path = Request.MapPath(productraw.Large_Image_path.ToString());

                        if (System.IO.File.Exists(S_image_path) & System.IO.File.Exists(L_image_path))
                        {
                            System.IO.File.Delete(S_image_path);
                            System.IO.File.Delete(L_image_path);

                        }

                    }
                    else
                    {

                        TempData["DeleteMessage"] = "<script>alert('Data Not Deleted')</script>";

                    }

                }

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var producrtraw = db.products.Where(model => model.Product_id == id).FirstOrDefault();
            Session["image1"] = producrtraw.Small_Image_path.ToString();
            Session["image2"] = producrtraw.Large_Image_path.ToString();

            return View(producrtraw);
        }
        /*     [HttpPost]
             public ActionResult Delete(IEnumerable<int> productIdsToDelete)
             {
                 List<product> products = db.products.Where(model => productIdsToDelete.Contains(model.Product_id)).ToList();

                 foreach(product p in products)
                    {         

                     db.products.Remove(p);

                     }

                 db.SaveChanges();

                 return RedirectToAction("Index");

             }
     */

        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            string[] ids = formCollection["ID"].Split(new char[] { ',' });
            foreach (string id in ids)
            {
                var employee = this.db.products.Find(int.Parse(id));
                this.db.products.Remove(employee);
                this.db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }

}