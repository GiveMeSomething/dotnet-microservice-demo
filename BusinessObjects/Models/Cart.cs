using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
	public class Cart
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CartId { get; set; }

		[Required]
		public int CustomerId { get; set; }
		public Customer Customer { get; set; }

        public IEnumerable<CartProduct> CartProducts { get; set; }
    }
}

