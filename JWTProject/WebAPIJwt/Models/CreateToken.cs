using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPIJwt.Models
{
	public class CreateToken
	{
		// Bu metod, JWT (JSON Web Token) oluşturmak için kullanılır.
		// Oluşturulan token, belirli bir süre geçerli olur ve doğrulama için kullanılır.
		public string TokenCreate()
		{
			// Gizli anahtarımızı byte dizisine dönüştürüyoruz.
			// Bu anahtar token'ın imzalanması için gereklidir.
			var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi_secret_key_32chars_minimum");

			// SymmetricSecurityKey sınıfı ile anahtarı simetrik güvenlik anahtarına çeviriyoruz.Aynı anda hem doğrulama ahem imzalama yapar 
			SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

			// İmzalama için kullanılacak algoritmayı ve anahtarı belirtiyoruz.
			SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			// JWT token nesnesi oluşturuluyor.
			JwtSecurityToken token = new JwtSecurityToken(
				issuer: "http://localhost",       // Token'ı oluşturan (yayınlayan) adres
				audience: "http://localhost",     // Token'ın geçerli olduğu hedef kitle
				claims: null,                     // Token içinde taşınacak kullanıcı veya rol bilgileri (şu an boş)
				notBefore: DateTime.Now,          // Token'ın geçerli olmaya başlayacağı zaman
				expires: DateTime.Now.AddSeconds(30), // Token'ın geçerlilik süresi (15 saniye)
				signingCredentials: signingCredentials // Token'ın imzalanması için kullanılan bilgiler
			);

			// Token oluşturma işlemi için handler (yönetici) oluşturuyoruz.
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

			// Token'ı string olarak dışarı döndürüyoruz (JWT formatında).
			return handler.WriteToken(token);
		}
		public string TokenCreateAdmin()
		{
			var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi_secret_key_32chars_minimum");
			SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
			SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Role,"Admin"),
				new Claim(ClaimTypes.Role,"Visitor")
			};

			JwtSecurityToken token=new JwtSecurityToken(
				issuer: "http://localhost",       // Token'ı oluşturan (yayınlayan) adres
				audience: "http://localhost",     // Token'ın geçerli olduğu hedef kitle
			                  
				notBefore: DateTime.Now,          // Token'ın geçerli olmaya başlayacağı zaman
				expires: DateTime.Now.AddSeconds(30), // Token'ın geçerlilik süresi (15 saniye)
				signingCredentials: signingCredentials ,// Token'ın imzalanması için kullanılan bilgiler
				claims: claims                             // Token içinde taşınacak kullanıcı veya rol bilgileri (admin,visitor)
			);
			
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

			
			return handler.WriteToken(token);
		}

	}
	}

