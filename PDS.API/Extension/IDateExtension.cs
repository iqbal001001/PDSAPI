using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PDS.API.Extension
{
    public static class IDateExtension
    {
        public static IDataDto ToDto(this IData data)
        {
            return null;
        }

        public static void ToDto(this IData data, IDataDto dataDto = null)
        {
            dataDto.Id = data.Id;
            dataDto.UpdatedBy = data.UpdatedBy;
            dataDto.UpdatedOn = data.UpdatedOn;
            dataDto.CreatedBy = data.CreatedBy;
            dataDto.CreatedOn = data.CreatedOn;
        }
        public static IData ToDomain(this IDataDto dataDto, IData data)
        {
            data.Id = dataDto.Id;
            data.UpdatedBy = dataDto.UpdatedBy;
            data.UpdatedOn = dataDto.UpdatedOn;
            data.CreatedBy = dataDto.CreatedBy;
            data.CreatedOn = dataDto.CreatedOn;

            return data;
        }
    }

    public static class IDateTypeExtension
    {
        public static void ToDto(this IType type, ITypeDto typeDto)
        {
            typeDto.Name = type.Name;
            typeDto.DisplayName = type.DisplayName;
            typeDto.UpdatedOn = type.UpdatedOn;
            typeDto.CreatedBy = type.CreatedBy;
            typeDto.CreatedOn = type.CreatedOn;

            ((IData)type).ToDto((IDataDto)typeDto);
        }
        public static void ToDomain(this ITypeDto typeDto, IType type)
        {
            type.Name = typeDto.Name;
            type.DisplayName = typeDto.DisplayName;

            ((IDataDto)typeDto).ToDomain((IData)type);
        }
    }
}