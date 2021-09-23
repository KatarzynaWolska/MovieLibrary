using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Utils
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
