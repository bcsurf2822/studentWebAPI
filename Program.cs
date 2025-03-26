using CollegeApp.Configurations;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

#region Loggin Settings
// builder.Logging.ClearProviders();
// builder.Logging.AddConsole();
// builder.Logging.AddDebug(); //Built in Loggers
#endregion
#region SeriLog Settings
// Log.Logger = new LoggerConfiguration().
// MinimumLevel.Information()
//     .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute)
//     .CreateLogger();

//builder.Host.UserSerilog();  Overrides built in Loggers
// builder.Logging.AddSerilog(); //Logging vs Services will do default loggin as well
#endregion


// ✅ Read the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ✅ Register your DbContext with the SQLite provider
builder.Services.AddDbContext<CollegeDBContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped(typeof(ICollegeRepository<>), typeof(CollegeRepository<>));//Generic types for dep injection
// builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy =>
// {
//     //Allow ALL origins
//     // policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
// }
// ));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});
    options.AddPolicy("AllowOnlyLocalHost", policy =>
    {
        //     //Allow ALL origins
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
    options.AddPolicy("AllowOnlyLocalHost", policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    }
    );
    options.AddPolicy("OnlyGoogle", policy =>
{
    policy.WithOrigins("http://google.com, gmail.com, drive.google").AllowAnyHeader().AllowAnyMethod();
});
});
// Add services to the containers
builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); //Allows JSON and XML


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddTransient<IMyLogger, LogToServerMemory>();
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(); //Default
// app.UseCors("MyTestCORS"); //Before authrizationand after routing (we can only name 1 at a time)
app.UseAuthorization();
app.MapControllers(); // Enables controller routing like [Route("api/[controller]")]
app.Run();