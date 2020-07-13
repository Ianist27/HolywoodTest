using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Hollywood.Models;
using Holywood.DAL;
using Holywood.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holywood.API.Controllers
{
    [Route("api/Event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        NQSIIEntities dbContext = new NQSIIEntities();

        // GET: api/<Event>
        [HttpGet]
        public IEnumerable<EventModel> Get()
        {
            var res = dbContext.Events.ToList();

            return AutoMapper.MapItems<DAL.Event, EventModel>(res);
        }

        // GET api/<Event>/5
        [HttpGet("{id}")]
        public EventModel Get(long id)
        {
            var res = dbContext.Events.Where(x => x.EventID == id).FirstOrDefault();

            return AutoMapper.MapItem<DAL.Event, EventModel>(res);
        }

        // POST api/<Event>
        [HttpPost]
        public int Create(EventModel eventModel)
        {
            var res = AutoMapper.MapItem<EventModel, DAL.Event>(eventModel);

            dbContext.Events.Add(res);

            return dbContext.SaveChanges();
        }

        // PUT api/<Event>/5
        [HttpPut("{id}")]
        public int Update(EventModel eventModel)
        {
            var res = AutoMapper.MapItem<EventModel, DAL.Event>(eventModel);

            //dbContext.Tournaments.Attach(res);

            dbContext.Entry(res).State = EntityState.Modified;

            return dbContext.SaveChanges();
        }

        // DELETE api/<Event>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            var res = dbContext.Events.Where(x => x.EventID == id).FirstOrDefault();

            dbContext.Events.Remove(res);

            return dbContext.SaveChanges();
        }
    }
}
