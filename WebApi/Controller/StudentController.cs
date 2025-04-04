using Domain.Entities;
using Domain.Responses;
using Infrasturcture.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controller;
[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService studentService)
{
    [HttpGet]
    public async Task<Response<List<Student>>> GetAllAsync()
    {
        var students = studentService.GetAllAsync();
        return await students;
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Student>> GetByIdAsync(int id)
    {
        var student = studentService.GetByIdAsync(id);
        return await student;
    }

    [HttpPost]
    public async Task<Response<Student>> CreateAsync(Student student)
    {
        var result = studentService.CreateAsync(student);
        return await result;
    }
    [HttpPut]
    public async Task<Response<Student>> UpdateAsync(Student student)
    {
        var result = studentService.UpdateAsync(student);
        return await result;
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var student = studentService.DeleteAsync(id);
        return await student;
    }


}
