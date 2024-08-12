using FacultyServices.API.Repository;
using FacultyServices.Data.Context;
using FacultyServices.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : Controller
    {
        private readonly IFacultyRepository facultyRepository;

        //controller
        public FacultyController(IFacultyRepository facultyRepository)
        {
            this.facultyRepository = facultyRepository;
        }

        // GET: FacultyController
        [HttpGet]
        public async Task<ActionResult<List<Faculty>>> GetFaculties()
        {
            var data = await facultyRepository.GetFaculties();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // GET: FacultyController
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<Faculty>>> GetFacultyById(int Id)
        {
            var data = await facultyRepository.GetFacultyById(Id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //Create student
        [HttpPost]
        public async Task<ActionResult<Faculty>> AddStudent(Faculty std)
        {
            var data = facultyRepository.AddFaculty(std);
            return Ok(std);
        }

        //Update Student
        [HttpPut]
        public async Task<ActionResult<Faculty>> UpdateFaculty(Faculty std)
        {
            facultyRepository.UpdateFaculty(std);
            return Ok(std);
        }

        //Delete Student
        [HttpDelete("{id}")]
        public async Task<ActionResult<Faculty>> RemoveFaculty(int id)
        {
            var data = await facultyRepository.GetFacultyById(id);
            if (data == null)
            {
                return NotFound();
            }
            facultyRepository.RemoveFaculty(data);
            return Ok();
        }
    }
}
