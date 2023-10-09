using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BTTH03.Models;

    public class BTTH03Context : DbContext
    {
        public BTTH03Context (DbContextOptions<BTTH03Context> options)
            : base(options)
        {
        }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Class>().ToTable("Class");
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Course>().ToTable("Course");
        modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
	}

	public DbSet<BTTH03.Models.Class> Class { get; set; } = default!;

        public DbSet<BTTH03.Models.Course> Course { get; set; } = default!;

        public DbSet<BTTH03.Models.Enrollment> Enrollment { get; set; } = default!;

        public DbSet<BTTH03.Models.Student> Student { get; set; } = default!;
    }
