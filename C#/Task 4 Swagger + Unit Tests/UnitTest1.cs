using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTAPI.Controllers;
using RESTAPI.Models;
using RESTAPI.Services;
using System.Collections.Generic;
using Xunit;

namespace TestsApi
{
    [TestClass]
    public class UnitTest1
    {
        GoodController controller;
        IGoodService service;

        public UnitTest1()
        {
            service = new GoodFake();
            controller = new GoodController(service);
        }

        [Fact]
        public void GetAll_ReturnsOK()
        {
            Assert.IsInstanceOfType(controller.Get("", "", "", 0, 0), typeof(OkObjectResult));
        }

        [Fact]
        public void GetAll_ReturnsListOfCompanies()
        {
            var result = controller.Get("", "", "", 0, 0) as OkObjectResult;
            Assert.IsInstanceOfType(result, typeof(List<Good>));
            Assert.Equals(3, ((List<Good>)result.Value).Count);
        }

        [Fact]
        public void GetById_ReturnsOK()
        {
            int id = 1;
            var result = controller.GetById(id);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [Fact]
        public void GetById_ReturnsError()
        {
            int id = 11;
            var result = controller.GetById(id);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [Fact]
        public void Create_ValidGood_ReturnsOK()
        {
            Good g = new Good
            {
                Id = 4,
                Code = "908-338-585",
                Title = "Blanket",
                Type = "box",
                Amount = 98,
                Price = 770,
                Data = "For years"
            };
            var result = controller.Post(g);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [Fact]
        public void Create_InvalidGood_ReturnsBadRequest()
        {
            Good g = new Good
            {
                Id = 6,
                Code = "908-338-58",
                Title = "Paper",
                Type = "letter",
                Amount = 33,
                Price = 1.7,
                Data = "Good quality"
            };
            controller.ModelState.AddModelError("Code", "Code bad format");
            var result = controller.Post(g);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [Fact]
        public void Delete_ValidId_ReturnsOk()
        {
            int id = 1;
            var result = controller.Delete(id);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [Fact]
        public void Delete_InvalidId_ReturnsNotFound()
        {
            int id = 100;
            var result = controller.Delete(id);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        [Fact]
        public void Edit_ValidGood_ReturnsOk()
        {
            Good g = new Good
            {
                Id = 4,
                Code = "908-338-585",
                Title = "Edited Good For Test",
                Type = "letter",
                Amount = 33,
                Price = 1.7,
                Data = "Good quality"
            };
            var result = controller.Put(g);
            var t = service.GetById(1);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.Equals("Edited Good For Test", t.Title);
        }

        [Fact]
        public void Edit_InvalidId_ReturnsNotFound()
        {
            Good g = new Good
            {
                Id = 8,
                Code = "908-338-585",
                Title = "Paper",
                Type = "letter",
                Amount = 33,
                Price = 1.7,
                Data = "Good quality"
            };
            var result = controller.Put(g);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
