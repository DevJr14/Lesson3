using Common.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UI.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddNewAsync(Student student)
        {
            await _httpClient.PostAsJsonAsync("api/students/add-new", student);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync("api/students/delete/" + id);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<List<Student>>("api/students/all");

            if (data != null)
            {
                return data;
            }
            return new List<Student>();

            #region Alternative
            //var response = await _httpClient.GetAsync("api/students/all");
            //var responseAsString = await response.Content.ReadAsStringAsync();

            //var responseObject = JsonSerializer.Deserialize<List<Student>>(responseAsString, new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true,
            //    ReferenceHandler = ReferenceHandler.Preserve
            //});

            //if (responseObject != null)
            //{
            //    return responseObject;
            //}
            //return new List<Student>();
            #endregion
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Student student)
        {
            await _httpClient.PutAsJsonAsync("api/students/update", student);
        }
    }
}
