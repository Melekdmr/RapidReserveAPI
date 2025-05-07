using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
	public class SubscribeManager : ISubscribeDal
	{
		private readonly ISubscribeDal _subscribeDal;
		public void Delete(Subscribe t)
		{
			_subscribeDal.Delete(t);
		}

		public Subscribe GetByID(int id)
		{
			return _subscribeDal.GetByID(id);
		}

		public List<Subscribe> GetList()
		{
			return _subscribeDal.GetList();
		}

		public void Insert(Subscribe t)
		{
			_subscribeDal.Insert(t);
		}

		public void Update(Subscribe t)
		{
			_subscribeDal.Update(t);
		}
	}
}
