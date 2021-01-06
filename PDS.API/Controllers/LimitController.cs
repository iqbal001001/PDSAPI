using PDS.Domain;
using PDS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PDS.API.Extension;
using PDS.API.Dto;
using System.Web.Http.Cors;

namespace PDS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LimitController : BaseApiController<Limit>
    {

        public LimitController()
        {
            _service = new LimitSerivce();
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]LimitDto value)
        {
            try
            {
                var originalEntity = _service.Gets(value.Id).FirstOrDefault();
                var entity = value.ToDomain(originalEntity);
                _service.Add(entity);
                return Ok(entity.Id);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

    }

    public class LimitTypeController : BaseApiController<LimitType>
    {

        public LimitTypeController()
        {
            _service = new LimitTypeSerivce();
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]LimitTypeDto value)
        {
            try
            {
                var originalEntity = _service.Gets(value.Id).FirstOrDefault();
                var entity = value.ToDomain(originalEntity);
                _service.Add(entity);
                return Ok(entity.Id);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

    }
}
