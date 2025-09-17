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
public class EfStaffDal : GenericRepository<Staff>, IStaffDal
	{
		
			private readonly Context _context;
		
		public EfStaffDal(Context context) : base(context)
		{
			_context = context;
		}

		
		public int GetStaffCount()
		{
			var values = _context.Staffs.Count();
			return values;
		}

		public List<Staff> Last4Staff()
		{
			var values = _context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList();
			return values;
		}
	}
}
