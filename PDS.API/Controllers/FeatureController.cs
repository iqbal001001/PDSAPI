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
    public class FeatureController : BaseApiController<Feature,FeatureDto>
    {
        private readonly FeatureItemSerivce _featureItemSerivce;

        public FeatureController()
        {
            _service = new FeatureSerivce();
            _featureItemSerivce = new FeatureItemSerivce();
            _dtoService = new FeatureDtoService();
        }

        [Route("api/Feature/GetItems/{id}")]
        public List<FeatureDto> GetItems(int? id = null)
        {
            var entity = ((FeatureSerivce)_service).GetItems(id).Select(t => t.ToDto()).ToList();
            return entity;
        }

        [Route("api/Feature/Dependents/{id?}")]
        public List<FeatureDto> GetDependents(int? id = null)
        {
            var entity = ((FeatureSerivce)_service).GetDependents(id).Select(t => t.ToDto()).ToList();
            return entity;
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]FeatureDto value)
        {
            try
            {
                var originalEntity = _service.Gets(value.Id).FirstOrDefault();
                var entity = value.ToDomain(originalEntity);
                _service.Add(entity);
                return Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("api/Feature/List")]
        public IHttpActionResult Post([FromBody]List<FeatureDto> values)
        {
            try
            {
                var entities = new List<Feature>();
                foreach(var value in values)
                {
                    var originalEntity = _service.Gets(value.Id).FirstOrDefault();
                    var entity = value.ToDomain(originalEntity);
                    entities.Add(entity);
                }
               
                _service.AddRange(entities);
                return Ok(entities.Select(e => e.ToDto()));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("api/Feature/Items/")]
        public IHttpActionResult PostWithClinicalItem([FromBody]FeatureDto value)
        {
            try
            {
                var originalEntity = ((FeatureSerivce)_service).GetDependents(value.Id).FirstOrDefault();

                // For Deleted Link records
                    var deletedEntities = 
                        originalEntity?
                        .Items.Where(e => !value.Items.Select(x => x.Id).Contains(e.Id)).ToList() 
                        ??  Enumerable.Empty<FeatureItem>().ToList();
                    _featureItemSerivce.RemoveRange(deletedEntities, false);

                var entity = value.ToDomain(originalEntity);

                entity.Items = value.Items?.Select(v => v.ToDomain(originalEntity?.Items.FirstOrDefault(x=>x.UniqueId == v.UniqueId))).ToList();
                entity.Items.ForEach(v => v.FeatureId = entity.Id);
                entity.Items.ForEach(x => _service.UpdateData(x));

                _service.Add(entity);
                return Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }

    //public class FeatureTypeController : BaseApiController<FeatureType,FeatureTypeDto>
    //{

    //    public FeatureTypeController()
    //    {
    //        _service = new FeatureTypeSerivce();
    //    }

    //    // POST: api/Product                                                      
    //    public IHttpActionResult Post([FromBody]FeatureTypeDto value)
    //    {
    //        try
    //        {
    //            var originalEntity = _service.Gets(value.Id).FirstOrDefault();
    //            var entity = value.ToDomain(originalEntity);
    //            _service.Add(entity);
    //            return Ok(entity.Id);
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError();
    //        }
    //    }
    //}

    //public class FeatureGroupController : BaseApiController<FeatureGroup>
    //{

    //    public FeatureGroupController()
    //    {
    //        _service = new FeatureGroupSerivce();
    //    }

    //    // POST: api/Product                                                      
    //    public IHttpActionResult Post([FromBody]FeatureGroupDto value)
    //    {
    //        try
    //        {
    //            var originalEntity = _service.Gets(value.Id).FirstOrDefault();
    //            var entity = value.ToDomain(originalEntity);
    //            _service.Add(entity);
    //            return Ok(entity.Id);
    //        }
    //        catch (Exception ex)
    //        {
    //            return InternalServerError();
    //        }
    //    }
    //}
}
