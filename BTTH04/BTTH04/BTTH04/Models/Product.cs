using System.ComponentModel.DataAnnotations.Schema;

namespace BTTH04.Models
{
	public class Product
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public decimal? PriceSale { get; set; }

		public string Description { get; set; }

		public string? Image { get; set; }
		[NotMapped] // Đánh dấu thuộc tính này để nó không được ánh xạ vào cơ sở dữ liệu
		public IFormFile? CoverImage { get; set; }

		public int rating { get; set; }

		public bool isSale { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
	}
}
