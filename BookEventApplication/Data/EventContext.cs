using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEventApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookEventApplication.Data
{
    public class EventContext : IdentityDbContext<ApplicationUser>
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }

        public DbSet<Event> Event { get; set; }

        public DbSet<UserComment> UserComment { get; set; }

    }
}
