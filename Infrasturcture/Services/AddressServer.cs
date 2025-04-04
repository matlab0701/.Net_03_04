using System.Net;
using Domain.Responses;
using Infrastructure.Data;
using Infrasturcture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrasturcture.Services;

public class AddressServer(DataContext context) : IAddressServer
{
    public async Task<Response<Address>> CreateAsync(Address address)
    {
        await context.Addresses.AddAsync(address);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<Address>(HttpStatusCode.BadRequest, "Address not added") :
        new Response<Address>(address);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var address = await context.Addresses.FindAsync(id);
        if (address == null)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "Id is not found");
        }
        context.Remove(address);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>(HttpStatusCode.BadRequest, "Addres doesn`t remove")
        : new Response<string>("Address deleted succesfuly");

    }

    public async Task<Response<List<Address>>> GetAllAsync()
    {
        var result =await  context.Addresses.ToListAsync();
        return new Response<List<Address>>(result);

    }

    public async Task<Response<Address>> GetByIdAsync(int id)
    {
        var result = await context.Addresses.FindAsync(id);
        await context.SaveChangesAsync();
        return result == null
        ? new Response<Address>(HttpStatusCode.BadRequest, "Address is not found")
        : new Response<Address>(result);

    }

    public async Task<Response<Address>> UpdateAsync(Address address)
    {
       context.Addresses.Update(address);
       var result=await context.SaveChangesAsync();
       return result==0?
       new Response<Address>(HttpStatusCode.BadRequest,"Addres doesn`t update")
       :new Response<Address>(address);
    }

}
