using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models
{
    public class DesignationMVC
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string? DesignationCategories { get; set; }
    }
}

