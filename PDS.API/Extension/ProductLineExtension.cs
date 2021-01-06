using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class ProductLineExtension
    {
        public static ProductLineDto ToDto(this ProductLine line)
        {
            line.Excesses?.ForEach(v => v.ProductLineId = line.Id);

            var dto = new ProductLineDto
            {
                Id = line.Id,
                UniqueId = line.UniqueId,
                VersionId = line.VersionId,
                ProductCodeId = line.CodeId  ,
                ProductCode = line.Code?.ToDto(),
                Excesses = line.Excesses?.Select(v => v.ToDto()).ToList()
            };

            ((IData)line).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ProductLineDtoExtension
    {
        public static ProductLine ToDomain(this ProductLineDto line, ProductLine originalLine = null)
        {
            line.Excesses?.ForEach(v => v.ProductLineId = line.Id);

            if (originalLine != null && originalLine.UniqueId == line.UniqueId)
            {
                originalLine.VersionId = line.VersionId;
                originalLine.CodeId = line.ProductCodeId;

                foreach (var excess in line.Excesses ?? Enumerable.Empty<ProductExcessDto>())
                {
                    var original = originalLine.Excesses.SingleOrDefault(l => l.Id == excess.Id);
                    if (original != null)
                    {
                        var updatedOriginal = excess.ToDomain(original);
                        var index = originalLine.Excesses.IndexOf(original);
                        originalLine.Excesses[index] = updatedOriginal;
                    }
                    else
                    {
                        var Domainlayout = excess.ToDomain();
                        originalLine.Excesses.Add(Domainlayout);
                    }

                }

                ((IDataDto)line).ToDomain((IData)originalLine);
                return originalLine;
            }

            var data = new ProductLine
            {
                UniqueId = line.UniqueId,
                VersionId = line.VersionId,
                CodeId = line.ProductCodeId,
                Excesses = line.Excesses?.Select(v => v.ToDomain()).ToList(),
            };

            ((IDataDto)line).ToDomain((IData)data);
            return data;
        }
    }
}