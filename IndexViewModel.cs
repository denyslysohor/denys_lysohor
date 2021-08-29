using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewManagers.Models
{
    public class IndexViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
