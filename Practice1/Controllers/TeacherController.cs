using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Practice1.Models;
using Practice1.Repository.Implementation;
using Practice1.Repository.Interfaces;

namespace Practice1.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        //Get all teachers
        //[HttpGet("GetAllTcrDetails")]
        [HttpGet]
        public IActionResult GetAllTcrDetails()
        {
          //  TeacherRepository TcrRepo = new TeacherRepository();
            ModelState.Clear();
            return View(_teacherRepository.GetAllTeachers());
        }
        //GET : Get Teacher details
        public IActionResult AddTeacherDetails()
        {
            return View();
        }

        // This is for Redirecting to teacher controller
        public IActionResult RedirectionMethod()
        {
            return this.RedirectToAction("GetAllStdDetails", "Student");
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
        //[HttpPost("EditTeacherDetails")]
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
        //[HttpDelete("DeleteTeacherDetails")]
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
