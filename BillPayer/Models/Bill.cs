using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillPayer.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Due { get; set; }
        public bool Paid { get; set; }

    }
}
