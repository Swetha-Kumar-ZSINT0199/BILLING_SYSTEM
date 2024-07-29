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
    [Table("Bill")]
    public class Bill 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //To automatically generate the ID 
        public int BillId { get; set; } //field Name in the DB
        [Column(TypeName = "Text")]     //Field type 
        public int TotalItem { get; set; }
        [Column(TypeName = "Text")]
        public int TotalAmt { get; set; }
        //To add foreignKey from the user table
        [ForeignKey("User")] 
        public int UserId { get; set; }
        //To fetch the data from the User table 

        [ForeignKey("Order")]
        public int OrderId {  get; set; }
        public virtual User? User { get; set; }
        public virtual Order? Order { get; set; }
    }        

}
