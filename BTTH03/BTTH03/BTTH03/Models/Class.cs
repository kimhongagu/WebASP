namespace BTTH03.Models
{
	public class Class
	{
		public int ClassID { get; set; }

		public string? Title { get; set; }

		public ICollection<Student>? Students { get; set; }
	}
}
