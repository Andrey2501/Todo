using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Core;

namespace Todo.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoModel>> SelectAllAsync();
        Task DeleteByIdAsync(int id);
        Task InsertAsync(TodoCreateModel todoCreateModel);
        Task UpdateByIdAsync(TodoModel todoModel);
        Task<TodoModel> SelectByIdAsync(int id);
    }
}
