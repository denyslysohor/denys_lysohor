using AutoMapper;
using Managers.BLL;
using Managers.BLL.Interfaces;
using Managers.BLL.Services;
using Managers.DAL.Entities;
using Managers.DAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BLL.UnitTests.Services
{
    public class ShopServiceTests
    {
        [Fact]
        public void GetAll_ShouldReturnArrayOfShop()
        {
            // arrange
            var shops = new List<Shop>
            {
                new Shop
                {
                    Id = 1,
                    Name = "Shop1",
                    Address = "Address1"
                },
                new Shop
                {
                    Id = 2,
                    Name = "Shop2",
                    Address = "Address2"
                }
            };

            var ShopDAL = shops.Select(x => new Shop { Id = x.Id});

            var shopMock = new Mock<IShopService>();
            shopMock.Setup(x => x.GetAll())
                .Returns(shops);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<IEnumerable<Shop>>(It.IsAny<IEnumerable<Shop>>()))
                .Returns(ShopDAL);

            var shopService = new ShopService(shopMock.Object, mapperMock.Object);

            //act
            var result = shopService.GetAll();

            //assert
            Assert.NotNull(result);
        }
    }
}
