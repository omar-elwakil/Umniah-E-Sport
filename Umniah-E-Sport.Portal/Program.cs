using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Globalization;
using UI.Helper.Managers;
using UI.Helper.Managers.Portal;
using Umniah_E_Sport.Portal.ActionFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UserAuthenticationFilter>();
builder.Services.AddScoped<UserMailAuthenticationFilter>();
builder.Services.AddScoped<SubscriperAuthenticationFilter>();
builder.Services.AddHttpClient<SmartLinkApiClient>();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICookieManager, CookieManager>();
builder.Services.AddScoped<IUserManagerCookie, UserManagerCookie>();

builder.Services.AddSession();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization()
    .AddRazorRuntimeCompilation();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var cultures = new List<CultureInfo> {
                    new CultureInfo("en"),
                    new CultureInfo("ar")
                };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ar");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();
var options = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(options.Value);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"C:\inetpub\wwwroot\Content\Umniah-E-Sport")),
//    RequestPath = new PathString("/Path")
//});
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
