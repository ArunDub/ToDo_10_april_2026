using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TodoDto
    {

        public int Id{ get; set; }
        public int? TodoListId { get; set;}
        [Display(Name ="Todo Item")]
        [Required(ErrorMessage ="{0}is Required")]
        [StringLength(128,ErrorMessage ="{0} can not be more than {1} charecter")]
        public string TodoItem { get; set; }
        [Display(Name = "Created On")]
        [Column(TypeName="datetime")]
        public DateTime CreatedOn { get; set;}
        [Display(Name = "Due Date")]
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set;}
        [Display(Name = "Reminder Date")]
        [Column(TypeName = "datetime")]
        public DateTime ReminderDate { get; set;}
        [StringLength(128,ErrorMessage ="{0} can not be more than {1}")]
        public string Repeat { get; set; }
        public bool Important { get; set; }
        public bool Completed { get; set; }
        public virtual TodoList TodoList{ get; set; }
    }
}
