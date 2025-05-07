using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
	public class RoomManager : IRoomService
	{
		private readonly IRoomDal _roomdal;

		public RoomManager(IRoomDal roomdal)
		{
			_roomdal = roomdal;
		}

		public void TDelete(Room t)
		{
			_roomdal.Delete(t);
		}

		public Room TGetByID(int id)
		{
			return _roomdal.GetByID(id);
		}

		public List<Room> TGetList()
		{
			return _roomdal.GetList();
		}

		public void TInsert(Room t)
		{
			_roomdal.Insert(t);
		}

		public void TUpdate(Room t)
		{
			_roomdal.Update(t);
		}
	}
}
