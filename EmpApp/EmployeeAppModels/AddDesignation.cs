using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppModels
{
    public class AddDesignation
    {
        [DisplayName("Add Designation")]

        [StringLength(100, MinimumLength = 3)]
        public string Designation { get; set; } = null!;
    }
}
