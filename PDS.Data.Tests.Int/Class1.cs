using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDS.Data.Repository;
using PDS.Domain;

namespace PDS.Data.Tests.Int
{
    [TestClass]
    public class UnitTestSuteRepo
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var repo = new ProductSuiteRepo();
                var uow = new PDSDBUnitOfWork();
                var suite = new ProductSuite
                {
                    Id = 0,
                    UniqueId = Guid.NewGuid(),
                    Name = "Product Suite 1",
                    CategoryId = 1,
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    //Versions = new List<ProductVersion>
                    //{
                    //    new ProductVersion { Id = 0,
                    //                         StartDate = DateTime.Today,
                    //                         EndDate   =DateTime.Today.AddDays(7) 
                    //    }   ,
                    //    new ProductVersion { Id = 0,
                    //                         StartDate = DateTime.Today.AddDays(8),
                    //                         EndDate   =DateTime.Today.AddDays(14)
                    //    }
                    //}

                };
                repo.Add(suite);
                uow.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                var repo = new ProductCategoryRepo();
                var uow = new PDSDBUnitOfWork();
                var suite = new ProductCategory
                {
                    Id = 0,
                    Name = "Product Category 1",
                    UpdatedOn = DateTime.Now,
                    CreatedOn = DateTime.Now

                };
                repo.Add(suite);
                uow.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            try
            {
                var repo = new ProductCategoryRepo();


                var x = repo.Get();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
