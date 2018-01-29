using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLib;
using DataAccessLib.DAL;

namespace TestWebApi.Controllers
{
    public class TimeBookerController : ApiController
    {
        private readonly IRepository<TimeBooker> _timeBookerRepository;

        public TimeBookerController()
        {
            _timeBookerRepository = new TimeBookerRepository();
        }

        // for unit test.
        public TimeBookerController(IRepository<TimeBooker> dbRepository)
        {
            _timeBookerRepository = dbRepository;
        }

        // GET api/TimeBooker
        public IEnumerable<TimeBooker> Get()
        {
            return _timeBookerRepository.GetAll();
        }

        // GET api/TimeBooker/3
        public IHttpActionResult Get(int id)
        {
            var result = _timeBookerRepository.Get(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/TimeBooker
        public IHttpActionResult Post([FromBody]TimeBooker newBooking)
        {
            if (ModelState.IsValid)
            {
                _timeBookerRepository.Insert(newBooking);
                _timeBookerRepository.Save();

                return Ok(newBooking.Id);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/TimeBooker/3
        public IHttpActionResult Put(int id, [FromBody] TimeBooker updatedBooking)
        {
            if (ModelState.IsValid && id == updatedBooking.Id)
            {

                var result = _timeBookerRepository.Update(updatedBooking);

                if (result)
                {
                    _timeBookerRepository.Save();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        // DELETE api/TimeBooker/3
        public IHttpActionResult Delete(int id)
        {
            var result = _timeBookerRepository.Delete(id);

            if (result)
            {
                _timeBookerRepository.Save();
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
