using PDS.API.Dto;
using PDS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PDS.API.Extension
{
    public static class ProductSuiteExtension
    {
        public static ProductSuiteDto ToDto(this ProductSuite suite)
        {
            suite.Versions?.ForEach(v => v.SuiteId = suite.Id);

           

            var dto = new ProductSuiteDto
            {
                CategoryId = suite.CategoryId,
                UniqueId = suite.UniqueId,
                Name = suite.Name  ,
                Versions = suite.Versions?.Select(v => v.ToDto()).ToList()

            };
            ((IData)suite).ToDto((IDataDto)dto);
            return dto;
        }
    }

    public static class ProductSuiteDtoExtension
    {
        public static ProductSuite ToDomain(this ProductSuiteDto suite, ProductSuite originalsuite = null)
        {
            suite.Versions?.ForEach(v => v.SuiteId = suite.Id);

            if (originalsuite != null && originalsuite.UniqueId == suite.UniqueId)
            {
                originalsuite.Name = suite.Name;
                originalsuite.CategoryId = suite.CategoryId;

                originalsuite.Versions
               = suite.Versions?.Select(v => v.ToDomain(originalsuite?.Versions.FirstOrDefault(ov => ov.UniqueId == v.UniqueId))).ToList();

                //foreach (var version in suite.Versions ?? Enumerable.Empty<ProductVersionDto>())
                //{
                //    var original = originalsuite.Versions.SingleOrDefault(l => l.Id == version.Id);
                //    if (original != null)
                //    {
                //        var updatedOriginal = version.ToDomain(original);
                //        var index = originalsuite.Versions.IndexOf(original);
                //        originalsuite.Versions[index] = updatedOriginal;
                //    }
                //    else
                //    {
                //        var Domainlayout = version.ToDomain();
                //        originalsuite.Versions.Add(Domainlayout);
                //    }

                //}

                ((IDataDto)suite).ToDomain((IData)originalsuite);
                return originalsuite;
            }

            var data = new ProductSuite
            {
                UniqueId = suite.UniqueId,
                Name = suite.Name,
                CategoryId = suite.CategoryId,
                Versions = suite.Versions?.Select(v => v.ToDomain()).ToList(),
            };

            ((IDataDto)suite).ToDomain((IData)data);
            return data;
        }
    }
}