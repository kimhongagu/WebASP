using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLSV.Data;
using QLSV.Models;

namespace QLSV.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new QLSVContext(
            serviceProvider.GetRequiredService<DbContextOptions<QLSVContext>>()))
            {
                // Kiểm tra đã có dữ liệu hay chưa
                if (context.Student.Any())
                {
                    return;
                }
                // Chưa có dữ liệu, chạy data này
                context.Student.AddRange(
                new Student
                {
                    Code = "DPM185156",
                    Name = "Lê Công Hậu",
                    Birth = DateTime.Parse("2000-1-1")
                },
                new Student
                {
                    Code = "DTH185328",
                    Name = "Võ Hồng Ngọc",
                    Birth = DateTime.Parse("2000-12-12")
                },
                new Student
                {
                    Code = "DTH185410",
                    Name = "Lê Trịnh Trọng",
                    Birth = DateTime.Parse("2000-5-19")
                },
                new Student
                {
                    Code = "DPM185453",
                    Name = "Bùi Thị Bích Tuyền",
                    Birth = DateTime.Parse("2000-6-1")
                }
                );
                context.SaveChanges();
            }
        }
    }
}
