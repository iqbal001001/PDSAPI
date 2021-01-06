using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class LimitExtension
    {
        public static LimitDto ToDto(this Limit code)
        {

            var dto = new LimitDto
            {
                LimitTypeId = code.LimitTypeId,
                Amount = code.Amount,
                Percentage = code.Percentage,
                Number = code.Number,
                Description = code.Description
    };
            ((IData)code).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class LimitDtoExtension
    {
        public static Limit ToDomain(this LimitDto code, Limit originalCode = null)
        {

            if (originalCode != null && originalCode.Id == code.Id)
            {
                originalCode.LimitTypeId = code.LimitTypeId;
                originalCode.Amount = code.Amount;
                originalCode.Percentage = code.Percentage;
                originalCode.Number = code.Number;
                originalCode.Description = code.Description;

                ((IDataDto)code).ToDomain((IData)originalCode);
                return originalCode;
            }

            var data = new Limit
            {
                LimitTypeId = code.LimitTypeId,
                Amount = code.Amount,
                Percentage = code.Percentage,
                Number = code.Number,
                Description = code.Description
            };

            ((IDataDto)code).ToDomain((IData)data);
            return data;
        }
    }

    public static class LimitTypeExtension
    {
        public static LimitTypeDto ToDto(this LimitType code)
        {

            var dto = new LimitTypeDto
            {
                Name = code.Name,
                DisplayName = code.DisplayName
            };
            ((IData)code).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class LimitypeDtoExtension
    {
        public static LimitType ToDomain(this LimitTypeDto code, LimitType originalCode = null)
        {

            if (originalCode != null && originalCode.Id == code.Id)
            {
                originalCode.Name = code.Name;
                originalCode.DisplayName = code.DisplayName;

                ((IDataDto)code).ToDomain((IData)originalCode);
                return originalCode;
            }

            var data = new LimitType
            {
                Name = code.Name,
                DisplayName = code.DisplayName
            };

            ((IDataDto)code).ToDomain((IData)data);
            return data;
        }
    }
}