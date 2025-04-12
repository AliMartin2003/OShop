using Microsoft.EntityFrameworkCore;
using OShop.Core.Interfaces;
using OShop.Core.Services;
using OShop.DataLayer.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OShopContext>(options =>
options.UseSqlServer("server=.;" +
    "DataBase=OShopDb;" +
    "Initial Catalog=OShopDb;" +
    "Integrated Security=True;" +
    "MultipleActiveResultSets=True;")
);


builder.Services.AddScoped<IProductGroup, ProductGroupServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
