using PDS.API.Dto;
using PDS.Domain;
using System.Linq;

namespace PDS.API.Extension
{
    public static class ClinicalCategoryExtension
    {
        public static ClinicalCategoryDto ToDto(this ClinicalCategory cc, bool cascade = true)
        {
            cc.ClinicalItems?.ForEach(v => v.ClinicalCategoryId = cc.Id);
            cc.ClinicalProductCategories?.ForEach(v => v.ClinicalCategoryId = cc.Id);
            cc.Features?.ForEach(v => v.ClinicalCategoryId = cc.Id);

            var dto = new ClinicalCategoryDto
            {
                Name = cc.Name,
                Code = cc.Code ,
                //ClinicalItems = cc.ClinicalItems?.Select(v => v.ToDto()).ToList(),
                //ClinicalProductCategories = cc.ClinicalProductCategories?.Select(v => v.ToDto()).ToList()    ,
                //Features = cc.Features?.Select(v => v.ToDto()).ToList()

            };

            if (cascade)
            {
                dto.ClinicalItems = cc.ClinicalItems?.Select(v => v.ToDto()).ToList();
                dto.ClinicalProductCategories = cc.ClinicalProductCategories?.Select(v => v.ToDto()).ToList();
                dto.Features = cc.Features?.Select(v => v.ToDto()).ToList();
            }

            ((IData)cc).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ClinicalCategoryDtoExtension
    {
        public static ClinicalCategory ToDomain(this ClinicalCategoryDto cC, ClinicalCategory originalCC = null)
        {

            if (originalCC != null && originalCC.Id == cC.Id)
            {
                originalCC.Name = cC.Name;
                originalCC.Code = cC.Code;

                ((IDataDto)cC).ToDomain((IData)originalCC);
                return originalCC;
            }

            var data = new ClinicalCategory
            {
                Name = cC.Name,
                Code = cC.Code  ,
               // ClinicalItems = cC.ClinicalItems?.Select(v => v.ToDomain()).ToList()
            };

            ((IDataDto)cC).ToDomain((IData)data);
            return data;
        }
    }
    public static class ClinicalItemExtension
    {
        public static ClinicalItemDto ToDto(this ClinicalItem cItem)
        {

            var dto = new ClinicalItemDto
            {
                ClinicalCategoryId = cItem.ClinicalCategoryId,
                ItemId = cItem.ItemId,
                StartDate = cItem.StartDate,
                EndDate = cItem.EndDate

            };

            ((IData)cItem).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ClinicalItemDtoExtension
    {
        public static ClinicalItem ToDomain(this ClinicalItemDto cItem, ClinicalItem originalCItem = null)
        {

            if (originalCItem != null && originalCItem.Id == cItem.Id)
            {
                originalCItem.ClinicalCategoryId = cItem.ClinicalCategoryId;
                originalCItem.ItemId = cItem.ItemId;
                originalCItem.StartDate = cItem.StartDate;
                originalCItem.EndDate = cItem.EndDate;

                ((IDataDto)cItem).ToDomain((IData)originalCItem);
                return originalCItem;
            }

            var data = new ClinicalItem
            {
                ClinicalCategoryId = cItem.ClinicalCategoryId,
                ItemId = cItem.ItemId,
                StartDate = cItem.StartDate,
                EndDate = cItem.EndDate

            };

            ((IDataDto)cItem).ToDomain((IData)data);
            return data;
        }
    }

    public static class ClinicalProductCategoryExtension
    {
        public static ClinicalProductCategoryDto ToDto(this ClinicalProductCategory cItem)
        {

            var dto = new ClinicalProductCategoryDto
            {
                ClinicalCategoryId = cItem.ClinicalCategoryId,
                ProductCategoryId = cItem.ProductCategoryId,
                StartDate = cItem.StartDate,
                EndDate = cItem.EndDate

            };

            ((IData)cItem).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ClinicalProductCategoryDtoExtension
    {
        public static ClinicalProductCategory ToDomain(this ClinicalProductCategoryDto cItem, ClinicalProductCategory originalCItem = null)
        {

            if (originalCItem != null && originalCItem.Id == cItem.Id)
            {
                originalCItem.ClinicalCategoryId = cItem.ClinicalCategoryId;
                originalCItem.ProductCategoryId = cItem.ProductCategoryId;
                originalCItem.StartDate = cItem.StartDate;
                originalCItem.EndDate = cItem.EndDate;

                ((IDataDto)cItem).ToDomain((IData)originalCItem);
                return originalCItem;
            }

            var data = new ClinicalProductCategory
            {
                ClinicalCategoryId = cItem.ClinicalCategoryId,
                ProductCategoryId = cItem.ProductCategoryId,
                StartDate = cItem.StartDate,
                EndDate = cItem.EndDate

            };

            ((IDataDto)cItem).ToDomain((IData)data);
            return data;
        }
    }
}