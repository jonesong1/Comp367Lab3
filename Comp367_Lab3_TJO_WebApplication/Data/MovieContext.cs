using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Comp367_Lab3_TJO_WebApplication.Models;

namespace Comp367_Lab3_TJO_WebApplication.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Comp367_Lab3_TJO_WebApplication.Models.Movie> Movie { get; set; } = default!;
    }
}
