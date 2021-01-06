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
    public class UnitTestProductVersionController
    {

        [TestMethod]
        public void Get()
        {
            try
            {
                using (var server = TestServer.Create<MyStartup>())
                {
                    HttpResponseMessage response;
                    response = server.HttpClient.GetAsync("api/ProductVersion").Result;
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

                    var dto = new ProductVersionDto
                    {
                        Id = 0,
                         SuiteId=3,
                          StartDate = DateTime.Now,
                          EndDate = DateTime.Now.AddYears(1)
                         
                          

                    };

                    HttpResponseMessage response;
                    response = server.HttpClient.PostAsJsonAsync("api/ProductVersion", dto).Result;
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
                    response = server.HttpClient.DeleteAsync("api/ProductVersion?id=3").Result;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
