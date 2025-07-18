using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using NuGet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// FluentValidation konfig�rasyonu
builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true; // �nemli: DataAnnotations'� kapat (required gibi) aksi halde fluent validation �al��maz mesjalar g�r�nmez
});
builder.Services.AddFluentValidationClientsideAdapters();//Formda kullan�c� yazmaya ba�lad���nda an�nda validation yapar
//Sayfa yenilenmeden hata mesajlar� g�sterir

// Validator'� kaydet
builder.Services.AddScoped<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddScoped<IValidator<UpdateGuestDto>, UpdateGuestValidator>();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddHttpClient(); //UI katman�nda API'ye istek g�ndermek i�in HttpClient kullan�l�r. Bu servis, d�� API'lere HTTP istekleri yapman�z� sa�lar.

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMvc(config => //config ad�nda bir ayar nesnesi veriliyor
{
	var policy = new AuthorizationPolicyBuilder() //yeni bir yetkilendirme politikas� 
	.RequireAuthenticatedUser() //Sadece giri� yapm�� kullan�c�lar eri�ebilsin
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy)); //Filters k�sm�na ekleyerek, t�m sayfalara bu kural� otomatik uygulam�� oluyoruz. Yani her controller ya da action�a tek tek[Authorize] yazmam�za gerek kalm�yor.

});
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
app.UseAuthentication(); //kim oldu�una bakar
app.UseRouting();

app.UseAuthorization(); //yetki kontrol�

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
