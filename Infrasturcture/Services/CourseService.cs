using System.Net;
using Domain.Entites;
using Domain.Responses;
using Infrasturcture.Data;
using Infrasturcture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrasturcture.Services;

public class CourseService(DataContext context) : ICourseServer
{
    public async Task<Response<Course>> CreateAsync(Course course)
    {
        await context.Courses.AddAsync(course);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<Course>(HttpStatusCode.BadRequest, "Course not created")
        : new Response<Course>(course);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var courses = await context.Courses.FindAsync(id);
        if (courses == null)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "Course not found");
        }
        context.Remove(courses);
        var res = await context.SaveChangesAsync();
        return res == 0 ?
        new Response<string>(HttpStatusCode.BadRequest, "Course doesn`t deleted")
        : new Response<string>("Course deleted succesfuly ");
    }

    public async Task<Response<List<Course>>> GetAllAsync()
    {
        var result = await context.Courses.ToListAsync();
        return new Response<List<Course>>(result);

    }

    public async Task<Response<Course>> GetByIdAsync(int id)
    {
        var res = await context.Courses.FindAsync(id);
        await context.SaveChangesAsync();
        return res == null
        ? new Response<Course>(HttpStatusCode.BadRequest, "Id is not found")
        : new Response<Course>(res);
    }

    public async Task<Response<Course>> UpdateAsync(Course course)
    {
        context.Courses.Update(course);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<Course>(HttpStatusCode.BadRequest, "Course is not updated")
        : new Response<Course>(course);
    }

}
