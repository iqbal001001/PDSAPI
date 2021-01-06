using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class ProductCategoryExtension
    {
        public static ProductCategoryDto ToDto(this ProductCategory category)
        {

            var dto = new ProductCategoryDto
            {
                Id = category.Id,
                UniqueId = category.UniqueId,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted,
                Name = category.Name

            };
            ((IData)category).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ProductCategotyDtoExtension
    {
        public static ProductCategory ToDomain(this ProductCategoryDto category, ProductCategory originalCategory = null)
        {

            if (originalCategory != null && originalCategory.UniqueId == category.UniqueId)
            {
                originalCategory.Name = category.Name;
                originalCategory.IsActive = category.IsActive;
                originalCategory.IsDeleted = category.IsDeleted;

                ((IDataDto)category).ToDomain((IData)originalCategory);
                return originalCategory;
            }

            var data = new ProductCategory
            {
                UniqueId = category.UniqueId,
                IsActive = category.IsActive,
                IsDeleted = category.IsDeleted,
                Name = category.Name
            };

            ((IDataDto)category).ToDomain((IData)data);
            return data;
        }
    }
}