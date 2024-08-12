using FacultyServices.Data.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.Repository;
using SchoolWeb.Repository.Interfaces;
using StudentServices.Data.Models;

namespace SchoolWeb.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyRepository facultyRepository;
        private readonly IWebHostEnvironment environment;
        public FacultyController(IFacultyRepository facultyRepository, IWebHostEnvironment environment)
        {
            this.facultyRepository = facultyRepository;
            this.environment = environment;
        }

        //Faculty List Page
        public async Task<IActionResult> Index()
        {
            var faculties = await facultyRepository.GetAllFaculty();
            return View(faculties);
        }

        //Faculty Details page
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var faculty = await facultyRepository.GetFacultyById(id);
            return View(faculty);
        }

        //Create faculty page
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Faculty obj, IFormFile? file)
        {
            //Store the file in database
            string wwwRootPath = environment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string imagePath = wwwRootPath + @"\Images\FacultyProfilePic";
                using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.profilePicName = fileName;
            }

            //Store the faculty details
            HttpResponseMessage response = await facultyRepository.AddFaculty(obj);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        //Edit Faculty details page
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var faculty = await facultyRepository.GetFacultyById(id);
            return View(faculty);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Faculty obj, IFormFile? file)
        {
            //update the file in database
            string wwwRootPath = environment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\FacultyProfilePic");

                if (!string.IsNullOrEmpty(obj.profilePicName))
                {
                    //delete the old image
                    var oldImagePath =
                        Path.Combine(wwwRootPath, obj.profilePicName.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                obj.profilePicName = fileName;
            }
            else
            {
                var old_obj = await facultyRepository.GetFacultyById(obj.facultyId);
                if (old_obj.profilePicName != null)
                {
                    obj.profilePicName = old_obj.profilePicName;
                }
            }
            //Update the faculty details
            HttpResponseMessage response = await facultyRepository.UpdateFaculty(obj);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete Faculty page
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var faculty = await facultyRepository.GetFacultyById(id);
            return View(faculty);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var obj = await facultyRepository.GetFacultyById(id);

            //Delete image from database
            var oldImagePath =
                       Path.Combine(environment.WebRootPath, obj.profilePicName.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            //Delete faculty data 
            HttpResponseMessage response = await facultyRepository.DeleteFaculty(obj.facultyId);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}