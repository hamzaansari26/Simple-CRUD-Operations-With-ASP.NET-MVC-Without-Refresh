using MVC_CRUD_Operations.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_Operations.Controllers
{
    public class StudentsController : Controller
    {
        dbContext db = new dbContext();
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(db.Students.ToList(),JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByID(int id)
        {
            var getStudent = db.Students.Find(id);

            return Json(getStudent, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var getStudent = db.Students.Find(id);
            db.Students.Remove(getStudent);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}