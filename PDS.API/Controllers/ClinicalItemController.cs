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
    public class ClinicalItemController : BaseApiController<ClinicalItem, ClinicalItemDto>
    {

        public ClinicalItemController()
        {
            _service = new ClinicalItemSerivce();
            _dtoService = new ClinicalItemDtoService();
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]ClinicalItemDto value)
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

        // POST: api/Product    
        [Route("api/ClinicalItem/Item/Group")]
        public IHttpActionResult PostGroup([FromBody]ClinicalItemGroupDto value)
        {
            try
            {
                var originalEntities = ((ClinicalItemSerivce)_service)
                    .GetByClinicalCategory(value.ClinicalCategoryId)
                    .Where(x=>x.StartDate == value.StartDate && x.EndDate == value.EndDate)
                    .ToList();

                // For Deleted Link records
                var deletedEntities = originalEntities.Where(e => !value.ClinicalItems.Select(x => x.Id).Contains(e.Id)).ToList();
                _service.RemoveRange(deletedEntities);

                var entities = value.ClinicalItems.Select(x => x.ToDomain(_service.Gets(x.Id).FirstOrDefault())).ToList();
                _service.AddRange(entities);

                value.ClinicalItems = entities.Select(x=>x.ToDto()).ToList();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public class ClinicalItemGroupDto
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int ClinicalCategoryId { get; set; }

            public List<ClinicalItemDto> ClinicalItems { get; set; }
        }
    }
}
