using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Authentication servisini JWT Bearer þemasýyla ekliyoruz.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	// JWT Bearer kimlik doðrulama özelliklerini yapýlandýrýyoruz.
	.AddJwtBearer(opt =>
	{
		// HTTPS zorunluluðunu kaldýrýyoruz (geliþtirme ortamý için, prod’da true olmalý)
		opt.RequireHttpsMetadata = false;

		// Token doðrulama parametrelerini belirtiyoruz.
		opt.TokenValidationParameters = new TokenValidationParameters()
		{
			// Token’ýn oluþturulduðu geçerli yayýncý (issuer)
			ValidIssuer = "http://localhost",

			// Token’ýn geçerli olduðu hedef kitle (audience)
			ValidAudience = "http://localhost",
			 

			// Token’ý doðrulamak için kullanýlan gizli anahtar (imza anahtarý)
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi_secret_key_32chars_minimum")),

			// Ýmzanýn doðrulanmasýný zorunlu tutuyoruz
			ValidateIssuerSigningKey = true,
			ValidateLifetime=true  //tokenýn hayatta kalma süresini kontrol et
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
