using TodoApiMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//add file TodoContext Model
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//// use View/cshtml
//app.UseHttpsRedirection();
//app.UseStaticFiles();

// use View in root html
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

//run HTTPS
app.UseAuthorization();

// define clearly pathern inside COntroller
app.MapControllers();

//abc.com, catch pathern to get website => use controller and Index method
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=TodoItems}/{action=Index}/{id?}");

app.Run();
