using FacultyServices.Data.Models;
using Newtonsoft.Json;
using SchoolWeb.Repository.Interfaces;
using StudentServices.Data.Models;
using System.Text;

namespace SchoolWeb.Repository
{
    public class FacultyRepository : IFacultyRepository
    {
        //API URL
        private readonly string url = "https://localhost:7233/api/Faculty/";
        private readonly HttpClient client;

        //Constructor
        public FacultyRepository(HttpClient client)
        {
            this.client = client;
            
        }

        //Get list of all faculty
        public async Task<IEnumerable<Faculty>> GetAllFaculty()
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Faculty>>(result);
            }
            return new List<Faculty>();
        }

        //get faculty details
        public async Task<Faculty> GetFacultyById(int id)
        {
            var response = await client.GetAsync(url + id);
            if (response.IsSuccessStatusCode) {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Faculty>(result);
            }
            return null;
        }

        //Create new faculty
        public async Task<HttpResponseMessage> AddFaculty(Faculty faculty)
        {
            var data = JsonConvert.SerializeObject(faculty);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateFaculty(Faculty faculty)
        {
            var data = JsonConvert.SerializeObject(faculty);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, content);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteFaculty(int id)
        {
            var response = await client.DeleteAsync(url + id);
            return response;
        }
    }
}
