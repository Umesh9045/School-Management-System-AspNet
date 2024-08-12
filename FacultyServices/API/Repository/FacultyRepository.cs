using FacultyServices.Data.Context;
using FacultyServices.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FacultyServices.API.Repository
{
    public class FacultyRepository : IFacultyRepository
    {

        private readonly FacultyDbContext context;

        //constructor
        public FacultyRepository(FacultyDbContext context)
        {
            this.context = context;
        }

        //Get all faculty list
        public Task<List<Faculty>> GetFaculties()
        {
            return context.Faculty.ToListAsync();   
        }

        //Get data by faculty id
        public Task<Faculty> GetFacultyById(int Id)
        {
            return context.Faculty.FindAsync(Id).AsTask();
        }

        //Add new faculty
        public Task AddFaculty(Faculty faculty)
        {
            context.Faculty.Add(faculty);
            context.SaveChanges();
            return Task.CompletedTask;
        }

        //Update faculty
        public Task UpdateFaculty(Faculty faculty)
        {
            context.Entry(faculty).State = EntityState.Modified;
            context.SaveChanges();
            return Task.CompletedTask;
        }

        //Remove Faculty
        public Task RemoveFaculty(Faculty faculty)
        {
            context.Faculty.Remove(faculty);
            context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
