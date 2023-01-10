using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using zsoow6TeacherSubjApi.Context;
using zsoow6TeacherSubjApi.Middleware;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Options;
using zsoow6TeacherSubjApi.Policy;
using zsoow6TeacherSubjApi.Services;
using zsoow6TeacherSubjApi.UnitOfWork;
using zsoow6TeacherSubjApi.Middleware;
using zsoow6TeacherSubjApi.Model.Entity;
using zsoow6TeacherSubjApi.Services;
using zsoow6TeacherSubjApi.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISubjectUnitOfWork, SubjectUnitOfWork>();
builder.Services.AddScoped<ICacheService, CacheService>();
//builder.Services.AddScoped<ISignalRNotificationService, SignalRNotificationService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
{
    options.User.RequireUniqueEmail = true;
})
                .AddEntityFrameworkStores<Zsoow6TeacherSubjApiContext>()
                .AddDefaultTokenProviders();

builder.Services.AddSingleton<IAuthorizationHandler, UserAuthorizationHandler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("User", policy =>
    policy.Requirements.Add(new UserPolicy()));
});
builder.Services.AddMemoryCache();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
       // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
}); ;
builder.Services.AddControllers();
// Add swagger api doc configuration and JWT authorization for swagger 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "zsoow6TeacherSubjApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

    });
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
                new string[] {}
            }
        });
});

#region Db

var dbContextOptions = new DBConnectionOption();
builder.Services.Configure<DBConnectionOption>(
    builder.Configuration.GetSection(DBConnectionOption.ConnectionStrings));
builder.Configuration.GetSection(DBConnectionOption.ConnectionStrings).Bind(dbContextOptions);
//Add custom TrainCarAPIDbContext "service" to the container.
builder.Services.AddDbContext<Zsoow6TeacherSubjApiContext>(options =>
{
    var dbBuilder = options.UseSqlServer(dbContextOptions.zsoow6TeacherSubjApiDb);
    if (builder.Environment.IsDevelopment())
    {
        dbBuilder.EnableSensitiveDataLogging();
    }
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseHttpsRedirection();
app.UseStaticFiles();

/// <summary>
/// UseRouting adds route matching to the middleware pipeline. This middleware looks at the set of endpoints defined in the app, and selects the best match based on the request.
/// </summary>
app.UseRouting();

app.UseAuthorization();
app.UseMiddleware<RequestResponseMiddleware>();

app.MapRazorPages();
/// <summary>
/// UseEndpoints adds endpoint execution to the middleware pipeline. It runs the delegate associated with the selected endpoint.
/// </summary>
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseEndpoints(endpoints =>
{
    //endpoints.MapHub<NotificationHub>("/notificationHub");
    endpoints.MapControllers();
});
using (var scope = app.Services.CreateScope())
{
    var cache = scope.ServiceProvider.GetService<ICacheService>();
    if (cache != null)
    {
        cache.SetCache();
    }
}
app.Run();
