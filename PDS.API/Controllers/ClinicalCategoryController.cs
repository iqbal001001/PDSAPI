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
    public class ClinicalCategoryController : BaseApiController<ClinicalCategory,ClinicalCategoryDto>
    {
        private readonly ClinicalItemSerivce _clinicalItemSerivce;
        private readonly ClinicalProductCategorySerivce _clinicalProductCategorySerivce;
        private readonly FeatureSerivce _featureSerivce;
        public ClinicalCategoryController()
        {
            _service = new ClinicalCategorySerivce();
            _clinicalItemSerivce = new ClinicalItemSerivce();
            _clinicalProductCategorySerivce = new ClinicalProductCategorySerivce();
            _featureSerivce = new FeatureSerivce();
            _dtoService = new ClinicalCategoryDtoService();
        }

        [Route("api/ClinicalCategory/GetItems/{id}")]
        public List<ClinicalCategoryDto> GetItems(int? id = null)
        {
            var entity = ((ClinicalCategorySerivce)_service).GetItems(id).Select(t => t.ToDto()).ToList();
            return entity;
        }

        [Route("api/ClinicalCategory/Dependents/{id}")]
        public List<ClinicalCategoryDto> GetDependents(int? id = null)
        {
            var entity = ((ClinicalCategorySerivce)_service).GetDependents(id).Select(t => t.ToDto()).ToList();
            return entity;
        }

        // POST: api/Product                                                      
        public IHttpActionResult Post([FromBody]ClinicalCategoryDto value)
        {
            try
            {
                var originalEntity = _service.Gets(value.Id).FirstOrDefault();
                var entity = value.ToDomain(originalEntity);
                _service.Add(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("api/ClinicalCategory/ClinicalItems/")]
        public IHttpActionResult PostWithClinicalItem([FromBody]ClinicalCategoryDto value)
        {
            try
            {
                var originalEntity = _service.Gets(value.Id).FirstOrDefault();
                var entity = value.ToDomain(originalEntity);
                entity.ClinicalItems = value.ClinicalItems?.Select(v => v.ToDomain()).ToList();
                entity.ClinicalItems.ForEach(x => _service.UpdateData(x));
                _service.Add(entity);
                return Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("api/ClinicalCategory/Dependents/")]
        public IHttpActionResult PostWithDependents([FromBody]ClinicalCategoryDto value)
        {
            try
            {
                var originalEntity = ((ClinicalCategorySerivce)_service).GetDependents(value.Id).FirstOrDefault();
                // For Deleted Link records
                var deletedClinicalItemsEntities =
                    originalEntity?
                    .ClinicalItems.Where(e => !value.ClinicalItems.Select(x => x.Id).Contains(e.Id)).ToList()
                    ?? Enumerable.Empty<ClinicalItem>().ToList();
                _clinicalItemSerivce.RemoveRange(deletedClinicalItemsEntities, false);

                var deletedClinicalProductCategoriesEntities =
                   originalEntity?
                   .ClinicalProductCategories.Where(e => !value.ClinicalProductCategories.Select(x => x.Id).Contains(e.Id)).ToList()
                   ?? Enumerable.Empty<ClinicalProductCategory>().ToList();
                _clinicalProductCategorySerivce.RemoveRange(deletedClinicalProductCategoriesEntities, false);

                //var deletedClinicalFeatureesEntities =
                //  originalEntity?
                //  .Features.Where(e => !value.Features.Select(x => x.Id).Contains(e.Id)).ToList()
                //  ?? Enumerable.Empty<Feature>().ToList();
                //_featureSerivce.RemoveRange(deletedClinicalFeatureesEntities, false);

                var entity = value.ToDomain(originalEntity);

                entity.ClinicalItems = value.ClinicalItems?.Select(v => v.ToDomain(originalEntity?.ClinicalItems.FirstOrDefault(x=>x.UniqueId == v.UniqueId))).ToList();
                entity.ClinicalItems.ForEach(x => _service.UpdateData(x));

                entity.ClinicalProductCategories = value.ClinicalProductCategories?.Select(v => v.ToDomain(originalEntity?.ClinicalProductCategories.FirstOrDefault(x => x.UniqueId == v.UniqueId))).ToList();
                entity.ClinicalProductCategories.ForEach(x => _service.UpdateData(x));

                entity.Features = value.Features?.Select(v => v.ToDomain(originalEntity?.Features.FirstOrDefault(x => x.UniqueId == v.UniqueId) ??_featureSerivce.Gets(v.Id).First())).ToList();
                entity.Features.ForEach(x => _service.UpdateData(x));

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
