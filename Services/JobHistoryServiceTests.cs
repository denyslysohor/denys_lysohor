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
    public class JobHistoryServiceTests
    {
        public void GetAll_ShouldReturnArrayOfHistory()
        {
            // arrange
            var histories = new List<JobHistory>
            {
                new JobHistory
                {
                    Id = 1,
                },
                new JobHistory
                {
                    Id = 2,
                }
            };

            var historiesDAL = histories.Select(x => new JobHistory { Id = x.Id });

            var historyMock = new Mock<IJobHistoryService>();
            historyMock.Setup(x => x.GetAll())
                .Returns(histories);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<IEnumerable<JobHistory>>(It.IsAny<IEnumerable<JobHistory>>()))
                .Returns(historiesDAL);

            var historyService = new JobHistoryService(historyMock.Object, mapperMock.Object);

            //act
            var result = historyService.GetAll();

            //assert
            Assert.NotNull(result);
        }
    }
}
