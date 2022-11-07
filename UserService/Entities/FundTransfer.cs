using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Security.Principal;

namespace UserService.Entities
{
    [Table("Tbl_FundTransfer")]
    public class FundTransfer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SourceAccNumber { get; set; }
        [Required]
        public string DestAccNumber { get; set; }
        [Required]
        public char DestAccTypeID { get; set; }
        [Required]
        public int TransferAmount { get; set; }
    }
}

