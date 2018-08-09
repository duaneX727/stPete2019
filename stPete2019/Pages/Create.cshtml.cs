using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace stPete2019.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        public CreateModel(AppDbContext db) {_db = db;}
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public Member Member { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Members.Add(Member);
            await _db.SaveChangesAsync();
            Message = $"Member: {Member.Name} added succesfully!";
            return RedirectToPage("/Index");
        }
    }
}