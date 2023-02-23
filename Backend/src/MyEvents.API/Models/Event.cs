using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEvents.API.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Place { get; set; } = "Nowhere";
        public string Date { get; set; } = "23/01/2002";
        public string Theme { get; set; } = "Blank";
        public int PeopleQty { get; set; } = 0;
        public string Batch { get; set; } = "1st Batch";
        public string ImageURL { get; set; } = "No image";
    }
}