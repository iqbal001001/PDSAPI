using PDS.API.Dto;
using PDS.API.Extension;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Service
{
    public interface IDtoService<T,Dto> where T:class,IData where Dto: class, IDataDto
    {
        Dto ToDto(T entity);
        T ToDomain(Dto dto, T originalEntity);
    }

    //public class DtoService : IDtoService
    //{
    //    public virtual IDataDto ToDto(IData entity)
    //    {
    //        return entity.ToDto();
    //    }

    //    public virtual IData ToDomain(IDataDto dto, IData originalEntity)
    //    {
    //        return dto.ToDomain(originalEntity);
    //    }
    //}
    public class ProductSuiteDtoService  : IDtoService<ProductSuite,ProductSuiteDto>
    {
        public ProductSuiteDto ToDto(ProductSuite entity)
        {
            try
            {
                return entity.ToDto();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ProductSuite ToDomain(ProductSuiteDto dto, ProductSuite originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }
    public class ProductVersionDtoService : IDtoService<ProductVersion, ProductVersionDto>
    {
        public ProductVersionDto ToDto(ProductVersion entity)
        {
            return entity.ToDto();
        }

        public ProductVersion ToDomain(ProductVersionDto dto, ProductVersion originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class ProductLineDtoService : IDtoService<ProductLine, ProductLineDto>
    {
        public ProductLineDto ToDto(ProductLine entity)
        {
            return entity.ToDto();
        }

        public ProductLine ToDomain(ProductLineDto dto, ProductLine originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class ProductCodeDtoService : IDtoService<ProductCode, ProductCodeDto>
    {
        public ProductCodeDto ToDto(ProductCode entity)
        {
            return entity.ToDto();
        }

        public ProductCode ToDomain(ProductCodeDto dto, ProductCode originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class AncillaryDtoService : IDtoService<Ancillary, AncillaryDto>
    {
        public AncillaryDto ToDto(Ancillary entity)
        {
            return entity.ToDto();
        }

        public Ancillary ToDomain(AncillaryDto dto, Ancillary originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class ProductCategoryDtoService : IDtoService<ProductCategory, ProductCategoryDto>
    {
        public ProductCategoryDto ToDto(ProductCategory entity)
        {
            return entity.ToDto();
        }
        public ProductCategory ToDomain(ProductCategoryDto dto, ProductCategory originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }
}