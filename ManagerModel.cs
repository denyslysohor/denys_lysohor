using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewManagers.Models
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEmployee { get; set; }
    }
}
