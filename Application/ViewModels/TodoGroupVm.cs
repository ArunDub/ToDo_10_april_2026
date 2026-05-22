using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TodoGroupVm
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
