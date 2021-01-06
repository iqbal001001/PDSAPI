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
    public class ProductExcessController : BaseApiController<ProductExcess>
    {

        public ProductExcessController()
        {
            _service = new ProductExcessService();
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]ProductExcessDto value)
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

    public class ExcessTypeController : BaseApiController<ExcessType>
    {

        public ExcessTypeController()
        {
            _service = new ExcessTypeSerivce();
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]ExcessTypeDto value)
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

    public class ExcessGroupController : BaseApiController<ExcessGroup>
    {

        public ExcessGroupController()
        {
            _service = new ExcessGroupSerivce();
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]ExcessGroupDto value)
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
