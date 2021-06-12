using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LogicalProgramming.Models;

namespace LogicalProgramming.Pages.TaskPages
{
    public class CreateModel : PageModel
    {
        private readonly LogicalProgramming.Models.aspnetLogicalProgrammingContext _context;

        public CreateModel(LogicalProgramming.Models.aspnetLogicalProgrammingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Category"] = new SelectList(_context.Category, "Id", "CagegoryName");
            return Page();
        }

        [BindProperty]
        public LogicalTask LogicalTask { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Task.Add(LogicalTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
