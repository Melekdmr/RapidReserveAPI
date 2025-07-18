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
builder.Services.AddMvc(config => //config adýnda bir ayar nesnesi veriliyor
{
	var policy = new AuthorizationPolicyBuilder() //yeni bir yetkilendirme politikasý 
	.RequireAuthenticatedUser() //Sadece giriþ yapmýþ kullanýcýlar eriþebilsin
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy)); //Filters kýsmýna ekleyerek, tüm sayfalara bu kuralý otomatik uygulamýþ oluyoruz. Yani her controller ya da action’a tek tek[Authorize] yazmamýza gerek kalmýyor.

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
app.UseAuthentication(); //kim olduðuna bakar
app.UseRouting();

app.UseAuthorization(); //yetki kontrolü

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
