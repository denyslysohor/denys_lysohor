using AutoMapper;
using Managers.BLL.Interfaces;
using Managers.BLL.Services;
using Managers.DAL.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BLL.UnitTests.Services
{
    public class ManagerServiceTests
    {
        [Theory]
        [InlineData(3)]
        public void GetById_ShouldReturnManager(int id)
        {
            //arrange
            var manager = new Manager { Id = 3, FirstName = "Vladimir" };

            var managerServiceMock = new Mock<IManagerService>();
            managerServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(manager);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<IEnumerable<Manager>>(It.IsAny<Manager>()))
                .Returns((IEnumerable<Manager>)manager);

            var managerService = new ManagerService(managerServiceMock.Object, mapperMock.Object);

            //act
            var result = managerService.GetById(id);

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAll_ShouldReturnArrayOfManager()
        {
            // arrange
            var managers = new List<Manager>
            {
                new Manager
                {
                    Id = 1,
                    FirstName = "Ivan"
                },
                new Manager
                {
                    Id = 2,
                    FirstName = "Alex"
                }
            };

            var ManagerDAL = managers.Select(x => new Manager { Id = x.Id });

            var databaseMock = new Mock<IManagerService>();
            databaseMock.Setup(x => x.GetAll())
                .Returns(managers);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<IEnumerable<Shop>>(It.IsAny<IEnumerable<Manager>>()))
                .Returns((Delegate)ManagerDAL);

            var managerService = new ManagerService(databaseMock.Object, mapperMock.Object);

            //act
            var result = managerService.GetAll();

            //assert
            Assert.NotNull(result);
        }
    }
}
