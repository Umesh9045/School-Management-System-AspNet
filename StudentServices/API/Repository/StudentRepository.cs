using Microsoft.EntityFrameworkCore;
using StudentServices.Data.Context;
using StudentServices.Data.Models;

namespace StudentServices.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext context;

        //constructor
        public StudentRepository(StudentDbContext context)
        {
            this.context = context; 
        }

        //Get all stuent list
        public Task<List<Student>> GetStudents()
        {
            return context.students.ToListAsync();
        }

        //get student by id
        public Task<Student> GetStudentByRoll(int roll)
        {
            return context.students.FindAsync(roll).AsTask();
        }

        //add new student
        public Task AddStudent(Student std)
        {
            context.students.Add(std);
            context.SaveChanges();
            return Task.CompletedTask;
        }

        //update student details
        public Task UpdateStudent(Student std)
        {
            context.Entry(std).State = EntityState.Modified;
            context.SaveChanges();
            return Task.CompletedTask;
        }

        //Delete student
        public Task RemoveStudentByRoll(Student std)
        {
            context.students.Remove(std);
            context.SaveChanges();
            return Task.CompletedTask;
        }       
    }
}
