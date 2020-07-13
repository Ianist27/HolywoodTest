using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hollywood.Models
{
    public class EventDetailModel
    {
        [Key]
        public long EventDetailID { get; set; }
        
        [Required]
        public long FK_EventID { get; set; }
        
        [Required]
        public short FK_EventDetailStatusID { get; set; }
        public string EventDetailName { get; set; }
        public short EventDetailNumber { get; set; }
        public decimal EventDetailOdd { get; set; }
        public short FinishingPosition { get; set; }
        public byte FirstTimer { get; set; }
    }
}
