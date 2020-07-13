using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Hollywood.Models;
using Holywood.DAL;
using Holywood.Resources;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Holywood.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        NQSIIEntities dbContext = new NQSIIEntities();

        // GET: api/<TournamentController>
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<TournamentModel> Get()
        {
            var res = dbContext.Tournaments.ToList();

            return AutoMapper.MapItems<DAL.Tournament, TournamentModel>(res);
        }

        // GET api/<TournamentController>/5
        [HttpGet]
        [Route("Get/{id}")]
        public TournamentModel Get(long id)
        {
            var res = dbContext.Tournaments.Where(x => x.TournamentID == id).FirstOrDefault();

            return AutoMapper.MapItem<DAL.Tournament, TournamentModel>(res);
        }

        // POST api/<TournamentController>
        [HttpPost]
        [Route("Create")]
        public int Create(TournamentModel tournament)
        {
            var res = AutoMapper.MapItem<TournamentModel, DAL.Tournament>(tournament);

            dbContext.Tournaments.Add(res);

            return dbContext.SaveChanges();
        }

        // PUT api/<TournamentController>/5
        [HttpPut]
        [Route("Update")]
        public int Update(TournamentModel tournament)
        {
            var res = AutoMapper.MapItem<TournamentModel, DAL.Tournament>(tournament);

            //dbContext.Tournaments.Attach(res);

            dbContext.Entry(res).State = EntityState.Modified;

            return dbContext.SaveChanges();
        }

        // DELETE api/<TournamentController>/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(long id)
        {
            var res = dbContext.Tournaments.Where(x => x.TournamentID == id).FirstOrDefault();

            dbContext.Tournaments.Remove(res);

            return dbContext.SaveChanges();
        }
    }
}
