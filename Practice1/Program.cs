using Practice1.Repository.Implementation;
using Practice1.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//var ConnectionString = builder.Configuration.GetConnectionString("getconn");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();

var app = builder.Build();

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
    pattern: "{controller=Student}/{action=AddStudentDetails}");
    //pattern: "{controller=Student}/{action=AddTeacherDetails}");

app.Run();
