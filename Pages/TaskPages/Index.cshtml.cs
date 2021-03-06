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
    public class IndexModel : PageModel
    {
        private readonly LogicalProgramming.Models.aspnetLogicalProgrammingContext _context;

        public IndexModel(LogicalProgramming.Models.aspnetLogicalProgrammingContext context)
        {
            _context = context;
        }

        public IList<LogicalTask> LogicalTask { get;set; }

        public async Task OnGetAsync()
        {
            LogicalTask = await _context.Task
                .Include(l => l.CategoryNavigation).ToListAsync();
        }
    }
}
