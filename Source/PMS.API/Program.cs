using Microsoft.EntityFrameworkCore;
using PMS_API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// adding serilog
var _logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

// builder.Logging.ClearProviders(); //if its enabled console loggings won't work
builder.Logging.AddSerilog(_logger);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "JWTToken_Auth_API", Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
        Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddDbContext<Context>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMailService,MailService>();
builder.Services.AddScoped<IMailDataAccessLayer,MailDataAccessLayer>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IUserData,UserData>();
builder.Services.AddScoped<IProfileData,ProfileData>();

builder.Services.AddScoped<IUserServices,UserServices>();

builder.Services.AddScoped<IProfileService,ProfileService>();
builder.Services.AddScoped<ICollegeServices,CollegeServices>();
builder.Services.AddScoped<IDesignationServices,DesignationServices>();
builder.Services.AddScoped<IDomainServices,DomainServices>();
builder.Services.AddScoped<IProfileStatusServices,ProfileStatusServices>();
builder.Services.AddScoped<ITechnologyServices,TechnologyServices>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata=false;
    options.SaveToken=true;
    options.TokenValidationParameters=new TokenValidationParameters()
    {
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidAudience= builder.Configuration["Jwt:Audience"],
        ValidIssuer=builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
}
);
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddCors((setup) =>

{

    setup.AddPolicy("default", (options) =>

    {

        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

    });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
