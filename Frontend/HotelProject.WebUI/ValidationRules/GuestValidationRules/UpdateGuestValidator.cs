using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
	public class UpdateGuestValidator:AbstractValidator<UpdateGuestDto> 
	{
		public UpdateGuestValidator()
		{

			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
			RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
			RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez");
			RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karakter girmelisiniz");
			RuleFor(x => x.SurName).MinimumLength(3).WithMessage("En az 3 karakter girmelisiniz");
			RuleFor(x => x.City).MinimumLength(3).WithMessage("En az 3 karakter girmelisiniz");
			RuleFor(x => x.Name).MaximumLength(15).WithMessage("En fazla 15 karakter girmelisiniz");
			RuleFor(x => x.SurName).MaximumLength(15).WithMessage("En fazla 15 karakter girmelisiniz");
			RuleFor(x => x.City).MaximumLength(20).WithMessage("En fazla 20 karakter girmelisiniz");

		}
	}
}
