using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class ProductCodeExtension
    {
        public static ProductCodeDto ToDto(this ProductCode code)
        {
            code.Ancillaries?.ForEach(v => v.ProdutCodeId = code.Id);
            var dto = new ProductCodeDto
            {
                Id = code.Id,
                UniqueId = Guid.NewGuid(),
                Name = code.Name,
                Code = code.Code,
                Excess = code.Excess,
                HospitalRanking = code.HospitalRanking,
                ExtrasRanking = code.ExtrasRanking  ,
                Ancillaries = code.Ancillaries?.Select(v => v.ToDto()).ToList()
            };
            ((IData)code).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ProductCodeDtoExtension
    {
        public static ProductCode ToDomain(this ProductCodeDto code, ProductCode originalCode = null)
        {

            if (originalCode != null && originalCode.Id == code.Id)
            {
                originalCode.Name = code.Name;
                originalCode.Code = code.Code;
                originalCode.Excess = code.Excess;
                originalCode.HospitalRanking = code.HospitalRanking;
                originalCode.ExtrasRanking = code.ExtrasRanking;

                ((IDataDto)code).ToDomain((IData)originalCode);
                return originalCode;
            }

            var data = new ProductCode
            {
                Name = code.Name,
                Code = code.Code,
                Excess = code.Excess,
                HospitalRanking = code.HospitalRanking,
                ExtrasRanking = code.ExtrasRanking
            };

            ((IDataDto)code).ToDomain((IData)data);
            return data;
        }
    }
}