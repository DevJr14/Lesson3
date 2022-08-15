using Common.Models;

namespace UI.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllAsync();
        Task AddNewAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Student student);
        Task<Student> GetByIdAsync(int id);
    }
}
