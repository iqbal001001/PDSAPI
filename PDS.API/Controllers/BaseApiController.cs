using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PDS.API.Extension;
using PDS.API.Dto;
using PDS.Service;
using System;
using PDS.Domain;
using System.Web.Http.Cors;
using PDS.API.Service;
using Newtonsoft.Json;

namespace PDS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseApiController<T,Dto> : ApiController  where T : class, IData where Dto : class, IDataDto
    {
        protected BaseService<T> _service;
        protected IDtoService<T, Dto> _dtoService;
        protected WorkFlowItemService _workFlowItemService;

        public BaseApiController()
        {

        }

        public IEnumerable<Dto> Gets()
        {
            return _service.Gets().Select(t => _dtoService.ToDto(t));
        }

      

       
        // GET: api/Product/5
        public Dto Get(int id)
        {
            //return _service.Gets(id).First().ToDto();
            T l =  (T)_service.Gets(id).First();
            var ldto = _dtoService.ToDto(l);
            return ldto;
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            _service.Remove(_service.Gets(id).First());
        }

    }
}