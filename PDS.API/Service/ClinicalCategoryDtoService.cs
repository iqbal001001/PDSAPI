using PDS.API.Dto;
using PDS.API.Extension;
using PDS.Domain;

namespace PDS.API.Service
{
    public class ClinicalCategoryDtoService : IDtoService<ClinicalCategory, ClinicalCategoryDto>
    {
        public ClinicalCategoryDto ToDto(ClinicalCategory entity)
        {
            return entity.ToDto();
        }

        public ClinicalCategory ToDomain(ClinicalCategoryDto dto, ClinicalCategory originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class ClinicalItemDtoService : IDtoService<ClinicalItem, ClinicalItemDto>
    {
        public ClinicalItemDto ToDto(ClinicalItem entity)
        {
            return entity.ToDto();
        }

        public ClinicalItem ToDomain(ClinicalItemDto dto, ClinicalItem originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }
    public class ClinicalProductCategoryDtoService : IDtoService<ClinicalProductCategory, ClinicalProductCategoryDto>
    {
        public ClinicalProductCategoryDto ToDto(ClinicalProductCategory entity)
        {
            return entity.ToDto();
        }

        public ClinicalProductCategory ToDomain(ClinicalProductCategoryDto dto, ClinicalProductCategory originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class FeatureDtoService : IDtoService<Feature, FeatureDto>
    {
        public FeatureDto ToDto(Feature entity)
        {
            return entity.ToDto();
        }

        public Feature ToDomain(FeatureDto dto, Feature originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class FeatureGroupDtoService : IDtoService<FeatureGroup, FeatureGroupDto>
    {
        public FeatureGroupDto ToDto(FeatureGroup entity)
        {
            return entity.ToDto();
        }

        public FeatureGroup ToDomain(FeatureGroupDto dto, FeatureGroup originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class FeatureTypeDtoService : IDtoService<FeatureType, FeatureTypeDto>
    {
        public FeatureTypeDto ToDto(FeatureType entity)
        {
            return entity.ToDto();
        }

        public FeatureType ToDomain(FeatureTypeDto dto, FeatureType originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }
    public class ItemDtoService : IDtoService<Item, ItemDto>
    {
        public ItemDto ToDto(Item entity)
        {
            return entity.ToDto();
        }

        public Item ToDomain(ItemDto dto, Item originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class FeatureItemDtoService : IDtoService<FeatureItem, FeatureItemDto>
    {
        public FeatureItemDto ToDto(FeatureItem entity)
        {
            return entity.ToDto();
        }

        public FeatureItem ToDomain(FeatureItemDto dto, FeatureItem originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }

    public class LimitDtoService : IDtoService<Limit, LimitDto>
    {
        public LimitDto ToDto(Limit entity)
        {
            return entity.ToDto();
        }

        public Limit ToDomain(LimitDto dto, Limit originalEntity)
        {
            return dto.ToDomain(originalEntity);
        }
    }
}