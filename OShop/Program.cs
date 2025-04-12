using Microsoft.EntityFrameworkCore;
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

app.Run();
