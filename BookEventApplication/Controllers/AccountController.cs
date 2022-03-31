using BookEventApplication.Models;
using BookEventApplication.Repository;
using Logger;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private ILog _Ilog;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _Ilog = Log.GetInstance;
        }

        /// <summary>
        /// SignUp Process in Controller
        /// </summary>
        /// <returns></returns>

        [Route("Sign-Up")]
        public IActionResult SignUp()
        {
            return View();
        }

        /// <summary>
        /// SignUp HttpPostMethod
        /// </summary>
        /// <param name="signUpUserModel"></param>
        /// <returns></returns>
        [Route("Sign-Up")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel signUpUserModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(signUpUserModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(signUpUserModel);
                }
                _Ilog.LogException("singup : user data inserted in database");
                ModelState.Clear();
            }
            return View(signUpUserModel);
        }

        /// <summary>
        /// LogIn action method
        /// </summary>
        /// <returns></returns>

        [Route("LogIn")]
        public IActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// Login action method HttpPost Method
        /// </summary>
        /// <param name="logInModel"></param>
        /// <returns></returns>

        [Route("LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PassWordSignInAsync(logInModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid credentials");
            }
            return View(logInModel);
        }

        /// <summary>
        /// Index---> Home Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// LogOut Action Method 
        /// </summary>
        /// <returns></returns>

        [Route("log-out")]
        public async Task<IActionResult> LogOut()
        {

            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
