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
    public class DetailsModel : PageModel
    {
        private readonly LogicalProgramming.Models.aspnetLogicalProgrammingContext _context;

        public DetailsModel(LogicalProgramming.Models.aspnetLogicalProgrammingContext context)
        {
            _context = context;
        }

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
    }
}
