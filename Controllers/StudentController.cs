using Domain;
using MVCAJAX_.Net.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Threading.Tasks;
using MVCAJAX_.Net.Proxy;
using System.Collections.ObjectModel;

namespace MVCAJAX_.Net.Controllers
{
    public class StudentController : Controller
    {

        private ApiService apiService = new ApiService();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexRazor()
        {
            var model = apiService.GetList<StudentModel>("http://localhost:44387", "/api", "/Student/GetAllStudents");
            return View(model.Result.Resultado);
        }

        public JsonResult getStudent(string id)
        {
            var response = Task.Run(() => apiService.GetList<StudentModel>("http://localhost:44387", "/api", "/Student/GetAllStudents"));
            System.Console.WriteLine(response.Result.Resultado);
            return Json(response.Result.Resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentModel std)
        {
            std.FechaCreacion = DateTime.Today;
            var response = Task.Run(() => apiService.Post<StudentModel>("http://localhost:44387", "/api", "/Student/Post", std));

            string message = "SUCCESS";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        //[HttpPost]
        //public ActionResult DeleteStudent (int id)
        //{
        //    service.Delete(id);
        //    string message = "SUCCESS";
        //    return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        //}

        //[HttpPost]
        //public ActionResult EstudentDetail(int id)
        //{
        //    return (Json(service.GetById(id), JsonRequestBehavior.AllowGet ));

        //}

        //[HttpPost]
        //public ActionResult UpdateStudent(Student std)
        //{
        //    service.Update(std, std.StudentID);
        //    string message = "SUCCESS";
        //    return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        //}

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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
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
            return View();
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
