using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
	public class Context:IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=MELEKDMR\\SQLEXPRESS;initial catalog=RapidApiDb;integrated security=true;TrustServerCertificate=true");
		}
		protected override void OnModelCreating(ModelBuilder builder)
		/*
		✅ protected: Bu metot sadece bu class ve türetilen classlar tarafından erişilebilir
		✅ override: DbContext'ten gelen sanal metodu ezip, kendi versiyonumuzu yazıyoruz
		✅ void: Geriye değer döndürmez
		✅ OnModelCreating: EF Core'un veritabanı modeli oluştururken çağırdığı özel metot
		✅ ModelBuilder builder: Veritabanı modelini yapılandırmak için kullanılan nesne
		*/
		//EF Core'a veritabanı modelini nasıl oluşturacağını söyler
		{
			base.OnModelCreating(builder);
			/*
		 ✅ DbContext'in kendi OnModelCreating metodunu çağırır
		 ✅ EF Core'un temel yapılandırmalarını yapar
		 ✅ Bunu çağırmazsak, EF Core'un varsayılan davranışları çalışmaz
		 ✅ MUTLAKA İLK SATIR OLMALI!
		 */

			builder.Entity<Room>(entry =>
			{/*
		 ✅ builder: ModelBuilder nesnesi
     ✅ Entity<Room>: Room sınıfı için yapılandırma başlat
     ✅ entry: Room entity'si için yapılandırma nesnesi (EntityTypeBuilder<Room>)
     ✅ Lambda expression(=>) kullanılarak yapılandırma bloğu açılır*/
				entry.ToTable("Rooms", tb =>
				/*✅ entry.ToTable: Bu entity'nin hangi tabloya karşılık geldiğini belirtir
				✅ "Rooms": Veritabanındaki tablo adı
				✅ tb: Tablo yapılandırma nesnesi(TableBuilder)
				✅ Lambda expression ile tablo - özel yapılandırmalar*/
				{
					tb.HasTrigger("Roomincrease"); // ✅ INSERT tetikleyicisi
					tb.HasTrigger("Roomdecrease");
				});
			});

			builder.Entity<Guest>(entry =>
			{
				entry.ToTable("Guests", tb =>

				{
					tb.HasTrigger("Guestincrease");  
					tb.HasTrigger("Guestdecrease"); 
					
				});
			});
		}

		public DbSet<Room> Rooms { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<Subscribe> Subscribes { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
		public DbSet<About> Abouts { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		
		public DbSet<Guest> Guests { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<SendMessage> SendMessages{ get; set; }
		public DbSet<MessageCategory> MessageCategories{ get; set; }
	}
}
