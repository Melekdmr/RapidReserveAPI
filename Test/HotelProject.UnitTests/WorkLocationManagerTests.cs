using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Moq;
using Xunit;
using System.Collections.Generic;

public class WorkLocationManagerTests
{
	[Fact]
	public void TGetList_ShouldReturnAllWorkLocations()
	{
		// Arrange: Sahte repository
		var mockRepo = new Mock<IWorkLocationDal>();
		mockRepo.Setup(repo => repo.GetList())
			.Returns(new List<WorkLocation>
			{
				new WorkLocation { WorkLocationId = 1, WorkLocationName = "Otel 1", City = "İstanbul" },
				new WorkLocation { WorkLocationId = 2, WorkLocationName = "Otel 2", City = "Ankara" }
			});

		var manager = new WorkLocationManager(mockRepo.Object);

		// Act: Metodu çalıştır
		var result = manager.TGetList();

		// Assert: Beklenen sonucu kontrol et
		Assert.Equal(2, result.Count);
		Assert.Contains(result, x => x.City == "İstanbul");
	}

	[Fact]
	public void TInsert_ShouldCallInsertOnRepository()
	{
		// Arrange
		var mockRepo = new Mock<IWorkLocationDal>();
		var manager = new WorkLocationManager(mockRepo.Object);
		var newLocation = new WorkLocation { WorkLocationId = 3, WorkLocationName = "Otel 3", City = "İzmir" };

		// Act
		manager.TInsert(newLocation);

		// Assert: Repository’nin Insert metodu bir kere çağrılmış mı?
		mockRepo.Verify(r => r.Insert(It.IsAny<WorkLocation>()), Times.Once);
	}

	[Fact]
	public void TDelete_ShouldCallDeleteOnRepository()
	{
		var mockRepo = new Mock<IWorkLocationDal>();
		var manager = new WorkLocationManager(mockRepo.Object);
		var location = new WorkLocation { WorkLocationId = 1 };

		manager.TDelete(location);

		mockRepo.Verify(r => r.Delete(location), Times.Once);
	}

	[Fact]
	public void TUpdate_ShouldCallUpdateOnRepository()
	{
		var mockRepo = new Mock<IWorkLocationDal>();
		var manager = new WorkLocationManager(mockRepo.Object);
		var location = new WorkLocation { WorkLocationId = 1, WorkLocationName = "Otel Güncel", City = "Ankara" };

		manager.TUpdate(location);

		mockRepo.Verify(r => r.Update(location), Times.Once);
	}

	[Fact]
	public void TGetByID_ShouldReturnCorrectWorkLocation()
	{
		var mockRepo = new Mock<IWorkLocationDal>();
		mockRepo.Setup(r => r.GetByID(1))
			.Returns(new WorkLocation { WorkLocationId = 1, WorkLocationName = "Otel 1", City = "İstanbul" });

		var manager = new WorkLocationManager(mockRepo.Object);

		var result = manager.TGetByID(1);

		Assert.NotNull(result);
		Assert.Equal("Otel 1", result.WorkLocationName);
	}
}
