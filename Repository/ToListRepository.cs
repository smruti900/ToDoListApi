using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Models;

namespace ToDoListApi.Repository
{
    public class ToListRepository : IToListRepository
    {
        private readonly ToListContext _context;
        public ToListRepository(ToListContext context)
        {
            this._context = context;
        }
        public async Task<ToList> Create(ToList tolist)
        {
            _context.ToLists.Add(tolist);
            await _context.SaveChangesAsync();
            return tolist;
        }

        public async Task Delete(int id)
        {
            var tolistdelete = await _context.ToLists.FindAsync(id);
            _context.ToLists.Remove(tolistdelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ToList> Get(int id)
        {
            return await _context.ToLists.FindAsync(id);
        }

        public async Task<IEnumerable<ToList>> Get()
        {
            return await _context.ToLists.ToListAsync();
        }

        public async Task Update(ToList toList)
        {
            _context.Entry(toList).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
