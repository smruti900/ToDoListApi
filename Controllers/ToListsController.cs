using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Models;
using ToDoListApi.Repository;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToListsController : ControllerBase
    {
        private readonly IToListRepository _tolistRepository;

        public ToListsController(IToListRepository tolistRepository)
        {
            _tolistRepository = tolistRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ToList>> GetToLists()
        {
            return await _tolistRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToList>> GetToLists(int id)
        {
            return await _tolistRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<ToList>> PostToLists([FromBody] ToList toList)
        {
            var newlist = await _tolistRepository.Create(toList);
            return CreatedAtAction(nameof(GetToLists), new { id = newlist.Id },newlist);
        }
    }
}
