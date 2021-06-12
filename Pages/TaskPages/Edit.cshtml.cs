using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogicalProgramming.Models;

namespace LogicalProgramming.Pages.TaskPages
{
    public class EditModel : PageModel
    {
        private readonly LogicalProgramming.Models.aspnetLogicalProgrammingContext _context;

        public EditModel(LogicalProgramming.Models.aspnetLogicalProgrammingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LogicalTask LogicalTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LogicalTask = await _context.Task
                .Include(l => l.CategoryNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (LogicalTask == null)
            {
                return NotFound();
            }
           ViewData["Category"] = new SelectList(_context.Category, "Id", "CategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LogicalTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogicalTaskExists(LogicalTask.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LogicalTaskExists(int id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
