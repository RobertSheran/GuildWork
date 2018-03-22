using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            return View(StudentRepository.Get(id));
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var model = StudentRepository.Get(id);
            StudentVM student = new StudentVM();
            student.SetCourseItems(CourseRepository.GetAll());
            student.SetMajorItems(MajorRepository.GetAll());
            student.SetStateItems(StateRepository.GetAll());
            student.Student = model;
            student.Student.Address = model.Address;
            student.SelectedCourseIds = model.Courses.Select(m => m.CourseId).ToList();      

            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM viewModel)
        {
            viewModel.Student.Courses = CourseRepository.Get( viewModel.SelectedCourseIds);
            viewModel.Student.Major = MajorRepository.Get(viewModel.Student.Major.MajorId);
            viewModel.Student.Address.State = StateRepository.Get(viewModel.Student.Address.State.StateAbbreviation);
            StudentRepository.Edit(viewModel.Student);
            return RedirectToAction("List");
        }
    }
}