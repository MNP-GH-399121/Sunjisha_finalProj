using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studentportal.Data;
using Studentportal.Model;
using Studentportal.Model.Entities;

namespace Studentportal.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDbcontext dbcontext;

        public StudentController(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAllEmployess()
        {
            var allStudents = dbcontext.Students.ToList();
            return Ok(allStudents);

        }


        [HttpPost]
        public IActionResult AddStudent(AddStudentDto addStudentdtl)
        {
            var studentEntity = new Student()
            {
                Id = addStudentdtl.Id,
                StudentName = addStudentdtl.StudentName,
                courseID = addStudentdtl.courseID,
                password = addStudentdtl.password,
            };
            dbcontext.Students.Add(studentEntity);
            dbcontext.SaveChanges();
            return Ok(studentEntity);

        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployessbyid(Guid id)
        {
            var student = dbcontext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpadteEmployee(int id, UpdateStudent updateStudent)
        {
            var student = dbcontext.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }


            student.StudentName = updateStudent.StudentName;
            student.courseID = updateStudent.courseID;
            student.password = updateStudent.password;
            dbcontext.SaveChanges();
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddLoginDetails(AddStudentDto AddStudentDto)
        {
            var studentEntity = new Student()
            {
                Id = AddStudentDto.Id,
                StudentName = AddStudentDto.StudentName,
                password = AddStudentDto.password,
            };
            dbcontext.Students.Add(studentEntity);
            dbcontext.SaveChanges();
            return Ok(studentEntity);
        }
    }
}
