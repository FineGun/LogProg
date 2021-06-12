using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace LogicalProgramming.Models
{
    [Table("Task")]
    public partial class LogicalTask
    {
        public int Id { get; set; }
        [Display(Name = "Название задачи")]
        public string Name { get; set; }
        [Display(Name = "Описание задачи")]
        public string Description { get; set; }
        [AllowHtml]
        [UIHint("tinymce_jquery_full")]
        [Display(Name = "Содержимое задачи")]
        public string Content { get; set; }
        [Display(Name = "Категория")]
        public int? Category { get; set; }
        [Display(Name = "Категория")]
        public virtual Category CategoryNavigation { get; set; }
    }
}
