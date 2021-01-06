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
    public class UnitTestClinicalCategoryController
    {

        [TestMethod]
        public void Get()
        {
            try
            {
                using (var server = TestServer.Create<MyStartup>())
                {
                    HttpResponseMessage response;
                    response = server.HttpClient.GetAsync("api/ClinicalCategory").Result;
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

                    var dto = new ClinicalCategoryDto
                    {
                        Id = 0,
                         Name = "Clinical 1",
                         Code = "CC1"
                    };

                    HttpResponseMessage response;
                    response = server.HttpClient.PostAsJsonAsync("api/ClinicalCategory", dto).Result;
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
                    response = server.HttpClient.DeleteAsync("api/ClinicalCategory?id=2").Result;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
