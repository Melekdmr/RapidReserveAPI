using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	public class EfRoomDal:GenericRepository<Room>,IRoomDal
	{
		private readonly Context _context;
		public EfRoomDal(Context context) :base(context)
		{
			_context = context;

		}

		public int GetRoomCount()
		{
			return _context.Rooms.Count();
		}
	}
}
