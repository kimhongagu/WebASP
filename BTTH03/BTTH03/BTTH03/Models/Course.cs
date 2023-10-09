namespace BTTH03.Models
{
	public class Course
	{
		public int CourseID { get; set; }

		public string Code { get; set; }

		public string Title { get; set; }

		public int Credits { get; set; }

		public ICollection<Enrollment>? Enrollments { get; set; }
	}
}
