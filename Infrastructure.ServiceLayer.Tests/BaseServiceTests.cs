using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Infrastructure.DataLayer;
using Moq;
using Xunit;

namespace Infrastructure.ServiceLayer.Tests
{
    public class BaseServiceTests
    {
        private readonly List<Entity> _testData = new List<Entity>();
        private readonly Mock<IBaseRepository<Entity>> _mockRepository;
        private readonly IBaseService<Entity> _service;

        public BaseServiceTests()
        {
            var mockMapper = new Mock<IMapper>();
            mockMapper
                .Setup(x => x.Map<Entity>(It.IsAny<Entity>()))
                .Returns<Entity>(x => x);

            _mockRepository = new Mock<IBaseRepository<Entity>>();
            _mockRepository
                .Setup(x => x.GetAll())
                .Returns(() => _testData);
            _mockRepository
                .Setup(x => x.GetPage(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int no, int size) => _testData.Skip(no * size).Take(size).ToList());
            _mockRepository
                .Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string id) => _testData.FirstOrDefault(x => x.Id == id));
            _mockRepository
                .Setup(x => x.Insert(It.IsAny<Entity>()))
                .Returns<Entity>(x => x);
            _mockRepository
                .Setup(x => x.Update(It.IsAny<Entity>()))
                .Returns<Entity>(_ => true);
            _mockRepository
                .Setup(x => x.Delete(It.IsAny<string>()))
                .Returns<string>(_ => true);

            _service = new BaseService<Entity,Entity>(_mockRepository.Object, mockMapper.Object);
        }

        #region GetAll
        [Fact]
        public void GetAll()
        {
            Assert.Equal(
                expected: _mockRepository.Object.GetAll(),
                actual: _service.GetAll());
        }
        #endregion

        #region GetPage
        [Theory]
        [InlineData(1, 5)]
        [InlineData(4, 5)]
        [InlineData(4, 6)]
        public void GetPage_ValidPageData_Success(int pageNo, int pageSize)
        {
            Assert.Equal(
                expected: _mockRepository.Object.GetPage(pageNo, pageSize),
                actual: _service.GetPage(pageNo, pageSize));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 5)]
        [InlineData(1, 0)]
        public void GetPage_InvalidPageData_ArgumentException(int pageNo, int pageSize)
        {
            Assert.Throws<ArgumentException>(() => _service.GetPage(pageNo, pageSize));
        }
        #endregion

        #region GetById
        [Theory]
        [InlineData("1")]
        public void GetById_ValidId_Success(string id)
        {
            Assert.Equal(
                expected: _mockRepository.Object.GetById(id),
                actual: _service.GetById(id));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GetById_NullId_ArgumentNullException(string id)
        {
            Assert.Throws<ArgumentNullException>(() => _service.GetById(id));
        }
        #endregion

        #region Insert
        [Theory]
        [InlineData("1")]
        public void Insert_ValidDto_Success(string id)
        {
            var entity = new Entity { Id = id };

            Assert.Equal(
                expected: entity,
                actual: _service.Insert(entity));
        }

        [Fact]
        public void Insert_NullDto_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _service.Insert(null));
        }
        #endregion

        #region Update
        [Theory]
        [InlineData("1")]
        public void Update_ValidId_Success(string id)
        {
            var entity = new Entity { Id = id };

            Assert.True(_service.Update(entity));
        }

        [Fact]
        public void Update_NullId_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _service.Update(null));
        }
        #endregion

        #region Delete
        [Theory]
        [InlineData("1")]
        public void Delete_ValidId_Success(string id)
        {
            Assert.True(_service.Delete(id));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Delete_NullId_ArgumentNullException(string id)
        {
            Assert.Throws<ArgumentNullException>(() => _service.Delete(id));
        }
        #endregion

        #region Initial data for tests
        private void InitTestData()
        {
            foreach (var id in Enumerable.Range(0, 20))
            {
                _testData.Add(new Entity
                {
                    Id = id.ToString(),
                });
            }
        }
        #endregion
    }
}
