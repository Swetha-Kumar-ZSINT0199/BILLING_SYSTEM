using BillLibrary.Modal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Modal
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "Text")]
        public int Qty { get; set; }
        [Column(TypeName = "Text")]
        public int Price { get; set; }
        //To add foreignKey from the user table
        [ForeignKey("User")]
        public int UserId { get; set; }
        //To fetch the data from the User table 
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public virtual Items? Item { get; set; }


    }
}
