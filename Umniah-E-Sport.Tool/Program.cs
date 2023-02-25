using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.FileProviders;
using Umniah_E_Sport.Tool.Managers.Upload;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IUploadFileManager, UploadFileManager>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddMvcOptions(options => options.Filters.Add(new AuthorizeFilter()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"C:\\inetpub\\wwwroot\\Content\\Zain-E-Sport\\")),
//    RequestPath = new PathString("/Path")
//});
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
