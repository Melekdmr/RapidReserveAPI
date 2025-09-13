using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
	public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
	{
		private readonly Context _context;
		/*Context: EF Core’un veritabanı bağlantısını yöneten sınıf.

         Dependency Injection (DI) ile dışarıdan Context alınıyor.

         base(context): GenericRepository’nin constructor’ına context gönderiliyor, 
		yani temel CRUD işlemleri için de aynı context kullanılabiliyor.

        _context = context;: Bu sınıfta kullanılmak üzere context saklanıyor.*/
		public EfAppUserDal(Context context) : base(context)
		{
			_context = context;
		}
		public List<AppUser> UserListWithWorkLocation()
		{
			return _context.Users.Include(x => x.WorkLocation).ToList(); /*Kullanıcıların bağlı olduğu WorkLocation tablosunu da sorguya dahil et (Eager Loading).*/
		}
	}
}
