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
    public class ProductVersionController : BaseApiController<ProductVersion,ProductVersionDto>
    {
        private readonly ProductLineSerivce _productLineSerivce;
        private readonly WorkFlowItemService _workFlowItemService;

        public ProductVersionController()
        {
            _service = new ProductVersionSerivce();
            _productLineSerivce = new ProductLineSerivce();
            _workFlowItemService = new WorkFlowItemService();
            _dtoService = new ProductVersionDtoService();
        }

        [Route("api/ProductVersion/Dependents/{id}")]
        public List<ProductVersionDto> GetDependents(int? id = null)
        {
            var entity = ((ProductVersionSerivce)_service).GetDependents(id).Select(t => t.ToDto()).ToList();
            return entity;
        }


        // POST: api/Product
        public IHttpActionResult Post([FromBody]ProductVersionDto value)
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

        //[Route("api/ProductVersion/Dependents/")]
        //public IHttpActionResult PostWithDependents([FromBody]ProductVersionDto value)
        //{
        //    try
        //    {
        //        ProductVersion entity = AddVersion(value);
        //        return Ok(entity.ToDto());
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError();
        //    }
        //}

        private ProductVersion AddVersion(ProductVersionDto value)
        {
            var originalEntity = ((ProductVersionSerivce)_service).GetDependents(value.Id).FirstOrDefault();

            // For Deleted Link records
            var deletedLinesEntities =
                originalEntity?
                .Lines.Where(e => !value.ProductLines.Select(x => x.Id).Contains(e.Id)).ToList()
                ?? Enumerable.Empty<ProductLine>().ToList();
            _productLineSerivce.RemoveRange(deletedLinesEntities, false);


            var entity = value.ToDomain(originalEntity);

            entity.Lines = value.ProductLines?.Select(v => v.ToDomain(entity.Lines.FirstOrDefault(x => x.Id == v.Id))).ToList();
            entity.Lines.ForEach(v => v.VersionId = entity.Id);
            entity.Lines.ForEach(x => _service.UpdateData(x));

            _service.Add(entity);
            return entity;
        }

        [Route("api/ProductVersion/Dependents/")]
        public IHttpActionResult PostWithDependentsWithWorkFlow([FromBody]ProductVersionDto value)
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
                            var entity = AddVersion(value);
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
                else if(value.ApprovalStatus == ApprovalStatusDto.Pending)
                        {
                    var entity = AddVersion(value);
                    return Ok(entity.ToDto());
                }
                else
                {
                    var wFIDto = new WorkFlowItemDto
                    {
                        Obj = value,
                        API = "api/ProductVersion/Dependents",
                        ApprovalStatus = ApprovalStatusDto.Pending,
                        Type = value.GetType().Name.ToString()

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


    }
}
