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
    [Route("api/EventDetailStatus")]
    [ApiController]
    public class EventDetailStatusController : ControllerBase
    {
        NQSIIEntities dbContext = new NQSIIEntities();

        // GET: api/<EventDetailStatus>
        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<EventDetailStatusModel> Get()
        {
            var res = dbContext.EventDetailStatus.ToList();

            return AutoMapper.MapItems<DAL.EventDetailStatu, EventDetailStatusModel>(res);
        }

        // GET api/<EventDetailStatus>/5
        [HttpGet("{id}")]
        [Route("Get")]
        public EventDetailStatusModel Get(long id)
        {
            var res = dbContext.EventDetailStatus.Where(x => x.EventDetailStatusID == id).FirstOrDefault();

            return AutoMapper.MapItem<DAL.EventDetailStatu, EventDetailStatusModel>(res);
        }

        // POST api/<EventDetailStatus>
        [HttpPost]
        public int Create(EventDetailStatusModel eventDetailStatus)
        {
            var res = AutoMapper.MapItem<EventDetailStatusModel, DAL.EventDetailStatu>(eventDetailStatus);

            dbContext.EventDetailStatus.Add(res);

            return dbContext.SaveChanges();
        }

        // PUT api/<EventDetailStatus>/5
        [HttpPut("{id}")]
        public int Update(EventDetailStatusModel eventDetailStatus)
        {
            var res = AutoMapper.MapItem<EventDetailStatusModel, DAL.EventDetailStatu>(eventDetailStatus);

            //dbContext.Tournaments.Attach(res);

            dbContext.Entry(res).State = EntityState.Modified;

            return dbContext.SaveChanges();
        }

        // DELETE api/<EventDetailStatus>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            var res = dbContext.EventDetailStatus.Where(x => x.EventDetailStatusID == id).FirstOrDefault();

            dbContext.EventDetailStatus.Remove(res);

            return dbContext.SaveChanges();
        }
    }
}
