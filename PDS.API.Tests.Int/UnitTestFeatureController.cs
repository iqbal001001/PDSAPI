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
    public class UnitTestFeatureController
    {

        [TestMethod]
        public void Get()
        {
            try
            {
                using (var server = TestServer.Create<MyStartup>())
                {
                    HttpResponseMessage response;
                    response = server.HttpClient.GetAsync("api/Feature").Result;
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

                    var dto = new FeatureDto
                    {
                        Id = 0,
                         ClinicalCategoryId = 1,
                         GroupId = 1,
                         TypeId = 1 ,
                         Name = "feature 9",
                         Description = "F 1",
                         Items = new List<FeatureItemDto>
                         {
                             new FeatureItemDto { ItemId = 2, FeatureId = 0, UpdatedOn = DateTime.Now, CreatedOn = DateTime.Now}
                         }
                    };

                    HttpResponseMessage response;
                    response = server.HttpClient.PostAsJsonAsync("api/Feature/Items", dto).Result;
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
                    response = server.HttpClient.DeleteAsync("api/Feature?id=2").Result;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
