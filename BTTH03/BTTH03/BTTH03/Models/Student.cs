﻿namespace BTTH03.Models
{
	public class Student
	{
		public int StudentID { get; set; }

		public string Code { get; set; }

		public string Name { get; set; }

		public DateTime Birth { get; set; }

		public string Email { get; set; }

		public int ClassID { get; set; }

		public Class? Class { get; set; }

		public ICollection<Enrollment>? Enrollments { get; set; }
	}
}
