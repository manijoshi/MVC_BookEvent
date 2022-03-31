using BookEventApplication.Controllers;
using BookEventApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EventTesting
{
    public class HomeControllerTest
    {
        private readonly IEventRepository _EventRepository = null;
        

        [Test]
        public void Index()
        {
            //Arrange
            HomeController controller = new HomeController(_EventRepository);

            //act
            var result = controller.Index() as Task<IActionResult>;

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AboutUs()
        {
            //Arrange
            HomeController controller = new HomeController(_EventRepository);

            //act
            var result = controller.AboutUs() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CustomerSupport()
        {
            //Arrange
            HomeController controller = new HomeController(_EventRepository);

            //act
            var result = controller.CustomerSupport() as ViewResult;

            //assert
            Assert.IsNull(result);
        }


    }
}
