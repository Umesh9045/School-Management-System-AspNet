using FacultyServices.Data.Models;
using StudentServices.Data.Models;

namespace SchoolWeb.Repository.Interfaces
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> GetAllFaculty();

        Task<Faculty> GetFacultyById(int id);

        Task<HttpResponseMessage> AddFaculty(Faculty faculty);

        Task<HttpResponseMessage> UpdateFaculty(Faculty faculty);
        Task<HttpResponseMessage> DeleteFaculty(int id);
    }
}
