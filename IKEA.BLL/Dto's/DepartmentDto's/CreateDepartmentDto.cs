using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto_s.DepartmentDto_s
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Code is required")]

        public string Code { get; set; }    
    }
}
