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
using PDS.API.Service;

namespace PDS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductLineController : BaseApiController<ProductLine,ProductLineDto>
    {

        public ProductLineController()
        {
            _service = new ProductLineSerivce();
            _dtoService = new ProductLineDtoService();
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]ProductLineDto value)
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
