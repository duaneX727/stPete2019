using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace stPete2019.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        [TempData]
        public string Message { get; set; }
        public IList<Member> Members { get; private set; }
        public async Task OnGetAsync()
        {
            Members = await _db.Members.AsNoTracking().ToListAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var member = await _db.Members.FindAsync(id);

            if(member != null)
            {
                _db.Members.Remove(member);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
