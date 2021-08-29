using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.BLL.DTO
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEmployee { get; set; }
    }
}
