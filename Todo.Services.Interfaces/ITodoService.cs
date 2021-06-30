using System;
using System.Collections.Generic;
using Todo.Domain.Core;

namespace Todo.Services.Interfaces
{
    public interface ITodoService
    {
        int GetQuantityCompletedTodos(IEnumerable<TodoModel> todos);
    }
}
