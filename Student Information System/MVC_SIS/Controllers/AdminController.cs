using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            Major major = new Major();
            major.MajorId = MajorRepository.GetAll().Max(m => m.MajorId) + 1;

            return View();
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            MajorRepository.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            StateRepository.Add(state);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult EditState(string id)
        {
            State stateToEdit = StateRepository.GetAll().FirstOrDefault(state => state.StateAbbreviation == id);
            return View(stateToEdit);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            StateRepository.Edit(state);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            return View(StateRepository.GetAll().FirstOrDefault(state => state.StateAbbreviation == id));
        }

        [HttpPost]
        public ActionResult DeleteState(State Delete)
        {
            StateRepository.Delete(Delete.StateAbbreviation);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            return View(CourseRepository.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            Course course = CourseRepository.Get(id);
            return View(course);

        }
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            CourseRepository.Edit(course);
            return RedirectToAction("Courses");
        }
        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {

            return View(CourseRepository.Get(id));
        }
        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            CourseRepository.Add(course.CourseName);
            return Redirect("Courses");
        }

    }
}