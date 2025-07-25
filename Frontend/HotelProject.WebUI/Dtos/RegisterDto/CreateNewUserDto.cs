﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
	public class CreateNewUserDto
	{
		[Required(ErrorMessage = "Ad alanı gereklidir")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Soyad alanı gereklidir")]
		public string SurName { get; set; }

		[Required(ErrorMessage = "Kullanıcı adı alanı gereklidir")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Mail alanı gereklidir")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Şifre alanı gereklidir")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Şifre Tekrar alanı gereklidir")]
		[Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
		public string ConfirmPassword { get; set; }
	}
}

