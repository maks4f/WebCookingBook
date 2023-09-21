using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebCookingBook.DbContexts;
using WebCookingBook.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddControllers(); // �������� �� MVC
builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseSqlite("Data Source=CookingBookDB.db");
});
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// � ������ ������ .NET core ������������ ������ �������������� �� �� ���� ������

app.UseRouting(); //   �������� �������� ������ ������� �������� �����
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers()); // ��������� ���������� �������� ����� � ��������

// � ����� ������������
//app.MapControllers(); 

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

