using Domain.Entites;
using Domain.Entities;
using Domain.Responses;
using Infrasturcture.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;
[ApiController]
[Route("api/[controller]")]

public class AddressController(IAddressServer addressServer)
{
        [HttpGet]
    public async Task<Response<List<Address>>> GetAllAsync()
    {
        var addresss = addressServer.GetAllAsync();
        return await addresss;
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Address>> GetByIdAsync(int id)
    {
        var address = addressServer.GetByIdAsync(id);
        return await address;
    }

    [HttpPost]
    public async Task<Response<Address>> CreateAsync(Address address)
    {
        var result = addressServer.CreateAsync(address);
        return await result;
    }
    [HttpPut]
    public async Task<Response<Address>> UpdateAsync(Address address)
    {
        var result = addressServer.UpdateAsync(address);
        return await result;
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var address = addressServer.DeleteAsync(id);
        return await address;
    }

}
