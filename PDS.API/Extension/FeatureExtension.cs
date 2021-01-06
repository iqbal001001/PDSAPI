using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class FeatureExtension
    {
        public static FeatureDto ToDto(this Feature feature, bool cascade = true)
        {

            var dto = new FeatureDto
            {
                Name = feature.Name,
                Description = feature.Description,
                WaitingPeriod = feature.WaitingPeriod,
                IsMentalHealthWaiver = feature.IsMentalHealthWaiver,
                IsActive = feature.IsActive,
                IsDeleted = feature.IsDeleted,
                TypeId = feature.TypeId,
                GroupId = feature.GroupId,
                ClinicalCategoryId = feature.ClinicalCategoryId ?? 0,
                ClinicalCategory = feature.ClinicalCategory?.ToDto(false),
                Items = feature.Items?.Select(v => v.ToDto()).ToList(),
            };

            ((IData)feature).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class FeatureDtoExtension
    {
        public static Feature ToDomain(this FeatureDto feature, Feature originalFeature = null)
        {
            //feature.Items?.ForEach(v => v.FeatureId = feature.Id);
            if (originalFeature != null && originalFeature.Id == feature.Id)
            {
                originalFeature.Name = feature.Name;
                originalFeature.Description = feature.Description;
                originalFeature.WaitingPeriod = feature.WaitingPeriod;
                originalFeature.IsMentalHealthWaiver = feature.IsMentalHealthWaiver;
                originalFeature.IsActive = feature.IsActive;
                originalFeature.IsDeleted = feature.IsDeleted;
                originalFeature.TypeId = feature.TypeId;
                originalFeature.GroupId = feature.GroupId;
                originalFeature.ClinicalCategoryId = feature.ClinicalCategoryId != 0 ? feature.ClinicalCategoryId : (int?) null;
               // originalFeature.Items?.Select(v => v.ToDto()).ToList();
                ((IDataDto)feature).ToDomain((IData)originalFeature);
                return originalFeature;
            }

            var data = new Feature
            {
                Name = feature.Name,
                Description = feature.Description,
                WaitingPeriod = feature.WaitingPeriod,
                IsMentalHealthWaiver = feature.IsMentalHealthWaiver,
                IsActive = feature.IsActive,
                IsDeleted = feature.IsDeleted,
                TypeId = feature.TypeId,
                GroupId = feature.GroupId,
                ClinicalCategoryId = feature.ClinicalCategoryId != 0 ? feature.ClinicalCategoryId : (int?)null,
            //Items = feature.Items?.Select(v => v.ToDomain()).ToList()
        };

            ((IDataDto)feature).ToDomain((IData)data);
            return data;
        }
    }

    public static class FeatureTpeExtension
    {
        public static FeatureTypeDto ToDto(this FeatureType feature)
        {

            var dto = new FeatureTypeDto
            {    
                Name = feature.Name,
                DisplayName = feature.DisplayName

            };

            ((IData)feature).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class FeatureTypeDtoExtension
    {
        public static FeatureType ToDomain(this FeatureTypeDto feature, FeatureType originalFeature = null)
        {

            if (originalFeature != null && originalFeature.Id == feature.Id)
            {
                originalFeature.Name = feature.Name;
                originalFeature.DisplayName = feature.DisplayName;



                ((IDataDto)feature).ToDomain((IData)originalFeature);
                return originalFeature;
            }

            var data = new FeatureType
            {
                Name = feature.Name,
                DisplayName = feature.DisplayName

            };

            ((IDataDto)feature).ToDomain((IData)data);
            return data;
        }
    }

    public static class FeatureGroupExtension
    {
        public static FeatureGroupDto ToDto(this FeatureGroup feature)
        {

            var dto = new FeatureGroupDto
            {
                Name = feature.Name,
                DisplayName = feature.DisplayName

            };

            ((IData)feature).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class FeatureGroupDtoExtension
    {
        public static FeatureGroup ToDomain(this FeatureGroupDto feature, FeatureGroup originalFeature = null)
        {

            if (originalFeature != null && originalFeature.Id == feature.Id)
            {
                originalFeature.Name = feature.Name;
                originalFeature.DisplayName = feature.DisplayName;

                ((IDataDto)feature).ToDomain((IData)originalFeature);
                return originalFeature;
            }

            var data = new FeatureGroup
            {
                Name = feature.Name,
                DisplayName = feature.DisplayName

            };

            ((IDataDto)feature).ToDomain((IData)data);
            return data;
        }
    }
}