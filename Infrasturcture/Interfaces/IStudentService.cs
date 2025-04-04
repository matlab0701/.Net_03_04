using Domain.Entities;
using Domain.Responses;

namespace Infrasturcture.Interfaces;

public interface IStudentService
{
    Task<Response<List<Student>>> GetAllAsync();
    Task<Response<Student>> GetByIdAsync(int id);
    Task<Response<Student>> CreateAsync(Student student);
    Task<Response<Student>> UpdateAsync(Student student);
    Task<Response<string>> DeleteAsync(int id);
}
