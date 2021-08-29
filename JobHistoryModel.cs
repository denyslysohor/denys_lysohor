using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewManagers.Models
{
    public class JobHistoryModel
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ManagerId { get; set; }
        public int ShopId { get; set; }
    }
}
