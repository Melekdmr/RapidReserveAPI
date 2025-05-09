using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		

			private readonly IRoomService _roomService;

		public RoomController(IRoomService roomService)
		{
			_roomService = roomService;
		}

		[HttpGet]
			public IActionResult RoomList()
			{
				var values = _roomService.TGetList();
				return Ok(values);
			}
			[HttpPost]
			public IActionResult AddRoom(Room p)
			{
				_roomService.TInsert(p);

				return StatusCode(201);
			}

			[HttpDelete]
			public IActionResult DeleteRoom(int id)
			{
				var values = _roomService.TGetByID(id);
				_roomService.TDelete(values);
				return Ok();
			}
			[HttpPut]
			public IActionResult UpdateRoom(Room room)
			{
				_roomService.TUpdate(room);
				return Ok();
			}
			[HttpGet("{id}")]
			public IActionResult GetRoom(int id)
			{
				var values = _roomService.TGetByID(id);
				return Ok(values);
			}
		}
	}


