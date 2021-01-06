using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDS.API.Dto;

namespace Zap.DocumentStorage.Api.Tests.Int
{
    [TestClass]
    public class UnitTestProductSuiteController
    {

        [TestMethod]
        public void Get()
        {
            try
            {
                using (var server = TestServer.Create<MyStartup>())
                {
                    HttpResponseMessage response;
                    response = server.HttpClient.GetAsync("api/ProductSuite").Result;
                }
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void Post()
        {
            try
            {
                using (var server = TestServer.Create<MyStartup>())
                {
                 
                    var dto = new ProductSuiteDto
                    {
                        Id = 2,
                        Name = "Product Suite 5",
                        CategoryId = 1

                    };

                    HttpResponseMessage response;
                    response = server.HttpClient.PostAsJsonAsync("api/ProductSuite", dto).Result;
                }
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void PostwithDependents()
        {
            try
            {
                using (var server = TestServer.Create<MyStartup>())
                {

                    var dto = new ProductSuiteDto
                    {
                        Id = 4,
                        Name = "Product Suite 5",
                        UniqueId = new Guid("8537c238-c6f2-434f-8af4-c2b506e021be"),
                        CategoryId = 1,
                        Versions = new List<ProductVersionDto>
                        {
                            new ProductVersionDto { Id = 0,
                                                 UniqueId = Guid.NewGuid(),
                                                 StartDate = DateTime.Today,
                                                 EndDate   =DateTime.Today.AddDays(7)
                            }   ,
                            new ProductVersionDto { Id = 0,
                                                 UniqueId = Guid.NewGuid(),
                                                 StartDate = DateTime.Today.AddDays(8),
                                                 EndDate   =DateTime.Today.AddDays(14)
                            }
                        }

                    };

                    HttpResponseMessage response;
                    response = server.HttpClient.PostAsJsonAsync("api/ProductSuite/Dependents/", dto).Result;
                }
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void Delete()
        {
            try
            {
                using (var server = TestServer.Create<MyStartup>())
                {
                    HttpResponseMessage response;
                    response = server.HttpClient.DeleteAsync("api/ProductSuite?id=1").Result;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
