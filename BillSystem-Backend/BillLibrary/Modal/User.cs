using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Modal
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Mail is Required")]
        [StringLength(30)]
        [EmailAddress(ErrorMessage = "Invalid Email Addeess")]

        public string? Email { get; set; }
        [Required(ErrorMessage = "Password should contain 10 Characters")]
        [StringLength(10)]
        public string? Password { get; set; }
    }
}
