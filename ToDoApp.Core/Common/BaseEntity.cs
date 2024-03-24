using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Common
{
	public class BaseEntity
	{
		[Required]
		[Key]
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }

	}
}
