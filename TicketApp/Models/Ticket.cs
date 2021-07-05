using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//ticket model
namespace TicketApp.Models
{
    public class Ticket
    {
        //attributes
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Please enter the name of your ticket.")]
        public string TicketName { get; set; }

        [Required(ErrorMessage = "Please enter a ticket description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter point value")]
        [Range(1, 10, ErrorMessage = "Point value must be between 1 - 10")]
        public int PointValue { get; set; }
        [Required(ErrorMessage = "Please enter a deadline.")]
        public DateTime? Deadline { get; set; }

        [Required(ErrorMessage = "Please enter a sprint number for your ticket.")]
        public string SprintId { get; set; }
        public Sprint Sprint { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }

        public bool Overdue =>
            StatusId == "open" && Deadline < DateTime.Today;
    }
}
