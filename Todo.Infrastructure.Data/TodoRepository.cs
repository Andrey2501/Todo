using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Todo.Domain.Core;
using Todo.Domain.Interfaces;

namespace Todo.Infrastructure.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IDbConnection _dbConnection;
        public TodoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<IEnumerable<TodoModel>> SelectAllAsync()
        {
            return _dbConnection.QueryAsync<TodoModel>(@"SELECT * FROM [Todo]");
        }

        public Task<TodoModel> SelectByIdAsync(int id)
        {
            return _dbConnection.QuerySingleOrDefaultAsync<TodoModel>(@"SELECT * FROM [Todo] WHERE [id] = @id", new { id });
        }

        public Task DeleteByIdAsync(int id)
        {
            return _dbConnection.ExecuteAsync(@"DELETE FROM [Todo] WHERE [id] = @id", new { id });
        }

        public Task InsertAsync(TodoCreateModel todoCreateModel)
        {
            return _dbConnection.ExecuteAsync(@"INSERT INTO [Todo] ([title], [description], [completed]) VALUES (@title, @description, @completed)", todoCreateModel);
        }

        public Task UpdateByIdAsync(TodoModel todoModel)
        {
            return _dbConnection.ExecuteAsync(@"UPDATE [Todo] SET [title] = @title, [description] = @description, [completed] = @completed WHERE [id] = @id", todoModel);
        }
    }
}
