using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
	public class CartProduct
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int CartId { get; set; }
		public Cart Cart { get; set; }

		public int ProductId { get; set; }
		public Product Product { get; set; }
	}
}

