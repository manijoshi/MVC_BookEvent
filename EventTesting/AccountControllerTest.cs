using BookEventApplication.Controllers;
using BookEventApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EventTesting
{
    public class AccountControllerTest
    {
        private readonly IAccountRepository _accountRepository = null;

        public AccountControllerTest(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Test]
        public void Index()
        {
            //Arrange
            AccountController controller = new AccountController(_accountRepository);

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void SignUp()
        {
            //Arrange
            AccountController controller = new AccountController(_accountRepository);

            //act
            ViewResult result = controller.SignUp() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void LogIn()
        {
            //Arrange
            AccountController controller = new AccountController(_accountRepository);

            //act
            ViewResult result = controller.LogIn() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void LogOut()
        {
            //Arrange
            AccountController controller = new AccountController(_accountRepository);
            //act
            var result = controller.LogOut() as Task<IActionResult>;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
