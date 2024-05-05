
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineTutorManagementSystem_Infra.Repos;
using OnlineTutorManagementSystem_Infra.Service;
using OnlineTutorManagmentSystem_Core.Context;
using OnlineTutorManagmentSystem_Core.IRepos;
using OnlineTutorManagmentSystem_Core.IService;
using Serilog;
using Serilog.Formatting.Json;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddAuthentication(cfg => {
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes("OnlineTutorManagementSystemBayanQuraan1999")
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings
.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Online Tutor Managment System API ",
        Version = "v1",
        Description = "An API to perform Online Tutor Managment System operations",
        Contact = new OpenApiContact
        {
            Name = "Bayan Al-Qura'an",
            Email = "bayanquraan332@gmail.com",
        },
        License = new OpenApiLicense
        {
            Name = "Online Tutor Managment System API LICX",
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddDbContext<OnlineTutorManagementSystemDbContext>(cop =>
cop.UseSqlServer(builder.Configuration.GetValue<string>("sqlconnect")));
builder.Services.AddScoped<ITeacherReposeInterface, TeacherRepos>();
builder.Services.AddScoped<IStudentReposeInterface, StudentRepos>();
builder.Services.AddScoped<IStudentServiceInterface, StudentService>();
builder.Services.AddScoped<ITeacherServiceInterface, TeacherService>();
//Serilog Config
Log.Logger = new LoggerConfiguration()
   .WriteTo.Console(new JsonFormatter())
   .WriteTo.File(new JsonFormatter(), "logs\\log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
   .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Tutor Managment System API V1");
    });
}
Log.Information("Application Has been Started");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
