using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class VersionExtension
    {
        public static ProductVersionDto ToDto(this ProductVersion version)
        {
            version.Lines?.ForEach(v => v.VersionId = version.Id);

            var dto = new ProductVersionDto
            {
                SuiteId  =    version.SuiteId,
                UniqueId = version.UniqueId,
                StartDate = version.StartDate,
                EndDate = version.EndDate,
                SalesChannels = version.SalesChannels,
                MinAgeOfOldesPersion = version.MinAgeOfOldesPersion,
                IsApproved = version.IsApproved,
                IsDelete = version.IsDelete,
                StateCoverge = version.StateCoverge,
                Scale = version.Scale,
                ScaleQuoteMap = version.ScaleQuoteMap,
                CoPayment = version.CoPayment,
                AccidentWaiver = version.AccidentWaiver,
                DaySurgeryWaiver = version.DaySurgeryWaiver,
                ChildrenWaiver = version.ChildrenWaiver,
                Description = version.Description,
                StaffSubsidy = version.StaffSubsidy,
                PerEpisodic = version.PerEpisodic     ,
                ProductLines = version.Lines?.Select(v => v.ToDto()).ToList()
            };

            ((IData)version).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class VersionDtoExtension
    {
        public static ProductVersion ToDomain(this ProductVersionDto version, ProductVersion originalVersion = null)
        {
            version.ProductLines?.ForEach(v => v.VersionId = version.Id);

            if (originalVersion != null && originalVersion.UniqueId == version.UniqueId)
            {
                originalVersion.SuiteId = version.SuiteId;
                originalVersion.StartDate = version.StartDate;
                originalVersion.EndDate = version.EndDate;
                originalVersion.SalesChannels = version.SalesChannels;
                originalVersion.MinAgeOfOldesPersion = version.MinAgeOfOldesPersion;
                originalVersion.IsApproved = version.IsApproved;
                originalVersion.IsDelete = version.IsDelete;
                originalVersion.StateCoverge = version.StateCoverge;
                originalVersion.Scale = version.Scale;
                originalVersion.ScaleQuoteMap = version.ScaleQuoteMap;
                originalVersion.CoPayment = version.CoPayment;
                originalVersion.AccidentWaiver = version.AccidentWaiver;
                originalVersion.DaySurgeryWaiver = version.DaySurgeryWaiver;
                originalVersion.ChildrenWaiver = version.ChildrenWaiver;
                originalVersion.Description = version.Description;
                originalVersion.StaffSubsidy = version.StaffSubsidy;
                originalVersion.PerEpisodic = version.PerEpisodic;

                foreach (var line in version.ProductLines ?? Enumerable.Empty<ProductLineDto>())
                {
                    var original = originalVersion.Lines.SingleOrDefault(l => l.UniqueId == line.UniqueId);
                    if (original != null)
                    {
                        var updatedOriginal = line.ToDomain(original);
                        var index = originalVersion.Lines.IndexOf(original);
                        originalVersion.Lines[index] = updatedOriginal;
                    }
                    else
                    {
                        var Domainlayout = line.ToDomain();
                        originalVersion.Lines.Add(Domainlayout);
                    }

                }

                ((IDataDto)version).ToDomain((IData)originalVersion);
                return originalVersion;
            }

            var data = new ProductVersion
            {
                SuiteId = version.SuiteId,
                UniqueId = version.UniqueId,
                StartDate = version.StartDate,
                EndDate = version.EndDate,
                SalesChannels = version.SalesChannels,
                MinAgeOfOldesPersion = version.MinAgeOfOldesPersion,
                IsApproved = version.IsApproved,
                IsDelete = version.IsDelete,
                StateCoverge = version.StateCoverge,
                Scale = version.Scale,
                ScaleQuoteMap = version.ScaleQuoteMap,
                CoPayment = version.CoPayment,
                AccidentWaiver = version.AccidentWaiver,
                DaySurgeryWaiver = version.DaySurgeryWaiver,
                ChildrenWaiver = version.ChildrenWaiver,
                Description = version.Description,
                StaffSubsidy = version.StaffSubsidy,
                PerEpisodic = version.PerEpisodic,
                Lines = version.ProductLines?.Select(v => v.ToDomain()).ToList(),
            };

            ((IDataDto)version).ToDomain((IData)data);
            return data;
        }
    }
}