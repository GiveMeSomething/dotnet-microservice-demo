using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
	public class Product
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductId { get; set; }

		[Required]
		[StringLength(40)]
		public string ProductName { get; set; }

		[Required]
		public double UnitPrice { get; set; }

		[Required]
		public int Quantity { get; set; }

		public virtual IEnumerable<CartProduct>? CartProducts { get; set; }
	}
}

