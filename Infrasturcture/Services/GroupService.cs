using System.Net;
using Domain.Entites;
using Domain.Responses;
using Infrasturcture.Data;
using Infrasturcture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrasturcture.Services;

public class GroupService(DataContext context) : IGroupService
{
    public async Task<Response<Group>> CreateAsync(Group group)
    {
        await context.Groups.AddAsync(group);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<Group>(HttpStatusCode.BadRequest, "Something went wrong")
        : new Response<Group>(group);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var res = await context.Groups.FindAsync(id);
        if (res == null)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "Group not found");
        }
        context.Remove(res);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>(HttpStatusCode.BadRequest, "Group not delete")
        : new Response<string>("Group Succesfuly delete");

    }

    public async Task<Response<List<Group>>> GetAllAsync()
    {
        var group = await context.Groups.ToListAsync();
        return new Response<List<Group>>(group);

    }

    public async Task<Response<Group>> GetByIdAsync(int id)
    {
        var group = await context.Groups.FindAsync(id);
        return group == null
        ? new Response<Group>(HttpStatusCode.BadRequest, "Group not found")
        : new Response<Group>(group);

    }

    public async Task<Response<Group>> UpdateAsync(Group group)
    {
        context.Groups.Update(group);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<Group>(HttpStatusCode.BadRequest, "Group doesn`t update")
        : new Response<Group>(group);
    }

}
