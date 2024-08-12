using System.ComponentModel.DataAnnotations;

namespace StudentServices.Data.Models
{
    public class Student
    {
        [Key]
        public int roll { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int standard { get; set; }
    }
}
