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
    public class ProductCodeController : BaseApiController<ProductCode,ProductCodeDto>
    {
        private readonly AncillarySerivce _ancillarySerivce;
        private readonly ProductLineSerivce _productLineSerivce;
        public ProductCodeController()
        {
            _service = new ProductCodeSerivce();
            _ancillarySerivce = new AncillarySerivce();
            _productLineSerivce = new ProductLineSerivce();
            _dtoService = new ProductCodeDtoService();
        }

        [Route("api/ProductCode/Dependents/{id}")]
        public List<ProductCodeDto> GetDependents(int? id = null)
        {
            var entity = ((ProductCodeSerivce)_service).GetDependents(id).Select(t => t.ToDto()).ToList();
            return entity;
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]ProductCodeDto value)
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

        [Route("api/ProductCode/Dependents")]
        public IHttpActionResult PostWithDependents([FromBody]ProductCodeDto value)
        {
            try
            {
                var originalEntity = ((ProductCodeSerivce)_service).GetDependents(value.Id).FirstOrDefault();
                // For Deleted Link records
                if (originalEntity != null && value.Ancillaries != null)
                {
                    var deletedAncillaryEntities = originalEntity.Ancillaries.Where(e => !value.Ancillaries.Select(x => x.Id).Contains(e.Id)).ToList();
                    _ancillarySerivce.RemoveRange(deletedAncillaryEntities, false);
                }

                var entity = value.ToDomain(originalEntity);
                entity.Ancillaries = value.Ancillaries?.Select(v => v.ToDomain()).ToList();
                entity.Ancillaries.ForEach(x => _service.UpdateData(x));

                _service.Add(entity);
                return Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
