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
    public class DetailsModel : PageModel
    {
        private readonly Comp367_Lab3_TJO_WebApplication.Data.MovieContext _context;

        public DetailsModel(Comp367_Lab3_TJO_WebApplication.Data.MovieContext context)
        {
            _context = context;
        }

      public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
