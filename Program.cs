using School_Site.Dal;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("SchoolDbDemo"));
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapControllerRoute(
      name: "adminTexts",
      pattern: "AdminTexts/{action=Index}/{id?}",
      defaults: new { controller = "AdminTexts" }
  );

    // ראוט ברירת מחדל לאתר:
    // / → Home/Index
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    // נתיב פאנל ניהול: /AdminTexts
  

   
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
