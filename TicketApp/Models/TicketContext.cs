using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace TicketApp.Models
{ 
    //ticketcontext
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
                : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sprint>().HasData(
                new Sprint { SprintId = "1", Name = "712-222-0090" },
                new Sprint { SprintId = "2", Name = "712-789-8872" },
                new Sprint { SprintId = "3", Name = "712-111-1111" },
                new Sprint { SprintId = "4", Name = "712-987-1234" },
                new Sprint { SprintId = "5", Name = "712-712-0712" }
            );
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "t", Name = "To Do" },
                new Status { StatusId = "i", Name = "In progress" },
                new Status { StatusId = "qa", Name = "Quality Assurance" },
                new Status { StatusId = "d", Name = "Done" }
            );
        }
    }
}
