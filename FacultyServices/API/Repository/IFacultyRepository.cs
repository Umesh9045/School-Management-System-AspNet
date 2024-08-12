using FacultyServices.Data.Models;

namespace FacultyServices.API.Repository
{
    public interface IFacultyRepository
    {
        Task<List<Faculty>> GetFaculties();

        Task<Faculty> GetFacultyById(int Id);

        Task AddFaculty(Faculty faculty);

        Task UpdateFaculty(Faculty faculty);

        Task RemoveFaculty(Faculty faculty);
    }
}
