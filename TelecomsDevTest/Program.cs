using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using TestDatabase;
using TestRepositories;
using TestServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IQrGeneratorService, QrGeneratorService>();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<RadiusGymContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using (var client = new RadiusGymContext())
    {
        client.Database.EnsureCreated();

        if (!client.MembershipTypes.Any())
        {
            client.MembershipTypes.AddRange(TestDatabaseSqlite.Scaffold.ScaffoldMembershipTypes());
            client.SaveChanges();
        }

        if (!client.Members.Any())
        {           
            client.Members.AddRange(TestDatabaseSqlite.Scaffold.ScaffoldDefaultMembers());
            client.SaveChanges();
        }
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
