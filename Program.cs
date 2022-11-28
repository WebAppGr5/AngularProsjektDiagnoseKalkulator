using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Repository.implementation;
using obligDiagnoseVerktøyy.Repository.interfaces;
using DiagnoseKalkulatorAngular.data;
using DiagnoseKalkulatorAngular.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data source=diagnoseVerktoy.db"));

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); // optional (clear providers already added)
    logging.AddFile("Logs/diagnoseLog.txt");
});
builder.Services.AddLogging();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllersWithViews();
builder.Services.AddOptions();
builder.Services.AddTransient<IDiagnoseRepository, DiagnoseRepository>();
builder.Services.AddTransient<IDiagnoseGruppeRepository, DiagnoseGruppeRepository>();
builder.Services.AddTransient<ISymptomBildeRepository, SymptomBildeRepository>();
builder.Services.AddTransient<ISymptomGruppeRepository, SymptomGruppeRepository>();
builder.Services.AddTransient<ISymptomRepository, SymptomRepository>();
builder.Services.AddTransient<IBrukerRepository, BrukerRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/build";
});
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".DiagnoseKalkulator.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(1800); // 30 minutter
    options.Cookie.IsEssential = true;
});
builder.Services.AddDistributedMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseCookiePolicy();
var loggerFactory = app.Services.GetService<ILoggerFactory>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Diagnose}/{action=test}/{id?}");
//
app.UseSession();
app.PrepareDatabase()
    .GetAwaiter()
    .GetResult();

app.Run();