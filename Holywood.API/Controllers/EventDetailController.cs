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
    [Route("api/EventDetail")]
    [ApiController]
    public class EventDetailController : ControllerBase
    {
        NQSIIEntities dbContext = new NQSIIEntities();

        // GET: api/<EventDetail>
        [HttpGet]
        public IEnumerable<EventDetailModel> Get()
        {
            var res = dbContext.EventDetails.ToList();

            return AutoMapper.MapItems<DAL.EventDetail, EventDetailModel>(res);
        }

        // GET api/<EventDetail>/5
        [HttpGet("{id}")]
        public EventDetailModel Get(long id)
        {
            var res = dbContext.EventDetails.Where(x => x.EventDetailID == id).FirstOrDefault();

            return AutoMapper.MapItem<DAL.EventDetail, EventDetailModel>(res);
        }

        // POST api/<EventDetail>
        [HttpPost]
        public int Create(EventDetailModel eventDetail)
        {
            var res = AutoMapper.MapItem<EventDetailModel, DAL.EventDetail>(eventDetail);

            dbContext.EventDetails.Add(res);

            return dbContext.SaveChanges();
        }

        // PUT api/<EventDetail>/5
        [HttpPut("{id}")]
        public int Update(EventDetailModel eventDetail)
        {
            var res = AutoMapper.MapItem<EventDetailModel, DAL.EventDetail>(eventDetail);

            //dbContext.Tournaments.Attach(res);

            dbContext.Entry(res).State = EntityState.Modified;

            return dbContext.SaveChanges();
        }

        // DELETE api/<EventDetail>/5
        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            var res = dbContext.EventDetails.Where(x => x.EventDetailID == id).FirstOrDefault();

            dbContext.EventDetails.Remove(res);

            return dbContext.SaveChanges();
        }
    }
}
