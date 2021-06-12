using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogicalProgramming.Models
{
    public partial class Category
    {
        public Category()
        {
            Task = new HashSet<LogicalTask>();
        }

        public int Id { get; set; }
        [Display(Name = "Название категории")]
        public string CategoryName { get; set; }
        [Display(Name = "Описание категории")]
        public string CategoryDesc { get; set; }

        public virtual ICollection<LogicalTask> Task { get; set; }
    }
}
