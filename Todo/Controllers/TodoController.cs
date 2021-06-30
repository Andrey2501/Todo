using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Core;
using Todo.Domain.Interfaces;
using Todo.Services.Interfaces;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ITodoService _todoService;

        public TodoController(ITodoRepository todoRepository, ITodoService todoService)
        {
            _todoRepository = todoRepository;
            _todoService = todoService;
        }

        [HttpGet, Route("list")]
        public async Task<IActionResult> GetListAsync()
        {
            return Ok(await _todoRepository.SelectAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _todoRepository.SelectByIdAsync(id));
        }

        [HttpGet, Route("completed/list")]
        public async Task<IActionResult> GetCompletedListAsync()
        {
            IEnumerable<TodoModel> todos = await _todoRepository.SelectAllAsync();
            int quantity = _todoService.GetQuantityCompletedTodos(todos);

            return Ok(quantity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateByIdAsync([FromBody] TodoModel todoModel)
        {
            await _todoRepository.UpdateByIdAsync(todoModel);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] TodoCreateModel todoCreateModel)
        {
            await _todoRepository.InsertAsync(todoCreateModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            await _todoRepository.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
