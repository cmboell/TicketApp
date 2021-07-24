using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketApp.Models;

namespace TicketApp.Models
{
    public class StatusViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Ticket ticket)
        {
            return View(ticket);
        }
    }
}

