﻿namespace HotelProject.WebUI.Dtos.BookingDto
{
	public class CreateBookingDto
	{
		public int BookingID { get; set; }
		public string Name { get; set; }
		public string Mail { get; set; }
		public DateTime Checkin { get; set; }
		public DateTime CheckOut { get; set; }
		public string AdultCount { get; set; }
		public string ChildCount { get; set; }
		public string RoomCount { get; set; }
		public string? SpecialRequest { get; set; }
		public string Descriptiont { get; set; }
		public string Status { get; set; }
	}
}
