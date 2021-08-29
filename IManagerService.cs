using Managers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.BLL.Interfaces
{
    public interface IManagerService
    {
        IEnumerable<ManagerDTO> GetAll();
        ManagerDTO Get(int id);
        void Create(ManagerDTO item);
        void Delete(int id);
    }
}
