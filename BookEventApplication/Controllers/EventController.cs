using BookEventApplication.Models;
using BookEventApplication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logger;

namespace BookEventApplication.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _EventRepository ;
        private ILog _ILog;

        /// <summary>
        /// Event controller constructor
        /// </summary>
        /// <param name="eventRepository"></param>
        public EventController(IEventRepository eventRepository)
        {
            _EventRepository = eventRepository;
            _ILog = Log.GetInstance;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get all events --- all the registered events would be returned 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAllEvents()
        {
            var data = await _EventRepository.GetAllEvents();
            return View(data);
        }

        

        /// <summary>
        /// get book events by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetEventById(int id)
        {
            ViewBag.data = await _EventRepository.GetEventById(id);
            ViewBag.eveComment = await _EventRepository.GetComments(id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetComments(CommentModel commentModel)
        {
            var id = await _EventRepository.AddComment(commentModel);
            RedirectToAction("EventsInvitedTo");
            return View();
        }

        /// <summary>
        /// All the events created by user is fetched 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> MyEvents()
        {
            var data = await _EventRepository.GetAllEvents();
            return View(data);
        }

        /// <summary>
        /// Events in which user is invited action method
        /// </summary>
        /// <returns></returns>

        public async Task<IActionResult> EventsInvitedTo()
        {
            var data = await _EventRepository.GetAllEvents();
            return View(data);
        }

        /// <summary>
        /// when user want to add new event 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public ViewResult AddNewEvent(bool isSuccess = false,int eventId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.EventId = eventId;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddNewEvent(EventModel EventModel)
        {
           
            if (ModelState.IsValid)
            {
                int id = await _EventRepository.AddNewEvent(EventModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewEvent), new { isSuccess = true });
                }

            }
            ViewBag.IsSuccess = false;
            ViewBag.EventId = 0;
            return View(EventModel);
        }

       
    

        public async Task<IActionResult> EditEvent(int id)
        {
            var data = await _EventRepository.GetEventById(id);

             return View(data);
        }

   
        [HttpPost]
        public async Task<IActionResult> EditEvent(EventModel editedEvent)
        {
            int id = await _EventRepository.EditEvent(editedEvent);
            return RedirectToAction("MyEvents");
        }

        public async Task<List<CommentModel>> GetComments(int id)
        {
            return await _EventRepository.GetComments(id);
        }

        
    }
}
