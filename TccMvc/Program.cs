using Microsoft.EntityFrameworkCore;
using TccMvc.Configuration;
using TccMvc.Context;
using TccMvc.Repository;
using TccMvc.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddHttpContextAccessor();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAutoMapper(typeof(MaperConfig));

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "CategoriaFiltro",
    pattern: "Produto/{action}/{categoria?}",
    defaults: new { controller = "Produto", Action = "List" }
    );

    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "login",
    defaults: new { controller = "ContaUsuario", Action = "Login" },
    pattern: "ContaUsuario/Login");

    endpoints.MapControllerRoute(
    name: "AccessDenied",
    defaults: new { controller = "ContaUsuario", Action = "AccessDenied" },
    pattern: "ContaUsuario/AccessDenied");
});



app.Run();
