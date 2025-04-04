using Domain.Entites;
using Domain.Responses;
using Infrasturcture.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;
[ApiController]
[Route("api/[controller]")]
public class StudentGroupController(IStudentGroupService studentGroupService)
{
        [HttpGet]
    public async Task<Response<List<StudentGroup>>> GetAllAsync()
    {
        var studentGroups = studentGroupService.GetAllAsync();
        return await studentGroups;
    }
    [HttpGet("{id:int}")]
    public async Task<Response<StudentGroup>> GetByIdAsync(int id)
    {
        var studentGroup = studentGroupService.GetByIdAsync(id);
        return await studentGroup;
    }

    [HttpPost]
    public async Task<Response<StudentGroup>> CreateAsync(StudentGroup studentGroup)
    {
        var result = studentGroupService.CreateAsync(studentGroup);
        return await result;
    }
    [HttpPut]
    public async Task<Response<StudentGroup>> UpdateAsync(StudentGroup studentGroup)
    {
        var result = studentGroupService.UpdateAsync(studentGroup);
        return await result;
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var studentGroup = studentGroupService.DeleteAsync(id);
        return await studentGroup;
    }

}
