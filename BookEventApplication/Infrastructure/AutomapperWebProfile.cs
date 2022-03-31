using BookEventApplication.Data;
using BookEventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEventApplication.Infrastructure
{
    public class AutomapperWebProfile: AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<EventModel, Event>().ReverseMap();
        }
    }
}
