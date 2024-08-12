using System.ComponentModel.DataAnnotations;

namespace FacultyServices.Data.Models
{
    public class Faculty
    {
        [Key]
        public int facultyId { get; set; } 

        public string? name { get; set; }

        public string? profilePicName { get; set; }
    }
}
