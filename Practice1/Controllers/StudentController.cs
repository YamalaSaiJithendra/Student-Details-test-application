using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Practice1.Models;
using Practice1.Repository;
using System.Linq.Expressions;

namespace Practice1.Controllers
{
    public class StudentController : Controller
    {

        public readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //private IActionResult GetConnectionString()
        //{
        //    var conStr = _configuration.GetConnectionString("getconn");
        //    SqlConnection con = new SqlConnection(conStr);
        //    return View(con); 
        //}
       
        public IActionResult GetAllStdDetails()
        {
            //For ConnectionString value
            //var conStr = _configuration.GetConnectionString("getconn");
            //SqlConnection con = new SqlConnection(conStr);

            StudentRepository StdRepo = new StudentRepository();
            ModelState.Clear();
            return View(StdRepo.GetAllStudents());
        }
        //GET: GetSudentDetails
        public IActionResult AddStudentDetails()
        {
            return View();
        }

        //POST: Student:AddStudent
        [HttpPost]
        public IActionResult AddStudentDetails(StudentModel std)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    StudentRepository StdRepo = new StudentRepository();
                    if (StdRepo.AddStudentDetails(std))
                        {
                        ViewBag.Message = "Student Records added succesfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        // GET: Student/EditSTDDetails/5
        public IActionResult EditSTDDetails(int id)
        {
            StudentRepository StdRepo = new StudentRepository();
            return View(StdRepo.GetAllStudents().Find(Std => Std.StudentId == id));

        }

        // POST: Student/EditSTDDetails/5
        [HttpPost]

        public IActionResult EditSTDDetails(int id, StudentModel obj)
        {
            try
            {
                StudentRepository StdRepo = new StudentRepository();

                StdRepo.UpdateStudent(obj);

                return RedirectToAction("GetAllStdDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/DeleteStd/5
        public IActionResult DeleteStd(int id)
        {
            try
            {
                StudentRepository StdRepo = new StudentRepository();
                if (StdRepo.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student details deleted successfully";

                }
                return RedirectToAction("GetAllStdDetails");

            }
            catch
            {
                return View();
            }
        }
        //Get all teachers
        [HttpGet]
        public IActionResult GetAllTcrDetails()
        {
            TeacherRepository TcrRepo = new TeacherRepository();
            ModelState.Clear();
            return View(TcrRepo.GetAllTeachers());
        }
        //GET : Get Teacher details
        public IActionResult AddTeacherDetails()
        {
            return View();
        }
        //POST: Teacher:AddTeacherDetails
        [HttpPost]
        public IActionResult AddTeacherDetails(TeacherModel tcr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TeacherRepository tcrRepo = new TeacherRepository();
                    if (tcrRepo.AddTeacherDetails(tcr))
                    {
                        ViewBag.Message = "Teacher Records added succesfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public IActionResult EditTeacherDetails(int id)
        {
            TeacherRepository TcrRepo = new TeacherRepository();
            return View(TcrRepo.GetAllTeachers().Find(tcr => tcr.Id==id));
        }
        [HttpPost]
        public IActionResult EditTeacherDetails(int id, TeacherModel tcr)
        {
            try
            {
                TeacherRepository TcrRepo = new TeacherRepository();
                TcrRepo.UpdatedTeacher(tcr);
                return RedirectToAction("GetAllTcrDetails");
            }
            catch
            {
                return View();
            }

        }
        //Delete Teacher reocords based on Id
        public IActionResult DeleteTeacherDetails(int id)
        {
            try
            {
                TeacherRepository TcrRepo = new TeacherRepository();
                if (TcrRepo.DeleteTeacher(id))
                {
                    ViewBag.AlertMsg ="Teacher Record deleted succesfully";
                }
                return RedirectToAction("GetAllTcrDetails");
            }
            catch
            {
                return View();
            }
        }
    }
}
