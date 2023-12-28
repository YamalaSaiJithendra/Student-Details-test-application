using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Practice1.Models;
using Practice1.Repository;

namespace Practice1.Controllers
{
    public class TeacherController : Controller
    {
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
