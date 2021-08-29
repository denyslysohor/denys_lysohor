using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.BLL.DTO
{
    public class JobHistoryDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int ManagerId { get; set; }
        public int ShopId { get; set; }
    }
}
