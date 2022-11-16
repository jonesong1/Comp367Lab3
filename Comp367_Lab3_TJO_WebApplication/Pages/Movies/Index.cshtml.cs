using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Comp367_Lab3_TJO_WebApplication.Data;
using Comp367_Lab3_TJO_WebApplication.Models;

namespace Comp367_Lab3_TJO_WebApplication.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Comp367_Lab3_TJO_WebApplication.Data.MovieContext _context;

        public IndexModel(Comp367_Lab3_TJO_WebApplication.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
