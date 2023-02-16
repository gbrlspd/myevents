using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvents.API.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Place { get; set; }
        public string Date { get; set; }
        public string Theme { get; set; }
        public int PeopleQty { get; set; }
        public string Batch { get; set; }
        public string? ImageURL { get; set; }
    }
}