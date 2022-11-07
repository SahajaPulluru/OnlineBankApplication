using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Security.Principal;

namespace UserService.Entities
{
    [Table("Tbl_checkbookdtls")]
    public class Checkbook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public DateTime RequestedDate { get; set; }
        [Required]
        public int Priority { get; set; }
    }
}

