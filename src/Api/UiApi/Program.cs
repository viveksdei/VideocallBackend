using Core.App;
using Core.App.Common.Interfaces;
using Core.App.Common.Services;
using Core.Domain.Common;
using Infrastructure.Persistence;
using Infrastructure.Persistence.EfCoreData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UiApi;
using UiApi.Hub;
using static Core.Domain.Common.EncryptionService;

public class Program
{
    private static int Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var jwtIssuer = builder.Configuration["Jwt:Issuer"];
        var jwtAudience = builder.Configuration["Jwt:Audience"];
        var jwtKey = builder.Configuration["Jwt:Key"];
        // Add services to the container.

      
        builder.Services.AddTransient<IPatients, PatientService>();
        builder.Services.AddTransient<IReadClaimsToken, ReadClaimsToken>();
        builder.Services.Configure<EncryptionSettings>(builder.Configuration.GetSection("EncryptionSettings"));
        builder.Services.AddTransient<EncryptionService>();
        builder.Services.AddUiApiServices();
        builder.Services.AddSignalR(e => { e.EnableDetailedErrors = true; });
        builder.Services.AddApplicationCoreServices();
        builder.Services.AddInfrastructurePersistenceServices(builder.Configuration);
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)


    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer, // Replace with your issuer
            ValidAudience = jwtAudience, // Replace with your audience
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)) // Replace with your secret key
        };
    });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "Your API Title",
                Version = "v2",
                Description = "Your API Description",
                Contact = new OpenApiContact
                {
                    Name = "Your Name",
                    Email = "your.email@example.com",
                }
            });

            // Add a security definition for JWT
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });

            // Add a global JWT requirement for all endpoints
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
        });


        // Customise default API behaviour
        builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddCors(option =>
        {
            option.AddPolicy("AllowAllOrigins", x =>
            {
                x.WithOrigins(new string[] { "http://localhost:4200", "http://localhost:53804", "http://3.131.105.103:8062", "http://3.131.105.103:8061", "https://ms.stagingsdei.com:8062", "https://ms.stagingsdei.com:8061" });
                x.AllowAnyHeader();
                x.AllowAnyMethod();
            });
        });
        // builder.Services.AddCors();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name");
            });
        }

        app.UseCors(x => x.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:4200", "http://localhost:53804", "http://3.131.105.103:8062", "http://3.131.105.103:8061", "https://ms.stagingsdei.com:8062", "https://ms.stagingsdei.com:8061"));
        app.UseCors("AllowAllOrigins");

        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name");
        });
        app.UseCors("AllowAllOrigins");

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        //app.UseEndpoints(endpoints => { HubEndpointConventionBuilder hubEndpointConventionBuilder = endpoints.MapHub<ChatHub>(pattern: "/chathub"); });
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<ChatHub>("/chathub", options =>
            {
                options.Transports =
                    HttpTransportType.WebSockets |
                    HttpTransportType.LongPolling;
            });
        });
        app.Run();

        return 0;
    }
}