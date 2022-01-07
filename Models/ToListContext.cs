using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListApi.Models
{
    public class ToListContext : DbContext
    {
        public ToListContext(DbContextOptions<ToListContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ToList> ToLists { get; set; }
    }
}
