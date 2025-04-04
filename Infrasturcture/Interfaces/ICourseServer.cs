using Domain.Entites;
using Domain.Responses;

namespace Infrasturcture.Interfaces;

public interface ICourseServer
{
    Task<Response<List<Course>>> GetAllAsync();
    Task<Response<Course>> GetByIdAsync(int id);
    Task<Response<Course>> CreateAsync(Course course);
    Task<Response<Course>> UpdateAsync(Course course);
    Task<Response<string>> DeleteAsync(int id);
}
