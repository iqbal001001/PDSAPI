using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class ProductExcessExtension
    {
        public static ProductExcessDto ToDto(this ProductExcess excess)
        {
            var dto = new ProductExcessDto
            {
                ProductLineId = excess.ProductLineId,
                ExcessTypeId = excess.TypeId,
                ExcessGroupId = excess.GroupId,
                Excess = excess.Excess,
                PerEpisodic = excess.PerEpisodic,
                PerAdult = excess.PerAdult
            };

            ((IData)excess).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ProductExcessDtoExtension
    {
        public static ProductExcess ToDomain(this ProductExcessDto excess, ProductExcess originalExcess = null)
        {
            if (originalExcess != null && originalExcess.Id == excess.Id)
            {
                originalExcess.ProductLineId = excess.ProductLineId;
                originalExcess.TypeId = excess.ExcessTypeId;
                originalExcess.GroupId = excess.ExcessGroupId;
                originalExcess.Excess = excess.Excess;
                originalExcess.PerEpisodic = excess.PerEpisodic;

                ((IDataDto)excess).ToDomain((IData)originalExcess);
                return originalExcess;
            }

            var data = new ProductExcess
            {
                ProductLineId = excess.ProductLineId,
                TypeId = excess.ExcessTypeId,
                GroupId = excess.ExcessGroupId,
                Excess = excess.Excess,
                PerEpisodic = excess.PerEpisodic,
                PerAdult = excess.PerAdult
            };

            ((IDataDto)excess).ToDomain((IData)data);
            return data;
        }
    }

    public static class ProductExcessTypeExtension
    {
        public static ExcessTypeDto ToDto(this ExcessType excessType)
        {
            var dto = new ExcessTypeDto
            {
            };

            ((IData)excessType).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ProductExcessTypeDtoExtension
    {
        public static ExcessType ToDomain(this ExcessTypeDto excessType, ExcessType originalExcessType = null)
        {
            if (originalExcessType != null && originalExcessType.Id == excessType.Id)
            {
                ((IDataDto)excessType).ToDomain((IData)originalExcessType);
                return originalExcessType;
            }

            var data = new ExcessType
            {
            };

            ((IDataDto)excessType).ToDomain((IData)data);
            return data;
        }
    }

    public static class ProductExcessGroupExtension
    {
        public static ExcessGroupDto ToDto(this ExcessGroup excessGroup)
        {
            var dto = new ExcessGroupDto
            {
            };

            ((IData)excessGroup).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ProductExcessGroupDtoExtension
    {
        public static ExcessGroup ToDomain(this ExcessGroupDto excessGroup, ExcessGroup originalExcessGroup = null)
        {
            if (originalExcessGroup != null && originalExcessGroup.Id == excessGroup.Id)
            {
                ((IDataDto)excessGroup).ToDomain((IData)originalExcessGroup);
                return originalExcessGroup;
            }

            var data = new ExcessGroup
            {
            };

            ((IDataDto)excessGroup).ToDomain((IData)data);
            return data;
        }
    }
}