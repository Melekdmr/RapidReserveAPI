namespace HotelProject.WebUI.Dtos.FollowersDto
{

	public class ResultTwitterFollowersDto
	{

		public class Rootobject
		{
			public bool blue { get; set; }
			public string blueType { get; set; }
			public string created { get; set; }
			public Descriptionlink[] descriptionLinks { get; set; }
			public string displayname { get; set; }
			public int favouritesCount { get; set; }
			public int followersCount { get; set; }
			public int friendsCount { get; set; }
			public int id { get; set; }
			public string id_str { get; set; }
			public int listedCount { get; set; }
			public string location { get; set; }
			public int mediaCount { get; set; }
			public object[] pinnedIds { get; set; }
			public string profileBannerUrl { get; set; }
			public string profileImageUrl { get; set; }
			public object _protected { get; set; }
			public string rawDescription { get; set; }
			public int statusesCount { get; set; }
			public string url { get; set; }
			public string username { get; set; }
			public bool verified { get; set; }
		}

		public class Descriptionlink
		{
			public string tcourl { get; set; }
			public string text { get; set; }
			public string url { get; set; }
		}



	}

}
