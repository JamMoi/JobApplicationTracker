using JobApplicationTracker.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);//luo builder-olion, jonka avulla määritämme sovelluksen asetukset ja tarvitsemat palvelut

// Add services to the container.
builder.Services.AddControllersWithViews();

//AddDbContext<ApplicationDbContext> metodi rekisteröi ApplicationDbContext-luokan sovelluksen palveluihin (ASP.NET Coren Dependency Injection -järjestelmään.), jotta sitä voidaan käyttää riippuvuuksien injektoinnissa.
//options.UseSqlServer(...)kertoo EF Corelle:Tämän DbContextin tietokantamoottori on SQL Server.
//builder.Configuration.GetConnectionString("DefaultConnection") hakeek SQL serrverin osoitteen appsetting.json tiedostonsa.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//IsDevelopment() tarkistaa, onko sovellus käynnissä kehitysympäristössä. Tämä lohko suoritetaan vain, kun sovellus ei ole kehitysympäristöss
{
    //UseExceptionHandler() määrittää virheiden käsittelyn ja UseHsts() ohjaa selaimia suosimaan suojattua HTTPS-yhteyttä.
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
