using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillLibrary.Modal
{
    [Table("Item")]
    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        [Column(TypeName = "Text")]
        public string Name { get; set; }
        [Column(TypeName = "Text")]
        public int Qty { get; set; }
        [Column(TypeName = "Text")]
        public int Price { get; set; }

 }
}