using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private StudentService service = new StudentService();

        // GET: api/Student
        [HttpGet]
        public JsonResult<List<StudentModel>> GetAllStudents()
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            List<Student> prodList = service.Get();
            List<StudentModel> students = new List<StudentModel>();
            foreach (var item in prodList)
            {
                students.Add(mapObj.Translate(item));
            }
            return Json<List<StudentModel>>(students);
        }

        // GET: api/Student/5
        [HttpGet]
        public JsonResult<StudentModel> GetStudent(int id)
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            Student DOStudent = service.GetById(id);
            StudentModel student = new StudentModel();
            student = mapObj.Translate(DOStudent);
            return Json<StudentModel>(student);
        }

        // POST: api/Student
        [HttpPost]
        public bool Post(StudentModel Student)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
                Student DOStudent = new Student();
                DOStudent = mapObj.Translate(Student);
                service.Insert(DOStudent);
                status = true;
            }
            return status;
        }


        // PUT: api/Student/5
        [HttpPut]
        public bool Put(StudentModel Student)
        {
            bool status = false;
            EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
            Student DOStudent = new Student();
            DOStudent = mapObj.Translate(Student);
            service.Update(DOStudent, DOStudent.StudentID);
            status = true;
            return status;
        }

        // DELETE: api/Student/5
        [HttpDelete]
        public bool Delete(int id)
        {
            bool status = false;
            service.Delete(id);
            status = true;
            return status;
        }
    }
}
