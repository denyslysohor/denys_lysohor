using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaFile
{
    class Order
    {
        public int Id { get; set; }

        public int User_id { get; set; } 

        public string Order_number { get; set; }

        public DateTime Order_date { get; set; }

        public decimal Total { get; set; }

    }
}
