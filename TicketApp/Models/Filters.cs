using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//filters model
namespace TicketApp.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            SprintId = filters[0];
            Due = filters[1];
            StatusId = filters[2];
        }
        public string FilterString { get; }
        public string SprintId { get; }
        public string Due { get; }
        public string StatusId { get; }

        public bool HasSprint => SprintId.ToLower() != "all";
        public bool HasDue => Due.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";

        public static Dictionary<string, string> DueFilterValues =>
            new Dictionary<string, string> {
                { "future", "Future" },
                { "past", "Past" },
                { "today", "Today" }
            };
        public bool IsPast => Due.ToLower() == "past";
        public bool IsFuture => Due.ToLower() == "future";
        public bool IsToday => Due.ToLower() == "today";
    }
}
