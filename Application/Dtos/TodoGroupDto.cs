using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos
{
    public class TodoGroupDto
    {
        public int Id { get; set; }
        [Display(Name = "GroupName Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(128, ErrorMessage = "{0} is not more then {1}")]
        public string GroupName { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}
