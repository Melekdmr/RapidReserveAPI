using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// FluentValidation konfigürasyonu
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true; // Önemli: DataAnnotations'ý kapat (required gibi) aksi halde fluent validation çalýþmaz mesjalar görünmez
});
builder.Services.AddFluentValidationClientsideAdapters();//Formda kullanýcý yazmaya baþladýðýnda anýnda validation yapar
//Sayfa yenilenmeden hata mesajlarý gösterir

// Validator'ý kaydet
builder.Services.AddScoped<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddScoped<IValidator<UpdateGuestDto>, UpdateGuestValidator>();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddHttpClient(); //UI katmanýnda API'ye istek göndermek için HttpClient kullanýlýr. Bu servis, dýþ API'lere HTTP istekleri yapmanýzý saðlar.

builder.Services.AddAutoMapper(typeof(Program));
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
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
