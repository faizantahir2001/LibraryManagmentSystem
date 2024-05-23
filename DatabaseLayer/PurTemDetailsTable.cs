using System.ComponentModel.DataAnnotations;
namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurTemDetailsTable
    {
        public int PurTemID { get; set; }
        [Required(ErrorMessage ="Select Book")]
        public int BookID { get; set; }
        [Required(ErrorMessage = "Enter Purchase Qty")]
        public int Qty { get; set; }
        [Required(ErrorMessage = "Enter Purchase Unit Price")]
        public double UnitPrice { get; set; }
    
        public virtual BookTable BookTable { get; set; }
    }
}
