using BookEventApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookEventApplication.Repository
{
    public interface IEventRepository
    {
        Task<int> AddNewEvent(EventModel model);
        Task<List<EventModel>> GetAllEvents();
        Task<EventModel> GetEventById(int id);
        Task<int> EditEvent(EventModel model);

        Task<List<CommentModel>> GetComments(int id);

        Task<int> AddComment(CommentModel commentModel);
    }
}