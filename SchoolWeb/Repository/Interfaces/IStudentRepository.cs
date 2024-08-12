using StudentServices.Data.Models;

namespace SchoolWeb.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentByRoll(int roll);
        Task<HttpResponseMessage> AddStudent(Student student);
        Task<HttpResponseMessage> UpdateStudent(Student student);
        Task<HttpResponseMessage> DeleteStudent(int roll);
    }
}
