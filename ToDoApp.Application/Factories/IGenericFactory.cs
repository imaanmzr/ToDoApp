using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Factories
{
	public interface IGenericFactory<T>
	{
		T CreateNewUserTask(int id, string title, string description, DateTime dueDate, DateTime dateModified, bool isCompleted);
	}
}
