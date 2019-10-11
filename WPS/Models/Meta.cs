namespace WPS.Models
{
	public class Meta
	{
		public Cursor Cursor { get; set; }
	}

	public class Cursor
	{
		public string Current { get; set; }
		public string Prev { get; set; }
		public string Next { get; set; }
		public int Count { get; set; }
	}
}
