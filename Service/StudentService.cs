using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StudentService
    {
        public List<Student> Get()
        {
            List<Student> students = null;
            
            using (var context = new SchoolContext())
            {
                students = context.Students.Where(x => x.Activo == true).ToList();
            }

            return students;
        }
        public Student GetById(int ID)
        {
            Student student = null;
            using (var context = new SchoolContext())
            {
                student = context.Students.Find(ID);
            }
            return student;
        }

        public void Insert (Student student)
        {
            using(var context = new SchoolContext())
            {
                student.FechaCreacion = DateTime.Now;
                student.Activo = true;
                context.Students.Add(student);

                context.SaveChanges();
            }
        }

        public void Update(Student student, int ID)
        {
            using (var context = new SchoolContext())
            {
                var studentNew = context.Students.Find(ID);
                studentNew.Codigo = student.Codigo;
                studentNew.StudentName = student.StudentName;
                studentNew.LastName= student.LastName;
                studentNew.StudentAddress = student.StudentAddress;
                studentNew.FechaModificacion = DateTime.Now;

                context.SaveChanges();

            }
        }

        public void Delete (int ID)
        {
            using (var context=new SchoolContext())
            {
                var student = context.Students.Find(ID);
                student.Activo = false;
                //context.Students.Remove(student);
                context.SaveChanges();
            }
        }


    }
}
