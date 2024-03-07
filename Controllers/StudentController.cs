using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MYCRUD;
using MYCRUD.Models;

namespace MYCRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentDBHandle dbhandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetStudent());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    StudentDBHandle dBHandle = new StudentDBHandle();
                    if (dBHandle.AddStudent(smodel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                    }
                    ModelState.Clear();
                }
            
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int ID)
        {
            StudentDBHandle sdb = new StudentDBHandle();
            return View(sdb.GetStudent().Find(StudentModel=>StudentModel.ID==ID));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel smodel)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
               
                sdb.UpdateDetails(smodel
                    );
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();


                if (sdb.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Sucessfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }  
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
