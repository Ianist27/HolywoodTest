using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hollywood.Models
{
    public class EventDetailStatusModel
    {
        [Key]
        public short EventStatusDetailID { get; set;}

        public string EventStatusDetailName { get; set; }
    }
}
