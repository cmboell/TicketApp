using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketApp.Models;

namespace TicketApp.Controllers
{  //home controller 
    public class HomeController : Controller
    {
        private TicketContext context;
        public HomeController(TicketContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            // load current filters and data needed for filter drop downs in ViewBag
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Sprints = context.Sprints.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            ViewBag.DueFilters = Filters.DueFilterValues;

            // get Ticket objects from database based on current filters
            IQueryable<Ticket> query = context.Tickets
                .Include(t => t.Sprint).Include(t => t.Status);
              if (filters.HasSprint)
            {
                query = query.Where(t => t.SprintId == filters.SprintId);
            }
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            if (filters.HasDue)
            {
                var today = DateTime.Today;
                if (filters.IsPast)
                    query = query.Where(t => t.Deadline < today);
                else if (filters.IsFuture)
                    query = query.Where(t => t.Deadline > today);
                else if (filters.IsToday)
                    query = query.Where(t => t.Deadline == today);
            }
            var tickets = query.OrderBy(t => t.Deadline).ToList();
            return View(tickets);
        }

        public IActionResult Add()
        {
            ViewBag.Sprints = context.Sprints.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Sprints = context.Sprints.ToList();
                ViewBag.Statuses = context.Statuses.ToList();
                ModelState.AddModelError("", "Please correct all errors.");//error message
                return View(ticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }
        
        [HttpPost]
        public IActionResult Edit([FromRoute] string id, Ticket selected)
        {
            if (selected.StatusId == null)
            {
                context.Tickets.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.Tickets.Find(selected.TicketId);
                selected.StatusId = newStatusId;
                context.Tickets.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}