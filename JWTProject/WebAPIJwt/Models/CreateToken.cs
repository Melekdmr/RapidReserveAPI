using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebAPIJwt.Models
{
	public class CreateToken
	{
		public string TokenCreate()
		{
		 var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi_secret_key_32chars_minimum");
			SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
			SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: "http://localhost",
				audience: "http://localhost",
				claims: null, // Bu parametreyi ekleyin
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddSeconds(15),
				signingCredentials: signingCredentials
			);
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			 return handler.WriteToken(token);
		}
	}
}
