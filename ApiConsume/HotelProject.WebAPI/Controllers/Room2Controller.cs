using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Room2Controller : ControllerBase
	{
		private readonly IRoomService _roomService;

		private readonly IMapper _mapper;

		public Room2Controller(IRoomService roomService, IMapper mapper)
		{
			_roomService = roomService;  //Burada _roomService alanı sayesinde, servis katmanındaki metotları çağırabiliyorsun.
										 // Gelen roomService'i _roomService alanına atayarak sınıf içinde kullanılabilir hale getiriyoruz.
			_mapper = mapper; // burada mapper null olmaktan çıkar
		}

		/*public Room2Controller(IMapper mapper)
		{
			_mapper = mapper;
		}*/

		[HttpGet]
		public IActionResult Index()
		{
			var values = _roomService.TGetList();
			return Ok(values);

		}
		[HttpPost]
		public IActionResult AddRoom(RoomAddDto roomAddDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var values = _mapper.Map<Room>(roomAddDto);
			_roomService.TInsert(values);

			return Ok();

		}
		[HttpPut]
		public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var values = _mapper.Map<Room>(updateRoomDto);
			_roomService.TUpdate(values);

			return Ok();
		}
	}
}