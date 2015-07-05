using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using PersianRug.Business.Bootstrapper;
using PersianRug.Business.Entities;
using PersianRug.Data.Contracts;
using Core.Common.Contracts;
using Core.Common.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PersianRug.Data.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

        [TestMethod]
        public void test_repository_usage()
        {
            RepositoryTestClass repositoryTest = new RepositoryTestClass();

            IEnumerable<TimeSlot> timeSlots = repositoryTest.GetTimeSlots();

            Assert.IsTrue(timeSlots != null);
        }

        [TestMethod]
        public void test_repository_factory_usage()
        {
            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass();

            IEnumerable<TimeSlot> timeSlots = factoryTest.GetTimeSlots();

            Assert.IsTrue(timeSlots != null);
        }

        [TestMethod]
        public void test_repository_mocking()
        {
            List<TimeSlot> timeSlots = new List<TimeSlot>()
            {
                new TimeSlot() { TimeSlotId = 1, Description = "Mustang" },
                new TimeSlot() { TimeSlotId = 2, Description = "Corvette" }
            };

            Mock<ITimeSlotRepository> mockTimeSlotRepository = new Mock<ITimeSlotRepository>();
            mockTimeSlotRepository.Setup(obj => obj.Get()).Returns(timeSlots);

            RepositoryTestClass repositoryTest = new RepositoryTestClass(mockTimeSlotRepository.Object);

            IEnumerable<TimeSlot> ret = repositoryTest.GetTimeSlots();

            Assert.IsTrue(ret == timeSlots);
        }
        
        [TestMethod]
        public void test_factory_mocking1()
        {
            List<TimeSlot> timeSlots = new List<TimeSlot>()
            {
                new TimeSlot() { TimeSlotId = 1, Description = "Mustang" },
                new TimeSlot() { TimeSlotId = 2, Description = "Corvette" }
            };

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<ITimeSlotRepository>().Get()).Returns(timeSlots);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

            IEnumerable<TimeSlot> ret = factoryTest.GetTimeSlots();

            Assert.IsTrue(ret == timeSlots);
        }

        [TestMethod]
        public void test_factory_mocking2()
        {
            List<TimeSlot> timeSlots = new List<TimeSlot>()
            {
                new TimeSlot() { TimeSlotId = 1, Description = "Mustang" },
                new TimeSlot() { TimeSlotId = 2, Description = "Corvette" }
            };

            Mock<ITimeSlotRepository> mockTimeSlotRepository = new Mock<ITimeSlotRepository>();
            mockTimeSlotRepository.Setup(obj => obj.Get()).Returns(timeSlots);

            Mock<IDataRepositoryFactory> mockDataRepository = new Mock<IDataRepositoryFactory>();
            mockDataRepository.Setup(obj => obj.GetDataRepository<ITimeSlotRepository>()).Returns(mockTimeSlotRepository.Object);

            RepositoryFactoryTestClass factoryTest = new RepositoryFactoryTestClass(mockDataRepository.Object);

            IEnumerable<TimeSlot> ret = factoryTest.GetTimeSlots();

            Assert.IsTrue(ret == timeSlots);
        }
    }

    public class RepositoryTestClass
    {
        public RepositoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryTestClass(ITimeSlotRepository timeSlotRepository)
        {
            _TimeSlotRepository = timeSlotRepository;
        }

        [Import]
        ITimeSlotRepository _TimeSlotRepository;

        public IEnumerable<TimeSlot> GetTimeSlots()
        {
            IEnumerable<TimeSlot> timeSlots = _TimeSlotRepository.Get();

            return timeSlots;
        }
    }

    public class RepositoryFactoryTestClass
    {
        public RepositoryFactoryTestClass()
        {
            ObjectBase.Container.SatisfyImportsOnce(this);
        }

        public RepositoryFactoryTestClass(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        public IEnumerable<TimeSlot> GetTimeSlots()
        {
            ITimeSlotRepository timeSlotRepository = _DataRepositoryFactory.GetDataRepository<ITimeSlotRepository>();

            IEnumerable<TimeSlot> timeSlots = timeSlotRepository.Get();

            return timeSlots;
        }
    }
}
