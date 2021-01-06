using PDS.Domain;
using PDS.Service;
using System;
using System.Linq;
using System.Web.Http;
using PDS.API.Extension;
using PDS.API.Dto;
using System.Web.Http.Cors;
using PDS.API.Service;
using System.Collections.Generic;

namespace PDS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeatureItemController : BaseApiController<FeatureItem,FeatureItemDto>
    {

        public FeatureItemController()
        {
            _service = new FeatureItemSerivce();
            _dtoService = new FeatureItemDtoService();
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]FeatureItemDto value)
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

        [Route("api/FeatureItem/Item/List")]
        public IHttpActionResult PostList([FromBody]FeatureItemGroupDto value)
        {
            try
            {
                var originalEntities = ((FeatureItemSerivce)_service)
                    .GetByFeature(value.FeatureId)
                    .ToList();

                // For Deleted Link records
                var deletedEntities = originalEntities.Where(e => !value.Items.Select(x => x.Id).Contains(e.Id)).ToList();
                _service.RemoveRange(deletedEntities);

                var entities = value.Items.Select(x => x.ToDomain(_service.Gets(x.Id).FirstOrDefault())).ToList();
                _service.AddRange(entities);

                value.Items = entities.Select(x => x.ToDto()).ToList();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public class FeatureItemGroupDto
        {
            public int FeatureId { get; set; }
            public List<FeatureItemDto> Items { get; set; }
        }
    }
}
