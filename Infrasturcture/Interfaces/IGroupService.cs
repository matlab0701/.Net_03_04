
using Domain.Entites;
using Domain.Responses;

namespace Infrasturcture.Interfaces;

public interface IGroupService
{
    Task<Response<List<Group>>> GetAllAsync();
    Task<Response<Group>> GetByIdAsync(int id);
    Task<Response<Group>> CreateAsync(Group group);
    Task<Response<Group>> UpdateAsync(Group group);
    Task<Response<string>> DeleteAsync(int id);
}
