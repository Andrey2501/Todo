using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Core;
using Todo.Services.Interfaces;

namespace Todo.Infrastructure.Business
{
    public class TodoService: ITodoService
    {
        public int GetQuantityCompletedTodos(IEnumerable<TodoModel> todos)
        {
            return todos.Where(todo => todo.Completed).Count();
        }
    }
}
