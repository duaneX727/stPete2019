using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace stPete2019.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        public EditModel(AppDbContext db){_db = db;}

        [BindProperty]
        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            Member = await _db.Members.FindAsync(Id);
            if (Member == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) { return Page(); }

            _db.Attach(Member).State = EntityState.Modified;

            try
            {
               

                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new Exception($"Member {Member.Id} not found!", e);
            }

            return RedirectToPage("./Index");
        }
    }
}