using Microsoft.AspNetCore.Mvc;
using StudentServices.API.Repository;
using StudentServices.Data.Models;

namespace StudentServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        //controller
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;            
        }

        //Get all students list
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await studentRepository.GetStudents();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //Get student by roll no
        [HttpGet("{roll}")]
        public async Task<ActionResult<Student>> GetStudentByRoll(int roll)
        {
            var data = await studentRepository.GetStudentByRoll(roll);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //Create student
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student std)
        {
            var data = studentRepository.AddStudent(std);
            return Ok(std);
        }

        //Update student
        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(Student std)
        {
            studentRepository.UpdateStudent(std);
            return Ok(std);
        }

        //Delete student
        [HttpDelete("{roll}")]
        public async Task<ActionResult<Student>> RemoveStudentByRoll(int roll)
        {
            var data = await studentRepository.GetStudentByRoll(roll);
            if (data == null)
            {
                return NotFound();
            }
            studentRepository.RemoveStudentByRoll(data);
            return Ok();
        }

    }
}
