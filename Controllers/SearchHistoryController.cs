using SearchHistoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SearchHistoryAPI.Controllers
{
    public class SearchHistoryController : ApiController
    {
        public IEnumerable<search_history> Get()
        {
            using (SearchHistoryDBEntities dbContext = new SearchHistoryDBEntities())
            {
                return dbContext.search_history.ToList();
            }
        }


        public IHttpActionResult Post(search_history search_History)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new SearchHistoryDBEntities())
            {
                ctx.search_history.Add(new search_history()
                {
                    city = search_History.city,
                    weather = search_History.weather,
                    description = search_History.description
                });

                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}
