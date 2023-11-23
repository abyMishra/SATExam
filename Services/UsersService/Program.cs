using JwtTokenAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UsersService.BusinessLogic;
using UsersService.DataAccess;
using UsersService.Models;
using System.Text;
using CommonLibrary;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin() 
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                      });
});

builder.Services.AddJwtAuthentication();

builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddTransient<ICommonMethods, PasswordBycrpt>();
builder.Services.AddTransient<IUserBusinessLogic, UserBusinessLogic>();
builder.Services.AddSingleton<UserDataAccess>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
