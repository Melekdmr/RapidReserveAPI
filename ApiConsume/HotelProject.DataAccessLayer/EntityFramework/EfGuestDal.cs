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
	public class EfGuestDal : GenericRepository<Guest>, IGuestDal
	{
		public EfGuestDal(Context context) : base(context)
		/*
		✅ Context context: Entity Framework DbContext nesnesi
		✅ : base(context): Üst sınıfın (GenericRepository) constructor'ına context'i gönderir
		✅ Dependency Injection ile context dışarıdan alınır
		✅ Bu sayede test edilebilir ve gevşek bağlı bir yapı oluşur
		*/
		{
		}
	}
}

