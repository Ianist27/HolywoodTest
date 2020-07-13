using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hollywood.Models
{
    public class TournamentModel
    {
        [Key]
        public long TournamentID { get; set; }

        public string TournamentName { get; set; }
    }
}
