using API.Data;
using API.Extensions;
using API.InterfaceServices;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddSwagger();

//builder.Services.AddDbContext<DataContext>(opt =>
//{
//    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
//});


//builder.Services.AddSwaggerGen(setup =>
//{
//    // Include 'SecurityScheme' to use JWT Authentication
//    var jwtSecurityScheme = new OpenApiSecurityScheme
//    {
//        BearerFormat = "JWT",
//        Name = "JWT Authentication",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = JwtBearerDefaults.AuthenticationScheme,
//        Description = "Put *_ONLY_* your JWT Bearer token on textbox below!",

//        Reference = new OpenApiReference
//        {
//            Id = JwtBearerDefaults.AuthenticationScheme,
//            Type = ReferenceType.SecurityScheme
//        }
//    };

//    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

//    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        { jwtSecurityScheme, Array.Empty<string>() }
//    });

//});


//builder.Services.AddCors();
//builder.Services.AddScoped<ITokenService, TokenService>();



//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
//            ValidateIssuer = false,
//            ValidateAudience = false
//        };
//    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
