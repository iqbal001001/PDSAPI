using PDS.Domain;
using PDS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using PDS.API.Extension;
using PDS.API.Dto;
using System.Web.Http.Cors;
using PDS.API.Service;
using Newtonsoft.Json;

namespace PDS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductSuiteController : BaseApiController<ProductSuite,ProductSuiteDto>
    {
        private readonly ProductVersionSerivce _versionSerivce;
        private readonly ProductLineSerivce _lineSerivce;
        //private readonly WorkFlowItemService _workFlowItemService;
        public ProductSuiteController()
        {
            _service = new ProductSuiteSerivce();
            _versionSerivce = new ProductVersionSerivce();
            _lineSerivce = new ProductLineSerivce();
            _workFlowItemService = new WorkFlowItemService();
            _dtoService = new ProductSuiteDtoService();
        }

        [Route("api/ProductSuite/GetDependentsWithWorkFlowItem/{id}")]
        public ProductSuiteDto GetDependentsWithWorkFlowItem(int id)
        {
            var suite = ((ProductSuiteSerivce)_service).GetDependents(id).Select(x => x.ToDto()).FirstOrDefault();
            try
            {
                var wFIVersions = _workFlowItemService
                    .GetWorkFlowPendingItems("ProductSuite", id, "ProductVersion")
                    .Select(x => JsonConvert.DeserializeObject<ProductVersionDto>(x)).ToList();
                var vs = suite.Versions ?? Enumerable.Empty<ProductVersionDto>().ToList();

                foreach(var wFIVersion in wFIVersions)
                {
                    if (!vs.Select(x => x.Id).Contains(wFIVersion.Id))
                    {
                        vs.Add(wFIVersion);
                    }
                }
                suite.Versions = vs;
            }
            catch (Exception ex)
            {

            }
            return suite;
        }

        [Route("api/ProductSuite/GetDependentsWithWorkFlowItemWithAmends/{id}")]
        public ProductSuiteDto GetDependentsWithWorkFlowItemWithAmends(int id)
        {
            var suite = ((ProductSuiteSerivce)_service).GetDependents(id).Select(x => x.ToDto()).FirstOrDefault();
            try
            {
                var newVersionList = new List<ProductVersionDto>();
                var wFIVersions = _workFlowItemService
                    .GetWorkFlowPendingItems("ProductSuite", id, "ProductVersion")
                    .Select(x => JsonConvert.DeserializeObject<ProductVersionDto>(x)).ToList();
                var vs = suite.Versions ?? Enumerable.Empty<ProductVersionDto>().ToList();

                foreach (var v in vs)
                {
                    if (!wFIVersions.Select(x => x.Id).Contains(v.Id))
                    {
                        wFIVersions.Add(v);
                    }
                }
                suite.Versions = wFIVersions;
            }
            catch (Exception ex)
            {

            }
            return suite;
        }

        [Route("api/ProductSuite/GetVersions/{id}")]
        public List<ProductSuiteDto> GetVersions(int? id = null)
        {
            var suite = ((ProductSuiteSerivce)_service).GetVersions(id)
                .Select(t => t.ToDto()).ToList(); 
            return suite;
        }

        [Route("api/ProductSuite/GetVersionsAndProductLines/{id}")]
        public List<ProductSuiteDto> GetVersionsAndProductLines(int? id = null)
        {
            var suite = ((ProductSuiteSerivce)_service).GetDependents(id)
                .Select(t => t.ToDto()).ToList();
            return suite;
        }

        //POST: api/Product
        public IHttpActionResult Post([FromBody]ProductSuiteDto value)
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

        [Route("api/ProductSuite/Versions/")]
        public IHttpActionResult PostWithClinicalItem([FromBody]ProductSuiteDto value)
        {
            try
            {
                var originalEntity = ((ProductSuiteSerivce)_service)
                    .GetDependents(value.Id).FirstOrDefault();

                // For Deleted Link records
                var deletedVersionEntities =
                    originalEntity?
                   .Versions.Where(e => !value.Versions.Select(x => x.Id).Contains(e.Id)).ToList()
                    ?? Enumerable.Empty<ProductVersion>().ToList();
                _versionSerivce.RemoveRange(deletedVersionEntities, false);

                var entity = value.ToDomain(originalEntity);

                entity.Versions 
                    = value.Versions?.Select(v => v.ToDomain()).ToList();

                foreach(var version in value.Versions)
                {
                    var deletedLineEntities = 
                        originalEntity?.Versions.SelectMany(x => x.Lines)
                  .Where(e => 
                  !value.Versions.SelectMany(x=>x.ProductLines)
                  .Select(x => x.Id).Contains(e.Id)).ToList()
                   ?? Enumerable.Empty<ProductLine>().ToList();

                    _lineSerivce.RemoveRange(deletedLineEntities, false);

                    var lines = version.ProductLines?.Select(v => v.ToDomain()).ToList();
                    entity.Versions.ForEach(v => v.SuiteId = entity.Id);
                    entity.Versions.ForEach(x => _service.UpdateData(x));
                    entity.Versions.FirstOrDefault(x => x.Id == version.Id).Lines = lines;
                }

                entity.Versions.ForEach(v => v.SuiteId = entity.Id);
                entity.Versions.ForEach(x => _service.UpdateData(x));



                _service.Add(entity);
                return Ok(entity.ToDto());
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("api/ProductSuite/Dependents/")]
        public IHttpActionResult PostWithDependents([FromBody]ProductSuiteDto value)
        {
            try
            {

                ProductSuite entity = AddSuite(value);
                return Ok(entity.ToDto());

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

      //  [Route("api/ProductSuite/Dependents")]
        public IHttpActionResult PostWithDependentsWithWorkFlow([FromBody]ProductSuiteDto value)
        {
            try
            {
                if (value.WorkFlowItemId != 0)
                {
                    Guid? token = _workFlowItemService.GetToken(value.WorkFlowItemId);

                    if (token.HasValue && value.WorkFlowItemToken == token.Value)
                    {
                        if (value.ApprovalStatus == ApprovalStatusDto.Approved)
                        {
                            var entity = AddSuite(value);
                            return Ok(entity.ToDto());
                        }
                        else //if (value.ApprovalStatus == ApprovalStatusDto.Pending)
                        {
                            return Ok(value);

                        }
                    }
                    else
                    {
                        return BadRequest("Invalid Token");
                    }
                }
                else
                {
                    var wFIDto = new WorkFlowItemDto
                    {
                        Obj = value,
                        API = "api/ProductSuite/Dependents/WorkFlow",
                        ApprovalStatus = ApprovalStatusDto.Pending,
                        Type = value.GetType().ToString()

                    };

                    _workFlowItemService.Add(wFIDto.ToDomain());
                    value.ApprovalStatus = ApprovalStatusDto.Pending;
                    return Ok(value);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        private ProductSuite AddSuite(ProductSuiteDto value)
        {
            var originalEntity = ((ProductSuiteSerivce)_service)
                                    .GetDependents(value.Id).FirstOrDefault();

            // For Deleted Link records
            var deletedVersionEntities =
                originalEntity?
               .Versions.Where(e => !value.Versions.Select(x => x.Id).Contains(e.Id)).ToList()
                ?? Enumerable.Empty<ProductVersion>().ToList();
            _versionSerivce.RemoveRange(deletedVersionEntities, false);

            var entity = value.ToDomain(originalEntity);

            entity.Versions
                = value.Versions?.Select(v => v.ToDomain(originalEntity?.Versions.FirstOrDefault(ov => ov.UniqueId == v.UniqueId))).ToList();

            foreach (var version in value.Versions)
            {
                var deletedLineEntities =
                    originalEntity?.Versions.SelectMany(x => x.Lines?? Enumerable.Empty<ProductLine>())
                  .Where(e =>
                  !value.Versions.SelectMany(x => x.ProductLines)
                  .Select(x => x.UniqueId).Contains(e.UniqueId)).ToList()
                   ?? Enumerable.Empty<ProductLine>().ToList();

                _lineSerivce.RemoveRange(deletedLineEntities, false);


                var lines = version.ProductLines?
                    .Select(l => l.ToDomain(
                        originalEntity?.Versions
                        .FirstOrDefault(ov => ov.UniqueId == version.UniqueId).Lines?
                        .FirstOrDefault(ol => ol.UniqueId == l.UniqueId))
                    ).ToList()?? Enumerable.Empty<ProductLine>().ToList();

                lines.ForEach(v => v.VersionId = version.Id);
                lines.ForEach(x => _service.UpdateData(x));
                entity.Versions.FirstOrDefault(x => x.UniqueId == version.UniqueId).Lines = lines;
            }

            entity.Versions.ForEach(v => v.SuiteId = entity.Id);
            entity.Versions.ForEach(x => _service.UpdateData(x));



            _service.Add(entity);
            return entity;
        }
    }
}
