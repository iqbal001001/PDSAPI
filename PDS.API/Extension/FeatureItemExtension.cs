using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class FeatureItemExtension
    {
        public static FeatureItemDto ToDto(this FeatureItem entity)
        {

            var dto = new FeatureItemDto
            {
                FeatureId = entity.FeatureId,
                ItemId = entity.ItemId
            };
            ((IData)entity).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class FeatureItemDtoExtension
    {
        public static FeatureItem ToDomain(this FeatureItemDto dto, FeatureItem originalEntity = null)
        {

            if (originalEntity != null && originalEntity.Id == dto.Id)
            {
                originalEntity.FeatureId = dto.FeatureId;
                originalEntity.ItemId = dto.ItemId;


                ((IDataDto)dto).ToDomain((IData)originalEntity);
                return originalEntity;
            }

            var data = new FeatureItem
            {
                FeatureId = dto.FeatureId,
                ItemId = dto.ItemId,
            };

            ((IDataDto)dto).ToDomain((IData)data);
            return data;
        }
    }
}