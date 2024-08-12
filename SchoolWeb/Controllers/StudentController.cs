using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Core.Types;
using SchoolWeb.Repository.Interfaces;
using StudentServices.Data.Models;

namespace SchoolWeb.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        //Constructor
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        //Index/Home Page 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Get all students list
            var students = await studentRepository.GetAllStudents();
            return View(students);
        }

        //Student Details page
        [HttpGet]
        public async Task<IActionResult> Details(int roll)
        {
            var student = await studentRepository.GetStudentByRoll(roll);
            return View(student);
        }

        //Create student page
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            HttpResponseMessage response = await studentRepository.AddStudent(std);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Edit Student details page
        [HttpGet]
        public async Task<IActionResult> Edit(int roll)
        {
            var student = await studentRepository.GetStudentByRoll(roll);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student std)
        {
            HttpResponseMessage response = await studentRepository.UpdateStudent(std);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        //Delete student page
        [HttpGet]
        public async Task<IActionResult> Delete(int roll)
        {
            var student = await studentRepository.GetStudentByRoll(roll);

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(Student std)
        {
            HttpResponseMessage response = await studentRepository.DeleteStudent(std.roll);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}
