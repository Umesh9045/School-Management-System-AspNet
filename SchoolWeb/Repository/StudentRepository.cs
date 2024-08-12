using Newtonsoft.Json;
using SchoolWeb.Repository.Interfaces;
using StudentServices.Data.Models;
using System.Security.Policy;
using System.Text;

namespace SchoolWeb.Repository
{
    public class StudentRepository : IStudentRepository
    {
        //API URL
        private readonly string url = "https://localhost:7056/api/Student/";
        private readonly HttpClient client;

        //Constructor
        public StudentRepository(HttpClient client)
        {
            this.client = client;
        }

        //Get all students list
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Student>>(result);
            }
            return new List<Student>();
        }

        //Get details student using roll no
        public async Task<Student> GetStudentByRoll(int roll)
        {
            var response = await client.GetAsync(url + roll);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Student>(result);
            }
            return null;
        }

        //Create new student
        public async Task<HttpResponseMessage> AddStudent(Student student)
        {
            var data = JsonConvert.SerializeObject(student);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            return response;
        }

        //Update details of existing students
        public async Task<HttpResponseMessage> UpdateStudent(Student student)
        {
            var data = JsonConvert.SerializeObject(student);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);
            return response;
        }

        //Delete existing student
        public async Task<HttpResponseMessage> DeleteStudent(int roll)
        {
            var response = await client.DeleteAsync(url + roll);
            return response;
        }
    }
}
