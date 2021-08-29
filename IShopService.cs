using Managers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.BLL.Interfaces
{
    public interface IShopService
    {
        IEnumerable<ShopDTO> GetAll();
        ShopDTO Get(int id);
        void Create(ShopDTO item);
        void Delete(int id);
    }
}
