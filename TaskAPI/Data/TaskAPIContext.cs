using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.Data
{
    public class TaskAPIContext : DbContext
    {
        public TaskAPIContext (DbContextOptions<TaskAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TaskAPI.Models.Task> Task { get; set; } = default!;
    }
}
