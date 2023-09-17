using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_Management.Data;
using Car_Management.Models;

namespace Car_Management.Controllers
{
    public class CarModelsController : Controller
    {
        private Car_ManagementContext db = new Car_ManagementContext();

        // GET: CarModels
        public ActionResult Index()
        {
            return View(db.CarModels.ToList());
        }

        // GET: CarModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,Class,ModelName,ModelCode,Description,Features,Price,DateOfManufacturing,Active,SortOrder,Image,FileBase")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                string filename = Path.GetFileName(carModel.FileBase.FileName);
                string _filename = DateTime.Now.ToString("hhmmssfff") + filename; 
                string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
                carModel.Image = "~/Images/" + _filename;
                db.CarModels.Add(carModel);

                if (carModel.FileBase.ContentLength <= 5000000)
                {
                    if (db.SaveChanges() > 0)
                    {
                        carModel.FileBase.SaveAs(path);
                    }
                    return RedirectToAction("Index");
                }
                else { ViewBag.msg = "File must be less than of equal to 5 MB"; }
            }
            return View(carModel);
        }

        // GET: CarModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Brand,Class,ModelName,ModelCode,Description,Features,Price,DateOfManufacturing,Active,SortOrder,Image,FileBase")] CarModel carModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string filenames = Path.GetFileName(carModel.FileBase.FileName);
        //        string _filenames = DateTime.Now.ToString("hhmmssfff") + filenames;
        //        string path = Path.Combine(Server.MapPath("~/Images/"), _filenames);
        //        carModel.Image = "~/Images/" + _filenames;
        //        if (carModel.FileBase.ContentLength < 5000000)
        //        {
        //            db.Entry(carModel).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    else { ViewBag.msg = "File must be less than of equal to 5 MB"; }
        //    return View(carModel);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,Class,ModelName,ModelCode,Description,Features,Price,DateOfManufacturing,Active,SortOrder,Image,FileBase")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                // Check if a new file has been uploaded
                if (carModel.FileBase != null && carModel.FileBase.ContentLength > 0)
                {
                    // Generate a new filename and save the uploaded file
                    string filename = Path.GetFileName(carModel.FileBase.FileName);
                    string _filename = DateTime.Now.ToString("hhmmssfff") + filename;
                    string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
                    carModel.Image = "~/Images/" + _filename;

                    if (carModel.FileBase.ContentLength <= 5000000)
                    {
                        // Update the carModel and save changes
                        db.Entry(carModel).State = EntityState.Modified;
                        db.SaveChanges();

                        carModel.FileBase.SaveAs(path); // Save the uploaded file
                    }
                    else
                    {
                        ViewBag.msg = "File must be less than or equal to 5 MB";
                        return View(carModel); // Return the view with an error message
                    }
                }
                else
                {
                    // No file has been uploaded, simply update the carModel
                    db.Entry(carModel).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "File must be less than or equal to 5 MB";
            }

            return View(carModel);
        }




        // GET: CarModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModel carModel = db.CarModels.Find(id);
            db.CarModels.Remove(carModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
