using System.Net;
using Domain.Entites;
using Domain.Responses;
using Infrasturcture.Data;
using Infrasturcture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrasturcture.Services;

public class StudentGroupService(DataContext context) : IStudentGroupService
{
    public async Task<Response<StudentGroup>> CreateAsync(StudentGroup studentGroup)
    {
        await context.StudentGroups.AddAsync(studentGroup);
        var res = await context.SaveChangesAsync();
        return res == 0 ?
        new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup doesn`t added")
        : new Response<StudentGroup>(studentGroup);


    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var students = await context.StudentGroups.FindAsync(id);
        if (students == null)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "Id is not found");
        }
        context.Remove(students);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<string>(HttpStatusCode.BadRequest, "StudentGroup doesn`t deleted")
        : new Response<string>("StudentGroup deleted succesfuly");

    }

    public async Task<Response<List<StudentGroup>>> GetAllAsync()
    {
        var result = await context.StudentGroups.ToListAsync();
        return new Response<List<StudentGroup>>(result);
    }

    public async Task<Response<StudentGroup>> GetByIdAsync(int id)
    {
        var result = await context.StudentGroups.FindAsync(id);
        await context.SaveChangesAsync();
        return result == null ?
        new Response<StudentGroup>(HttpStatusCode.BadRequest, "Id is not found")
        : new Response<StudentGroup>(result);


    }

    public async Task<Response<StudentGroup>> UpdateAsync(StudentGroup studentGroup)
    {
        context.StudentGroups.Update(studentGroup);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup doesn`t update")
        : new Response<StudentGroup>(studentGroup);
    }

}
