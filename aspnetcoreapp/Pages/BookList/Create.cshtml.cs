using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcoreapp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcoreapp.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _db.Book.AddAsync(Book);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("/BookList/Index");
                }
                catch (Exception ex)
                {

                    return Content(ex.Message);
                }
              
            }
            else
            {
                return Page();
            }
        }
    }
}
