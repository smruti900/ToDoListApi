using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Models;

namespace ToDoListApi.Repository
{
    public interface IToListRepository
    {
        Task<ToList> Create(ToList tolist);
        Task<ToList> Get(int id);
        Task<IEnumerable<ToList>> Get();
        Task Delete(int id);
        Task Update(ToList toList);
    }
}
