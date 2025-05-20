using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebAPI.Mapping
{
	public class AutoMapperConfig: Profile //Profile sınıfından kalıtım alıyor. Bu, AutoMapper konfigürasyonu yapmanı sağlıyor. eşleştirme kurallarını barındırır
	{
		public AutoMapperConfig()//Bu sınıfın kurucu metodudur (constructor). Uygulama başlatıldığında çalışır. İçerisinde haritalama kuralları tanımlanır.

		{
			CreateMap<RoomAddDto, Room>();//RoomAddDto → Room sınıfına veri dönüştürmesini tanımlar.
			CreateMap<Room, RoomAddDto>();

			CreateMap<UpdateRoomDto, Room>().ReverseMap(); //.ReverseMap() sayesinde  çift yönlü dönüşüm yapılabilir.

		}
	}
}
