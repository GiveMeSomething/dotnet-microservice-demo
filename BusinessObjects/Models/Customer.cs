using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
	public class Customer
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[StringLength(40)]
		public string CustomerName { get; set; }

        [Required]
        [StringLength(40)]
        public string Address { get; set; }

        public Cart? Cart { get; set; }
	}
}

