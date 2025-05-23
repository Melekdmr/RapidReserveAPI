using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
	public class LoginUserDto
	{
		[Required(ErrorMessage ="Kullanıcı adını giriniz")]
		public string UserName{ get; set; }
		[Required(ErrorMessage = "Şifreyi giriniz")]
		public string Password{ get; set; }

	}
}
