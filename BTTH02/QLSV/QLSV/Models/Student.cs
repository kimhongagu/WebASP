using System.ComponentModel.DataAnnotations;

namespace QLSV.Models
{
    public class Student
    {
        public int Id { get; set; }

        [RegularExpression(@"[A-Z]{3}[0-9]{6}")]
        [Display(Name = "Mã số")]
        [StringLength(9)]
        [Required]
        public string Code { get; set; }

        [Display(Name = "Họ tên")]
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "Email là trường bắt buộc.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }
    }
}
