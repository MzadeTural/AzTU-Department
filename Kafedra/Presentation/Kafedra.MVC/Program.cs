
using Kafedra.Domain.Entities;
using Kafedra.Application;
using Kafedra.Domain.Enums;
using Kafedra.Infrastructure;
using Kafedra.Persistence;
using Kafedra.Persistence.Concretes.Services;
using Kafedra.Application.MappingProfile;

using Kafedra.Business;
using Kafedra.Infrastructure.Hubs;
using Kafedra.Application.Interfaces.Services.Interfaces;
using Kafedra.Application.Interfaces.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LayoutServices>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(typeof(EventMapper));
builder.Services.AddBusinessServices();
builder.Services.AddStorageType(StorageType.ILocalStorage);
builder.Services.AddSignalR();
builder.Services.AddScoped<IFileService, FileService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<SearchHub>("/searchHub"); // Map the hub endpoint
    endpoints.MapHub<ChangeStatusHub>("/statusHub");
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();