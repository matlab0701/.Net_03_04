using Infrasturcture.Data;
using Infrasturcture.Interfaces;
using Infrasturcture.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentGroupService, StudentGroupService>();
builder.Services.AddScoped<ICourseServer, CourseService>();
builder.Services.AddScoped<IAddressServer, AddressServer>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddDbContext<DataContext>(t => t.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebApi"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();


