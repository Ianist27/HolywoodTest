using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hollywood.Models;

namespace Hollywood.Web.Data
{
    public class HollywoodWebContext : DbContext
    {
        public HollywoodWebContext (DbContextOptions<HollywoodWebContext> options)
            : base(options)
        {
        }

        public DbSet<Hollywood.Models.TournamentModel> TournamentModel { get; set; }
    }
}
