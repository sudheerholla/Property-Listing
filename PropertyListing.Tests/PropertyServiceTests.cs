using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using PropertyListing.Core.BLL;
using PropertyListing.Core.DAL;
using PropertyListing.Core.Models;

namespace PropertyListing.Tests
{
    public class PropertyServiceTests
    {
       [Fact]
        public void Should_NotCall_AddProperty_When_Record_Exists()
        {
            var httpClientMock = new Mock<HttpClient>();
            var propertyRepoMock = new Mock<IPropertyRepository>();
            propertyRepoMock.Setup(m => m.GetById(
                It.IsAny<int>()
            )).Returns(() => Task.FromResult(new Property()));
            propertyRepoMock.Setup(m => m.AddProperty(
                It.IsAny<Property>()
            )).Returns(() => Task.FromResult(1));
            PropertyService propertyservice = new PropertyService(httpClientMock.Object, propertyRepoMock.Object);
            propertyservice.AddProperty(new Property());

            propertyRepoMock.Verify(m => m.GetById(
                It.IsAny<int>()),Times.Once());

            propertyRepoMock.Verify(m => m.AddProperty(
                It.IsAny<Property>()
            ), Times.Never);

        }

        [Fact]
        public void Should_Call_AddProperty_When_Record_Does_Not_Exists()
        {
            var httpClientMock = new Mock<HttpClient>();
            var propertyRepoMock = new Mock<IPropertyRepository>();
            propertyRepoMock.Setup(m => m.GetById(
                It.IsAny<int>()
            )).Returns(Task.FromResult((Property)null));
            propertyRepoMock.Setup(m => m.AddProperty(
                It.IsAny<Property>()
            )).Returns(() => Task.FromResult(1));
            PropertyService propertyservice = new PropertyService(httpClientMock.Object, propertyRepoMock.Object);
            propertyservice.AddProperty(new Property());

            propertyRepoMock.Verify(m => m.GetById(
                It.IsAny<int>()), Times.Once());

            propertyRepoMock.Verify(m => m.AddProperty(
                It.IsAny<Property>()
            ), Times.Once);

        }
    }
}
