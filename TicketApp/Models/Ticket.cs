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

        [Required(ErrorMessage = "Please enter the name of your ticket.")]//makes it required/custom error message
        [StringLength(25)] //makes it so string length can only be 25 characters
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Name cannot contain special characters")]//regex pattern that only allows upper and lower case letter
        public string TicketName { get; set; }

        [Required(ErrorMessage = "Please enter a ticket description.")]//makes it required/custom error message
        [StringLength(55)]//sets length of characters that can be entered
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter point value")]//makes it required/custom error message
        [Range(1, 10, ErrorMessage = "Point value must be between 1 - 10")]//sets a range that number has to be in
        public int? PointValue { get; set; }
        [Required(ErrorMessage = "Please enter a deadline.")]//makes it required/custom error message
        [Range(typeof(DateTime), "1/1/2000", "12/31/2099", ErrorMessage = "Deadline must be after 1/1/2000 and cannot exceed 12/31/2099")]//sets date range
        public DateTime? Deadline { get; set; }
        [Required(ErrorMessage = "Please select a sprint number for your ticket.")]
        [Phone]
        public string SprintId { get; set; }
        public Sprint Sprint { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string StatusId { get; set; }
        public Status Status { get; set; }

        public bool Overdue =>
            StatusId == "t" && Deadline<DateTime.Today|| StatusId == "i"  && Deadline < DateTime.Today || StatusId == "qa" && Deadline < DateTime.Today;
        //checks to see if ticket is overdue

    }
}
