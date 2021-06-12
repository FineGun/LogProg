using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LogicalProgramming.Models;

namespace LogicalProgramming.Pages.TaskPages
{
    public class DeleteModel : PageModel
    {
        private readonly LogicalProgramming.Models.aspnetLogicalProgrammingContext _context;

        public DeleteModel(LogicalProgramming.Models.aspnetLogicalProgrammingContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LogicalTask = await _context.Task.FindAsync(id);

            if (LogicalTask != null)
            {
                _context.Task.Remove(LogicalTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
