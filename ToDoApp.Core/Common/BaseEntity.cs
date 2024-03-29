using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Common
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }

	}
}
