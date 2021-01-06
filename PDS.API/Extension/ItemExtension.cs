using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class ItemExtension
    {
        public static ItemDto ToDto(this Item code)
        {

            var dto = new ItemDto
            {
                Code = code.Code,
                Type = code.Type,
                SpecialtyCode = code.SpecialtyCode,
                StartDate = code.StartDate,
                EndDate = code.EndDate,
                Description = code.Description,
                ProviderNumber = code.ProviderNumber,
                BenefitReplacementPeriod = code.BenefitReplacementPeriod,
                ReasonabilityRules = code.ReasonabilityRules,
                AssessorRules = code.AssessorRules

    };
            ((IData)code).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ItemDtoExtension
    {
        public static Item ToDomain(this ItemDto code, Item originalCode = null)
        {

            if (originalCode != null && originalCode.Id == code.Id)
            {
                originalCode.Code = code.Code;
                originalCode.Type = code.Type;
                originalCode.SpecialtyCode = code.SpecialtyCode;
                originalCode.StartDate = code.StartDate;
                originalCode.EndDate = code.EndDate;
                originalCode.Description = code.Description;
                originalCode.ProviderNumber = code.ProviderNumber;
                originalCode.BenefitReplacementPeriod = code.BenefitReplacementPeriod;
                originalCode.ReasonabilityRules = code.ReasonabilityRules;
                originalCode.AssessorRules = code.AssessorRules;

                ((IDataDto)code).ToDomain((IData)originalCode);
                return originalCode;
            }

            var data = new Item
            {
                Code = code.Code,
                Type = code.Type,
                SpecialtyCode = code.SpecialtyCode,
                StartDate = code.StartDate,
                EndDate = code.EndDate,
                Description = code.Description,
                ProviderNumber = code.ProviderNumber,
                BenefitReplacementPeriod = code.BenefitReplacementPeriod,
                ReasonabilityRules = code.ReasonabilityRules,
                AssessorRules = code.AssessorRules
            };

            ((IDataDto)code).ToDomain((IData)data);
            return data;
        }
    }


    public static class AncillaryExtension
    {
        public static AncillaryDto ToDto(this Ancillary code)
        {

            var dto = new AncillaryDto
            {
                ProdutCodeId = code.ProdutCodeId,
                ItemId = code.ItemId

            };
            ((IData)code).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class AncillaryDtoExtension
    {
        public static Ancillary ToDomain(this AncillaryDto code, Ancillary originalCode = null)
        {

            if (originalCode != null && originalCode.Id == code.Id)
            {
                originalCode.ProdutCodeId = code.ProdutCodeId;
                originalCode.ItemId = code.ItemId;

                ((IDataDto)code).ToDomain((IData)originalCode);
                return originalCode;
            }

            var data = new Ancillary
            {
                ProdutCodeId = code.ProdutCodeId,
                ItemId = code.ItemId
            };

            ((IDataDto)code).ToDomain((IData)data);
            return data;
        }
    }
}