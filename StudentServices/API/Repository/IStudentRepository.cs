using StudentServices.Data.Models;

namespace StudentServices.API.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentByRoll(int roll);
        Task AddStudent(Student std);
        Task UpdateStudent(Student std);
        Task RemoveStudentByRoll(Student std);
    }
}
