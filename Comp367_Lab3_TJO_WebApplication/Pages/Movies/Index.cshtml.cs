using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Comp367_Lab3_TJO_WebApplication.Data;
using Comp367_Lab3_TJO_WebApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            // Adding search feature
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();

            // basic search function
            //var movies = from m in _context.Movie
            //             select m;
            //if (!string.IsNullOrEmpty(SearchString))
            //{
            //    movies = movies.Where(s => s.Title.Contains(SearchString));
            //}

            //Movie = await movies.ToListAsync();
            // without search feature
            //if (_context.Movie != null)
            //{
            //    Movie = await _context.Movie.ToListAsync();
            //}
        }
    }
}
