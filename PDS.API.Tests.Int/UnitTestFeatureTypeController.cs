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
    public class UnitTestFeatureTypeController
    {

        [TestMethod]
        public void Get()
        {
            try
            {
                using (var server = TestServer.Create<MyStartup>())
                {
                    HttpResponseMessage response;
                    response = server.HttpClient.GetAsync("api/FeatureType").Result;
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

                    var dto = new FeatureTypeDto
                    {
                        Id = 0,
                        Name = "Type 1",
                        DisplayName = "Type 1"
                    };

                    HttpResponseMessage response;
                    response = server.HttpClient.PostAsJsonAsync("api/FeatureType", dto).Result;
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
                    response = server.HttpClient.DeleteAsync("api/FeatureType?id=2").Result;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
