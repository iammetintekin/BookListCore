using aspnetcoreapp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoreapp.Controllers
{   

    [Route("/api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public async Task< IActionResult> GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromdb = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if(bookFromdb == null)
            {
                return Json(new { success = false, message="Error while Deleting" });
            }
            _db.Book.Remove(bookFromdb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Succesfull" });
        }
    }
}
