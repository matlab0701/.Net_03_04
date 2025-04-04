using Domain.Entites;
using Domain.Entities;
using Domain.Responses;
using Infrasturcture.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;
[ApiController]
[Route("api/[controller]")]
public class GroupController(ICourseServer courseServer)
{
        [HttpGet]
    public async Task<Response<List<Course>>> GetAllAsync()
    {
        var courses = courseServer.GetAllAsync();
        return await courses;
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Course>> GetByIdAsync(int id)
    {
        var course = courseServer.GetByIdAsync(id);
        return await course;
    }

    [HttpPost]
    public async Task<Response<Course>> CreateAsync(Course course)
    {
        var result = courseServer.CreateAsync(course);
        return await result;
    }
    [HttpPut]
    public async Task<Response<Course>> UpdateAsync(Course course)
    {
        var result = courseServer.UpdateAsync(course);
        return await result;
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var course = courseServer.DeleteAsync(id);
        return await course;
    }


}
