using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Authentication servisini JWT Bearer �emas�yla ekliyoruz.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	// JWT Bearer kimlik do�rulama �zelliklerini yap�land�r�yoruz.
	.AddJwtBearer(opt =>
	{
		// HTTPS zorunlulu�unu kald�r�yoruz (geli�tirme ortam� i�in, prod�da true olmal�)
		opt.RequireHttpsMetadata = false;

		// Token do�rulama parametrelerini belirtiyoruz.
		opt.TokenValidationParameters = new TokenValidationParameters()
		{
			// Token��n olu�turuldu�u ge�erli yay�nc� (issuer)
			ValidIssuer = "http://localhost",

			// Token��n ge�erli oldu�u dinleyici (audience)
			ValidAudience = "http://localhost",
			 

			// Token�� do�rulamak i�in kullan�lan gizli anahtar (imza anahtar�)
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi_secret_key_32chars_minimum")),

			// �mzan�n do�rulanmas�n� zorunlu tutuyoruz
			ValidateIssuerSigningKey = true,
			ValidateLifetime=true, //token�n hayatta kalma s�resini kontrol et
			ClockSkew=TimeSpan.Zero  //Token s�resi doldu�u anda an�nda ge�ersiz olur.


		};
	});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); //	Token kontrol�, kullan�c� do�rulama E�er ge�erliyse, kullan�c� kimli�i olu�turulur.

app.UseAuthorization();//Kullan�c�n�n yetkilerini kontrol etme


app.MapControllers();

app.Run();
