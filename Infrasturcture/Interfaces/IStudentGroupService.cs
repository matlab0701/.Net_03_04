using Domain.Entites;
using Domain.Responses;

namespace Infrasturcture.Interfaces;

public interface IStudentGroupService
{
  
    Task<Response<List<StudentGroup>>> GetAllAsync();
    Task<Response<StudentGroup>> GetByIdAsync(int id);
    Task<Response<StudentGroup>> CreateAsync(StudentGroup studentGroup);
    Task<Response<StudentGroup>> UpdateAsync(StudentGroup studentGroup);
    Task<Response<string>> DeleteAsync(int id);
}
