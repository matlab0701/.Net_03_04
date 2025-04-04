using Domain.Responses;

namespace Infrasturcture.Interfaces;

public interface IAddressServer
{
    Task<Response<List<Address>>> GetAllAsync();
    Task<Response<Address>> GetByIdAsync(int id);
    Task<Response<Address>> CreateAsync(Address address);
    Task<Response<Address>> UpdateAsync(Address address);
    Task<Response<string>> DeleteAsync(int id);
}
