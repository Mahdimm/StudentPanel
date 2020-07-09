using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_app1.Models;

namespace StudentPanel.Controllers
{
    public class HomeController : Controller
    {
        IStudentBL stbl;

        public HomeController(IStudentBL s)
        {
           this.stbl = s;
        }
        [HttpGet]
        public ActionResult AddStudents()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudents(Student stu)
        {
            if (ModelState.IsValid)
            {
                stbl.insert(stu);
                ViewBag.InsertMessage = "اضافه شد";
            }
            return View();
        }


        public ActionResult ShowStudents()
        {
            List<Student> students = stbl.show();
            return View(students);
        }

        public ActionResult EditStudent(int id)
        {

            Student student = stbl.find(id);

            return View(student);
        }
        public ActionResult UpdateStudent(Student stu)
        {
            stbl.update(stu);
            ViewBag.message = "ویرایش شد";
            return View("EditStudent");
        }

        public ActionResult DeleteStudent(int id)
        {
            stbl.delete(id);
            ViewBag.message = "حذف شد";
            return RedirectToAction("ShowStudents");
        }

        public ActionResult DetailStudent(int id)
        {
            Student student = stbl.find(id);
            return View(student);
        }

    }
}