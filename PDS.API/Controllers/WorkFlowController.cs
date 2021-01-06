using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PDS.API.Dto;
using PDS.API.Extension;
using PDS.Service;
using PDS.API.Service;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace PDS.API.Controllers
{
    public class WorkFlowItemController : BaseApiController<WorkFlowItem, WorkFlowItemDto>
    {
        private static readonly HttpClient client = new HttpClient();
        public WorkFlowItemController()
        {
            _service = new WorkFlowItemService();
            _dtoService = new WorkFlowItemDtoService();
        }
        //// POST: api/WorkFlow
        //public IHttpActionResult Post([FromBody]WorkFlowItemDto value)
        //{
        //    try
        //    {
        //        var originalEntity = _service.Gets(value.Id).FirstOrDefault();
        //        var entity = value.ToDomain(originalEntity);
        //        _service.Add(entity);
        //        return Ok(entity.Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError();
        //    }
        //}

        //[Route("api/WorkFlowItem/Trigger/")]
        public IHttpActionResult Post([FromBody]WorkFlowItemDto value)
        {
            try
            {
                var originalEntity = _service.Gets(value.Id).FirstOrDefault();

                var entity = value.ToDomain(originalEntity);

                ((WorkFlowItemService)_service).AddAndTrigger(entity);

                return Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
