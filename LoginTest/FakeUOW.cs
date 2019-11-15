using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using B_Commerce.Common.UOW;

namespace LoginTest
{
    [TestClass]
    class FakeUOW
    {
        public readonly IUnitOfWork MockObject;
        public FakeUOW()
        {
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(t => t.SaveChanges()).Returns(() => 1);

            MockObject = mockUOW.Object;
        }
    }
}
