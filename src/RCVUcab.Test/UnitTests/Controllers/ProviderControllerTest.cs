using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using RCVUcab.BussinesLogic.DTOs;
using RCVUcab.Controllers.Provider;
using RCVUcab.Exceptions;
using RCVUcab.Persistence.DAOs.Interfaces;
using RCVUcab.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RCVUcab.Test.UnitTests.Controllers
{
    public class ProviderControllerTest
    {
        private readonly ProviderController _controller;
        private readonly Mock<IProviderDAO> _serviceMock;
        private readonly Mock<ILogger<ProviderController>> _loggerMock;

        public ProviderControllerTest()
        {
            _loggerMock = new Mock<ILogger<ProviderController>>();
            _serviceMock = new Mock<IProviderDAO>();
            _controller = new ProviderController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact(DisplayName = "Get Providers By Brand")]
        public Task GetProvidersByBrand()
        {
            _serviceMock
                .Setup(x => x.GetProvidersByBrand(It.IsAny<string>()))
                .Returns(new List<BrandDTO>());
              
            var result = _controller.GetProvidersByBrand("");

            Assert.IsType<ApplicationResponse<List<BrandDTO>>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Get Providers By Brand with Exception")]
        public Task GetProvidersByBrandException()
        {
            _serviceMock
                .Setup(x => x.GetProvidersByBrand(It.IsAny<string>()))
                .Throws(new RCVException("", new Exception()));

            var ex = _controller.GetProvidersByBrand("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }
    }
}
