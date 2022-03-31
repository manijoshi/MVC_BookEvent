using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookEventApplication.Repository;
using Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookEventApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _EventRepository = null;
        private ILog _ILog;

        public HomeController(IEventRepository eventRepository)
        {
            _EventRepository = eventRepository;
            _ILog = Log.GetInstance;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _EventRepository.GetAllEvents();
            return View(data);
        }

        public ViewResult AboutUs()
        {
            return View();
        }



        


        [Route("customer-support")]
        public IActionResult CustomerSupport()
        {
            return Redirect("http://helpdesk.nagarro.com");
        }
    }
}
