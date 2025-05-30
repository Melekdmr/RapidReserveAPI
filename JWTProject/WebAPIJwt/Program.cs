using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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

			// Token��n ge�erli oldu�u hedef kitle (audience)
			ValidAudience = "http://localhost",
			 

			// Token�� do�rulamak i�in kullan�lan gizli anahtar (imza anahtar�)
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi_secret_key_32chars_minimum")),

			// �mzan�n do�rulanmas�n� zorunlu tutuyoruz
			ValidateIssuerSigningKey = true,
			ValidateLifetime=true  //token�n hayatta kalma s�resini kontrol et
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
app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
