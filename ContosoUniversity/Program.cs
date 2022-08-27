// using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Data;


var builder = WebApplication.CreateBuilder(args);
// using ContosoUniversity.Data;
builder.Services.AddDbContext<SchoolContext>(options =>
// using ContosoUniversity.Data;
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();


// builder.Services.AddDbContext<SchoolContext>(options =>
//               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
