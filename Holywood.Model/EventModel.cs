using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hollywood.Models
{
    public class EventModel
    {
        [Key]
        public long EventID { get; set; }
        [Required]
        public long FK_TournamentID { get; set; }
        public string EventName { get; set; }
        public short EventNumber { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime EventEndDateTime { get; set; }
        public byte AutoClose { get; set; }
    }
}
