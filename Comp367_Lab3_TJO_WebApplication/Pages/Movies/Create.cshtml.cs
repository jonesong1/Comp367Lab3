using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Comp367_Lab3_TJO_WebApplication.Data;
using Comp367_Lab3_TJO_WebApplication.Models;

namespace Comp367_Lab3_TJO_WebApplication.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly Comp367_Lab3_TJO_WebApplication.Data.MovieContext _context;

        public CreateModel(Comp367_Lab3_TJO_WebApplication.Data.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
