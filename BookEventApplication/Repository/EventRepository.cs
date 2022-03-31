using BookEventApplication.Data;
using BookEventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookEventApplication.Infrastructure;
using Logger;

namespace BookEventApplication.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventContext _context = null;

        

        public EventRepository(EventContext context)
        {
            _context = context;
        }

        public async Task<List<EventModel>> GetAllEvents()
        {
            var Event = new List<EventModel>();
            var allEvent = await _context.Event.ToListAsync();
            if (allEvent?.Any() == true)
            {
                foreach(var events in allEvent){
                    Event.Add(new EventModel()
                    {
                        EventId = events.EventId,
                        Title = events.Title,
                        Date = events.Date,
                        StartTime = events.StartTime,
                        Duration = events.Duration,
                        Description = events.Description,
                        OtherDetails = events.OtherDetails,
                        InviteEmails = events.InviteEmails,
                        Organiser= events.Organiser,
                        EventType = events.EventType,
                        CreatedOn = events.CreatedOn,
                        UpdatedOn = events.UpdatedOn,
                        Location = events.Location
                    });
                    
                    
                        
                    
                }
            }
            return Event;
        }

        public async Task<EventModel> GetEventById(int id)
        {
            var events = await _context.Event.FindAsync(id);
            if (events != null)
            {
                var EventDetails = new EventModel()
                {
                    EventId = events.EventId,
                    Title = events.Title,
                    Date = events.Date,
                    StartTime = events.StartTime,
                    Duration = events.Duration,
                    Description = events.Description,
                    OtherDetails = events.OtherDetails,
                    InviteEmails = events.InviteEmails,
                    Organiser = events.Organiser,
                    EventType = events.EventType,
                    CreatedOn = events.CreatedOn,
                    UpdatedOn = events.UpdatedOn,
                    Location = events.Location
                };
                return EventDetails;
            }
            return null;
        }

       /* public List<EventModel> DataSource()
        {

        }*/

        public async Task<int> AddNewEvent(EventModel model)
        {
            var newEvent = new Event()
            {
                Title = model.Title,
                CreatedOn = DateTime.UtcNow,
                Date = model.Date,
                Location = model.Location,
                StartTime = model.StartTime,
                Description = model.Description,
                OtherDetails = model.OtherDetails,
                EventType = model.EventType,
                InviteEmails = model.InviteEmails,
                Duration = model.Duration,
                UpdatedOn = DateTime.UtcNow,
                Organiser = model.Organiser
                
                



            };

            await _context.Event.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return newEvent.EventId;
        }

        public async Task<int> EditEvent(EventModel model)
        {
            var oldEvent = await _context.Event.FindAsync(model.EventId);
            _context.Event.Remove(oldEvent);
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutomapperWebProfile>();
            });
            var mapper = config.CreateMapper();
            var newEvent = mapper.Map<EventModel, Event>(model);
            await _context.Event.AddAsync(newEvent);
            await _context.SaveChangesAsync();
            return model.EventId;
        }

        public async Task<List<CommentModel>> GetComments(int id)
        {
            var Comments = new List<CommentModel>();
            var allEvent = await _context.UserComment.ToListAsync();
            if (allEvent?.Any() == true)
            {
                foreach (var instance in allEvent)
                {
                    Comments.Add(new CommentModel()
                    {
                        EventId = instance.EventId,
                        Comment = instance.Comment,
                        Date = instance.Date,
                        Email = instance.Email

                    });
                }
            }
            return Comments;
        }

        
        public async Task<int> AddComment(CommentModel commentModel)
        {
            var newComment = new UserComment()
            {
                EventId = commentModel.EventId,
                Comment = commentModel.Comment,
                Date = commentModel.Date,
                Email = commentModel.Email




            };

            await _context.UserComment.AddAsync(newComment);
            await _context.SaveChangesAsync();

            return newComment.EventId;
        }
    }
}
