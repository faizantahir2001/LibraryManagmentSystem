using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.Models
{
    public class PurchaseTempMv
    {
        public int PurTemID { get; set; }

        public int BookID { get; set; }

        public int Qty { get; set; }

        public double UnitPrice { get; set; }

    }
}